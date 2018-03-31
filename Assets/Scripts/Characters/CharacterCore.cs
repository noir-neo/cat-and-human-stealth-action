using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using GameManagers;

namespace Characters
{
    [RequireComponent(typeof(CharacterParameters))]
    public class CharacterCore : MonoBehaviour, ICharacterPosition, IMainGameStartObserver, IMainGameEndObserver
    {
        [SerializeField] private CharacterParameters _parameters;
        public CharacterParameters CharacterParameters => _parameters;

        private float _moveSpeed = 0;
        private bool _isMovable = false;
        public Vector2 Direction { private get; set; }

        public IObservable<Vector3> Position => this.FixedUpdateAsObservable().Select(_ => transform.position);

        private void Awake()
        {
            _moveSpeed = _parameters.MoveSpeed;
        }

        public Vector2 Velocity()
        {
            var speed = _isMovable ? _moveSpeed : 0;
            return Direction * speed;
        }

        public void MainGameStart()
        {
            _isMovable = true;
        }

        public void MainGameEnd()
        {
            _isMovable = false;
        }
    }
}
