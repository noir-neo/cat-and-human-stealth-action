using UnityEngine;
using UniRx;
using System;

namespace Players
{
    [RequireComponent(typeof(PlayerParameters))]
    public class PlayerCore : MonoBehaviour
    {
        [SerializeField] private PlayerParameters _parameters;
        public PlayerParameters PlayerParameters => _parameters;

        private readonly FloatReactiveProperty _moveSpeed = new FloatReactiveProperty(0);

        public IObservable<Vector2> Movement => _moveSpeed.Select(speed => Vector2.up * speed);

        private void Awake()
        {
            _moveSpeed.Value = _parameters.MoveSpeed;
        }
    }
}
