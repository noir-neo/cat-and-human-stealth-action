using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using EventTriggers;
using EventType = EventTriggers.EventType;
using Obstacles;

namespace Players
{
    [RequireComponent(typeof(PlayerCore))]
    public class ObstacleDetector : MonoBehaviour
    {
        [SerializeField] private PlayerCore _playerCore;

        private void OnTriggerEnter(Collider collider)
        {
            var gameObject = collider.gameObject;
            var trigger = gameObject.GetComponent<IEventTrigger>();
            if (trigger == null)
            {
                return;
            }

            switch (trigger.EventType)
            {
                case EventType.Goal:
                    _playerCore.Goal();
                    break;
                case EventType.Obstacle:
                    var obstacle = gameObject.GetComponent<IObstacle>();
                    var target = obstacle.JumpTarget.transform.position;
                    _playerCore.JumpTo(target);
                    break;
            }
        }
    }
}
