using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using SA.Managers.Events;
using UnityEngine;

public class PlatformInteraction : MonoBehaviour
{
    private PlayerController playerController;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        GameManager.Instance.EventManager.Register(EventTypes.Platformactivated, ReactToEvent);
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
        if (CanEffect(effect.characterType))
        {
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
                case PlatformType.Lava:
                    DirectDamage(effect);
                    break;
                case PlatformType.Flyup:
                    FlyForDuration(1);
                    break;
                case PlatformType.Fall:
                    FallDown(effect);
                    break;
                case PlatformType.Spike:
                    GiantInstantDead(effect);
                    break;
            }
        }
        playerController.CheckHP();
    }

    void FallDown(PlatformTypeArgs effect)
    {
        if (playerController.characterType == CharacterType.Minion)
        {
            playerController.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            playerController.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX |
                                                                     RigidbodyConstraints.FreezePositionZ |
                                                                     RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            playerController.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }
    }

    void FlyForDuration(float duration)
    {
        transform.DOMoveY(transform.position.y + 8, duration);
    }

    void GiantInstantDead(PlatformTypeArgs effect)
    {
        playerController.minioncount--;
        if (playerController.characterType == CharacterType.Minion)
        {
            effect.effectedGameObject.GetComponent<MinionController>().Die();
        }
        else
        {
            playerController.minioncount -= playerController.minioncount;
            GameManager.Instance.playerController.Scale(CharacterType.Giant);
            playerController.Die();
        }
    }

    void DirectDamage(PlatformTypeArgs effect)
    {
        playerController.minioncount--;
        if (playerController.characterType == CharacterType.Minion)
        {
            effect.effectedGameObject.GetComponent<MinionController>().Die();
        }
        else
        {
            playerController.minioncount = playerController.minioncount / 2;
            GameManager.Instance.playerController.Scale(CharacterType.Giant);
        }
    }
}