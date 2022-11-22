
using UnityEngine;

namespace SA.Managers.Events
{
    public class EventRunner
    {
      
        public static void LevelStart()
        {
            GameManager.Instance.EventManager.InvokeEvent(EventTypes.LevelStart);
        }

        public static void LevelFail()
        {
            GameManager.Instance.EventManager.InvokeEvent(EventTypes.LevelFail);
        }

        public static void LevelSuccess()
        {
            GameManager.Instance.EventManager.InvokeEvent(EventTypes.LevelSuccess);
        }

        
        public static void LevelRestart()
        {
            GameManager.Instance.EventManager.InvokeEvent(EventTypes.LevelRestart);
        }
        
        public static void EarnCurrency(int currencyId, float amount)
        {
            GameManager.Instance.EventManager.InvokeEvent(EventTypes.CurrencyEarned, new CurrencyArgs(currencyId, amount));
        }

      
    
    }
}

