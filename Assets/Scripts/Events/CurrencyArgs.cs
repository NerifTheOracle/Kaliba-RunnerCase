using System.Collections;
using System;

namespace SA.Managers.Events
{
    public class CurrencyArgs : EventArgs
    {
        public int currencyId;
        public float changeAmount;

        public CurrencyArgs(int currencyId, float changeAmount)
        {
            this.currencyId = currencyId;
            this.changeAmount = changeAmount;
        }
    }
}

