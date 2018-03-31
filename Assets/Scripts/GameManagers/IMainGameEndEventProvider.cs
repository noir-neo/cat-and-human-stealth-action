using System;
using UniRx;

namespace GameManagers
{
    public interface IMainGameEndEventProvider {
        IObservable<bool> MainGameOver { get; }
    }
}
