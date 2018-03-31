using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using Obstacles;

namespace Players
{
    [RequireComponent(typeof(PlayerCore))]
    public class ObstacleDetector : MonoBehaviour
    {
        [SerializeField] private PlayerCore _playerCore;

        private void OnTriggerEnter(Collider collider)
        {
            var obstacle = collider.gameObject.GetComponent<IObstacle>();
            if (obstacle == null)
            {
                return;
            }

            switch (obstacle.ObstacleType)
            {
                case ObstacleType.GOAL:
                    _playerCore.Goal();
                    break;
            }
        }
    }
}
