using System;
using UniRx;
using UnityEngine;
using GameManagers;

namespace Players
{
    [RequireComponent(typeof(PlayerCore))]
    public class PlayerMainGameEndEventProvider : MonoBehaviour, IMainGameEndEventProvider
    {
        [SerializeField] private PlayerCore _playerCore;

        public IObservable<Unit> MainGameEnd =>
            _playerCore.IsCrossedGoal
                .Where(isCrossed => isCrossed)
                .Select(_ => Unit.Default);
    }
}
