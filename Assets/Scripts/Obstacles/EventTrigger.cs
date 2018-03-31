using UnityEngine;

namespace EventTriggers
{
    public class EventTrigger: MonoBehaviour, IEventTrigger
    {
        [SerializeField] private EventType _eventType;
        public EventType EventType => _eventType;
    }
}
