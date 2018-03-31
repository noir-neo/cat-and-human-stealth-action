using UnityEngine;

namespace Obstacles
{
    public class Obstacle: MonoBehaviour, IObstacle
    {
        [SerializeField] private ObstacleType _obstacleType;
        public ObstacleType ObstacleType => _obstacleType;
    }
}
