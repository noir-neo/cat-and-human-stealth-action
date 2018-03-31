using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Zenject;

namespace Characters
{
    [RequireComponent(typeof(CharacterCore))]
    public class CharacterMover : MonoBehaviour
    {
        [SerializeField] private CharacterCore _characterCore;
        [SerializeField] private Rigidbody _rigidbody;

        void FixedUpdate()
        {
            Move(_characterCore.Velocity() * Time.deltaTime);
        }

        private void Move(Vector2 movement)
        {
            _rigidbody.MovePosition(transform.position + movement.X0Y());
        }
    }
}
