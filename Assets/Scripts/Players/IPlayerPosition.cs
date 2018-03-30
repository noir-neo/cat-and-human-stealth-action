using System;
using UnityEngine;

namespace Players
{
    public interface IPlayerPosition
    {
        IObservable<Vector3> Position { get; }
    }
}
