using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Characters;

namespace Players
{
    [RequireComponent(typeof(PlayerCore), typeof(Animator))]
    public class PlayerJumpAnimationConfigurator: MonoBehaviour
    {
        [SerializeField] private CharacterCore _characterCore;
        [SerializeField] private PlayerCore _playerCore;
        [SerializeField] private Rigidbody _rigidBody;
        [SerializeField] private Animator _animator;

        public void Start()
        {
            _animator.enabled = false;

            _playerCore.Jump
                .Subscribe(_ => {
                    _characterCore.IsMovable = false;
                    _rigidBody.isKinematic = true;
                    _animator.enabled = true;
                })
                .AddTo(this);

            var jumpAdjuster = _animator.GetBehaviour<ObservableStateMachineTrigger>();

            var targetBodyPart = AvatarTarget.Root;
            var weightMask = new MatchTargetWeightMask(Vector3.one, 1);
            var startNormalizedTime = 0f;
            var endNormalizedTime = 1f;

            jumpAdjuster.OnStateUpdateAsObservable()
                .WithLatestFrom(_playerCore.Jump, (info, target) => (new Tuple<Animator, Vector3>(info.Animator, target)))
                .Subscribe(pair => {
                    var animator = pair.Item1;
                    var targetPosition = pair.Item2;
                    var currentPosition = _rigidBody.position;
                    var matchPosition = targetPosition;
                    var matchRotation = Quaternion.LookRotation(targetPosition - currentPosition);
                    animator.MatchTarget(matchPosition, matchRotation, targetBodyPart, weightMask, startNormalizedTime, endNormalizedTime);
                })
                .AddTo(this);

            jumpAdjuster.OnStateExitAsObservable()
                .Subscribe(info => {
                    _animator.enabled = false;
                    _rigidBody.isKinematic = false;
                    _characterCore.IsMovable = true;
                });

        }
    }
}