using UnityEngine;
using UniRx;
using System;
using Characters;
using Zenject;

namespace Players
{
    [RequireComponent(typeof(CharacterCore))]
    public class PlayerCore : MonoBehaviour
    {
        [SerializeField] private CharacterCore _characterCore;

        private readonly ISubject<Unit> _jump = new Subject<Unit>();
        public IObservable<Unit> Jump => _jump;

        private readonly BoolReactiveProperty _isCrossedGoal = new BoolReactiveProperty(false);
        public IObservable<bool> IsCrossedGoal => _isCrossedGoal;

        [Inject]
        public void Initialize(IInputEventProvider inputEventProvider)
        {
            inputEventProvider.MoveDirection
                .Subscribe(input => _characterCore.Direction = (Vector2.up + Vector2.right * input).normalized) // Automatic Movement + User Input
                .AddTo(this);
        }

        public void Goal()
        {
            _isCrossedGoal.Value = true;
        }
    }
}
