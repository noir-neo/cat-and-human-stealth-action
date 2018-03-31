using System;
using UniRx;

namespace GameManagers
{
    public interface IMainGameStartEventProvider {
        IObservable<Unit> MainGameStart { get; }
    }
}
