using UnityEngine.Events;

namespace SA.Managers.Events
{
    public class EventHolder<T>
    {
        public UnityAction<T> OnEvent;

        public EventHolder()
        {

        }
    }
}

