using System;
using UnityEngine;
using UnityEngine.Events;

namespace SA.Managers.Events
{
    public class EventCallback
    {
        public EventTypes eventType;
        public UnityAction<EventArgs> callback;

        public EventCallback(EventTypes eventType, UnityAction<EventArgs> callback)
        {
            this.eventType = eventType;
            this.callback = callback;
        }
    }
}

