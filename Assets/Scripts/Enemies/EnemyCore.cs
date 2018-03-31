using System;
using Characters;
using UniRx;
using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof(CharacterCore))]
    public class EnemyCore : MonoBehaviour
    {
        [SerializeField] private CharacterCore _characterCore;

        readonly ISubject<Unit> _nudge = new Subject<Unit>();

        void Start()
        {
            _characterCore.Direction = Vector2.up;
        }

        public void UpdateDirection(Vector2 direction)
        {
            _characterCore.Direction = direction;
        }

        public void OnNudge()
        {
            _nudge.OnNext(Unit.Default);
        }

        public IObservable<Unit> NudgeAsObservable()
        {
            return _nudge;
        }
    }
}
