using System.Collections;
using System;

namespace SA.Managers.Events
{
    public class CurrencyArgs : EventArgs
    {
        public float changeAmount;

        public CurrencyArgs( float changeAmount)
        {
            this.changeAmount = changeAmount;
        }
    }
}

