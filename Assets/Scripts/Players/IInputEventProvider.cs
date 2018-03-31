using System;
using UnityEngine;

namespace Players
{
    public interface IInputEventProvider
    {
        IObservable<Vector2> MoveDirection { get; }
    }
}