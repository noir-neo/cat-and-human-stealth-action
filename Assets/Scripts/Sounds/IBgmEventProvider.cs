using System;

namespace Sounds
{
    public interface IBgmEventProvider
    {
        IObservable<string> PlayBgmTriggerAsObservable();
    }
}
