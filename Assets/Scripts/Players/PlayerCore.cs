using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using Characters;

namespace Players
{
    [RequireComponent(typeof(CharacterCore))]
    public class PlayerCore : MonoBehaviour
    {
        [SerializeField] private CharacterCore _characterCore;

        public IObservable<float> MoveSpeed => _characterCore.MoveSpeed;

        private readonly ISubject<Unit> _jump = new Subject<Unit>();
        public IObservable<Unit> Jump => _jump;
    }
}
