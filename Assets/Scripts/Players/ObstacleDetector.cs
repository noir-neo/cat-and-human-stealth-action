using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System;
using EventTriggers;
using EventType = EventTriggers.EventType;

namespace Players
{
    [RequireComponent(typeof(PlayerCore))]
    public class ObstacleDetector : MonoBehaviour
    {
        [SerializeField] private PlayerCore _playerCore;

        private void OnTriggerEnter(Collider collider)
        {
            var obstacle = collider.gameObject.GetComponent<IEventTrigger>();
            if (obstacle == null)
            {
                return;
            }

            switch (obstacle.EventType)
            {
                case EventType.Goal:
                    _playerCore.Goal();
                    break;
            }
        }
    }
}
