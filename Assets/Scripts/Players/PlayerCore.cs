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

        private readonly ISubject<Vector3> _jump = new ReplaySubject<Vector3>();
        public IObservable<Vector3> Jump => _jump;

        private readonly ISubject<bool> _gameoverSubject = new Subject<bool>();
        public IObservable<bool> GameOverAsObservable()
        {
            return _gameoverSubject;
        }

        [Inject]
        public void Initialize(IInputEventProvider inputEventProvider)
        {
            inputEventProvider.MoveDirection
                .Subscribe(input => _characterCore.Direction = (Vector2.up + Vector2.right * input).normalized) // Automatic Movement + User Input
                .AddTo(this);
        }

        public void Goal()
        {
            _gameoverSubject.OnNext(true);
        }

        public void Caught()
        {
            _gameoverSubject.OnNext(false);
        }

        public void JumpTo(Vector3 position)
        {
            _jump.OnNext(position);
        }
    }
}
