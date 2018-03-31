using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

namespace Characters
{
    [RequireComponent(typeof(CharacterParameters))]
    public class CharacterCore : MonoBehaviour, ICharacterPosition
    {
        [SerializeField] private CharacterParameters _parameters;
        public CharacterParameters CharacterParameters => _parameters;

        private readonly FloatReactiveProperty _moveSpeed = new FloatReactiveProperty(0);
        public IObservable<float> MoveSpeed => _moveSpeed;
        public Vector2 Direction { private get; set; }

        public IObservable<Vector3> Position => this.FixedUpdateAsObservable().Select(_ => transform.position);

        private void Awake()
        {
            _moveSpeed.Value = _parameters.MoveSpeed;
        }

        public Vector2 Velocity()
        {
            return Direction * _moveSpeed.Value;
        }
    }
}
