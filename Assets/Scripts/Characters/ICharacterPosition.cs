using System;
using UnityEngine;

namespace Characters
{
    public interface ICharacterPosition
    {
        IObservable<Vector3> Position { get; }
    }
}
