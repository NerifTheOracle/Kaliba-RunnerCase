using System.Collections;
using System;

namespace SA.Managers.Events
{
    public class CurrencyArgs : EventArgs
    {
        public int changeAmount;

        public CurrencyArgs( int changeAmount)
        {
            this.changeAmount = changeAmount;
        }
    }
}

