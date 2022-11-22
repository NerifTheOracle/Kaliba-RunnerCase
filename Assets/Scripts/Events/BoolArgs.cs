using System;

namespace SA.Managers.Events
{
    public class BoolArgs : EventArgs
    {
        public bool value;

        public BoolArgs(bool v)
        {
            this.value = v;
        }
    }
}

