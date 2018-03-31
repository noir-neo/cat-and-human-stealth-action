using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using GameManagers;

namespace Characters
{
    [RequireComponent(typeof(CharacterParameters))]
    public class CharacterCore : MonoBehaviour, ICharacterPosition
    {
        [SerializeField] private CharacterParameters _parameters;
        public CharacterParameters CharacterParameters => _parameters;

        private float _moveSpeed = 0;
        public bool IsMovable { private get; set; }
        public Vector2 Direction { private get; set; }

        public IObservable<Vector3> Position => this.FixedUpdateAsObservable().Select(_ => transform.position);

        private void Awake()
        {
            _moveSpeed = _parameters.MoveSpeed;
        }

        public Vector2 Velocity()
        {
            var speed = IsMovable ? _moveSpeed : 0;
            return Direction * speed;
        }
    }
}
