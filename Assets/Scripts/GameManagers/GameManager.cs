using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Zenject;

namespace GameManagers
{
    public class GameManager : MonoBehaviour
    {
        [Inject]
        public void Initialize(
            List<IMainGameStartEventProvider> mainGameStartEventProviders,
            List<IMainGameEndEventProvider> mainGameEndEventProviders,
            List<IMainGameStartObserver> mainGameStartObserver,
            List<IMainGameEndObserver> mainGameEndObserver
            )
        {
            mainGameStartEventProviders
                .Select(provider => provider.MainGameStart)
                .Merge()
                .Subscribe(_ =>
                {
                    foreach (var observer in mainGameStartObserver)
                    {
                        observer.MainGameStart();
                    }
                })
                .AddTo(this);

            mainGameEndEventProviders
                .Select(provider => provider.MainGameOver)
                .Merge()
                .Subscribe(x =>
                {
                    foreach (var observer in mainGameEndObserver)
                    {
                        observer.MainGameEnd(x);
                    }
                })
                .AddTo(this);
        }
    }
}
