using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Players
{
    [RequireComponent(typeof(PlayerCore))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private PlayerCore _playerCore;
        [SerializeField] private Rigidbody _rigidbody;

        private void Start()
        {
            this.FixedUpdateAsObservable()
                .WithLatestFrom(_playerCore.Movement, (_, movement) => Time.deltaTime * movement)
                .Subscribe(Move)
                .AddTo(this);
        }

        private void Move(Vector2 movement)
        {
            _rigidbody.MovePosition(transform.position + movement.X0Y());
        }
    }
}
