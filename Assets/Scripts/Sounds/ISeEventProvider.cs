using System;

namespace Sounds
{
    public interface ISeEventProvider
    {
        IObservable<string> PlaySeTriggerAsObservable();
    }
}
