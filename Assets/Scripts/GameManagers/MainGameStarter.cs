using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Zenject;
using System;

namespace GameManagers
{
    public class MainGameStarter : MonoBehaviour, IMainGameStartEventProvider
    {
        private Subject<Unit> _mainGameStart = new Subject<Unit>();
        public IObservable<Unit> MainGameStart => _mainGameStart;

        void Start()
        {
            _mainGameStart.OnNext(Unit.Default);
        }
    }
}
