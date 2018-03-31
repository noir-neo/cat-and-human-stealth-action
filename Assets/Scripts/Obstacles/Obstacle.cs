using UnityEngine;

namespace Obstacles
{
    public class Obstacle : MonoBehaviour, IObstacle
    {
        [SerializeField] private GameObject _jumpTarget;
        public GameObject JumpTarget => _jumpTarget;
    }
}
