using System;
using UnityEngine;

namespace Players
{
    public interface IInputEventProvider
    {
        IObservable<float> MoveDirection { get; }
    }
}