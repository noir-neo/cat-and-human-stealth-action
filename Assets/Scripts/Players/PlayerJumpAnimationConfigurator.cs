using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Characters;

namespace Players
{
    [RequireComponent(typeof(PlayerCore), typeof(Animator))]
    public class PlayerJumpAnimationConfigurator : MonoBehaviour
    {
        [SerializeField] private CharacterCore _characterCore;
        [SerializeField] private PlayerCore _playerCore;
        [SerializeField] private Rigidbody _rigidBody;
        [SerializeField] private Animator _animator;

        public void Start()
        {
            _playerCore.JumpAsObservable()
                .Subscribe(target =>
                {
                    _characterCore.IsMovable = false;
                    _rigidBody.isKinematic = true;
                    _animator.applyRootMotion = true;
                    _animator.SetBool("IsJumping", true);
                })
                .AddTo(this);

            var jumpState = _animator.GetBehaviour<ObservableStateMachineTrigger>();
            jumpState.OnStateUpdateAsObservable()
                .WithLatestFrom(_playerCore.JumpAsObservable(), (info, target) => (new Tuple<Animator, Vector3>(info.Animator, target)))
                .Subscribe(pair =>
                {
                    var animator = pair.Item1;
                    if (animator.isMatchingTarget)
                    {
                        return;
                    }
                    var targetPosition = pair.Item2;
                    var currentPosition = _rigidBody.position;
                    var rotation =  Quaternion.identity; // Quaternion.LookRotation(targetPosition - currentPosition);
                    animator.MatchTarget(targetPosition, rotation, AvatarTarget.Root, new MatchTargetWeightMask(Vector3.one, 1), 0, 1);
                })
                .AddTo(this);
            jumpState.OnStateExitAsObservable()
                .Subscribe(info =>
                {
                    _animator.SetBool("IsJumping", false);
                    _animator.applyRootMotion = false;
                    _rigidBody.isKinematic = false;
                    _characterCore.IsMovable = true;
                })
                .AddTo(this);

        }
    }
}