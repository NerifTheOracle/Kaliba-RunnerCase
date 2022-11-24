using System;
using System.Collections;
using System.Collections.Generic;
using SA.Managers.Events;
using UnityEngine;


public class PlatformInteraction : MonoBehaviour
{

    private PlayerController playerController;
    void Start()
    {
        playerController = GetComponent<PlayerController>();
       GameManager.Instance.EventManager.Register(EventTypes.Platformactivated,ReactToEvent);
    }

    bool CanEffect(CharacterType refType)
    {
        if (playerController.characterType == refType || refType == CharacterType.Both)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void ReactToEvent(EventArgs args)
    {
        var effect = args as PlatformTypeArgs;

        switch (effect.platformType)
        {
            case PlatformType.Knife:
                DirectDamage(effect);
                break;
            case PlatformType.Hammer:
                DirectDamage(effect);
                break;
            case PlatformType.Saw:
                DirectDamage(effect);
                break;
        }
    }

    void DirectDamage(PlatformTypeArgs effect)
    {
        playerController.minioncount--;
        if ( CanEffect(effect.characterType))
        {
            if (playerController.characterType==CharacterType.Minion)
            {
                effect.effectedGameObject.GetComponent<MinionController>().Die();
            }
            else
            {
                GameManager.Instance.playerController.LoseBlob();
            }
        }
    }
}
