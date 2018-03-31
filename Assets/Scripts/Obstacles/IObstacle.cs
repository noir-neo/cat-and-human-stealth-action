using UnityEngine;

namespace Obstacles
{
    public interface IObstacle
    {
        GameObject JumpTarget { get; }
    }
}
