
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
        public static void ChangeCharacterType()
        {
            GameManager.Instance.EventManager.InvokeEvent(EventTypes.ChangeCharacter);
        }
        public static void EarnCurrency( float amount)
        {
            GameManager.Instance.EventManager.InvokeEvent(EventTypes.CurrencyEarned, new CurrencyArgs( amount));
        }
        public static void PlatformEffect(PlatformType platformType,GameObject effectedGameObject,CharacterType characterType)
        {
            GameManager.Instance.EventManager.InvokeEvent(EventTypes.Platformactivated, new PlatformTypeArgs(platformType, effectedGameObject,characterType));
        }

      
    
    }
}

