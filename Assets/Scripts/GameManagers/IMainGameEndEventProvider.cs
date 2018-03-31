using System;
using UniRx;

namespace GameManagers
{
    public interface IMainGameEndEventProvider {
        IObservable<Unit> MainGameEnd { get; }
    }
}
