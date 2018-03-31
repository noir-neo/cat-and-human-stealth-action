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
            _rigidbody.MoveRotation(Quaternion.LookRotation(movement.X0Y()));
            _rigidbody.MovePosition(transform.position + transform.forward * movement.magnitude);
        }
    }
}
