using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Zenject;

namespace Players
{
    [RequireComponent(typeof(PlayerCore))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private PlayerCore _playerCore;
        [SerializeField] private Rigidbody _rigidbody;

        [Inject]
        public void Initialize(IInputEventProvider inputEventProvider)
        {
            this.FixedUpdateAsObservable()
                .WithLatestFrom(inputEventProvider.MoveDirection, (_, input) => input)
                .Select(input => (Vector2.up + input).normalized)
                .WithLatestFrom(_playerCore.MoveSpeed, (direction, speed) => direction * speed * Time.deltaTime)
                .Subscribe(Move)
                .AddTo(this);
        }

        private void Move(Vector2 movement)
        {
            _rigidbody.MovePosition(transform.position + movement.X0Y());
        }
    }
}
