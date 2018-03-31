using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;

namespace Players
{
    [RequireComponent(typeof(PlayerParameters))]
    public class PlayerCore : MonoBehaviour, IPlayerPosition
    {
        [SerializeField] private PlayerParameters _parameters;
        public PlayerParameters PlayerParameters => _parameters;

        private readonly FloatReactiveProperty _moveSpeed = new FloatReactiveProperty(0);
        public IObservable<float> MoveSpeed => _moveSpeed;

        private readonly ISubject<Unit> _jump = new Subject<Unit>();
        public IObservable<Unit> Jump => _jump;

        public IObservable<Vector3> Position => this.FixedUpdateAsObservable().Select(_ => transform.position);

        private void Awake()
        {
            _moveSpeed.Value = _parameters.MoveSpeed;
        }
    }
}
