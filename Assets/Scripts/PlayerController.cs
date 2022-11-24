﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public AnimationController AnimationController;
    [HideInInspector]public List<GameObject> Minions;
    public GameObject GiantModel;
    public int minioncount=2;
    [SerializeField] public CharacterType characterType;

    private void Start()
    {
        GameManager.Instance.playerController = this;
        GameManager.Instance.EventManager.Register(EventTypes.ChangeCharacter,SwitchType);
        AnimationController = GetComponent<AnimationController>();
        ChangeToGiant();
    }

    public void SwitchType(EventArgs args)
    {
        switch (characterType)
        {
            case CharacterType.Giant:
                characterType = CharacterType.Minion;
                ChangeToMinion();
                AnimationController.SetAnimation(1);
                break;
            case CharacterType.Minion:
                characterType = CharacterType.Giant;
                ChangeToGiant();
                AnimationController.SetAnimation(1);
                break;
        }
    }

    void ChangeToGiant()
    {
        transform.DOScale(transform.localScale * minioncount/6f, 0.3f).SetEase(Ease.OutBounce).OnComplete(()=>FixFinalScale(Vector3.one * minioncount/6f));
        GiantModel.SetActive(true);
        RemoveMinions();
    }

    public void LoseBlob()
    {
        
        if (characterType == CharacterType.Giant)
        {
            transform.DOScale(transform.localScale * minioncount/6f, 0.3f).OnComplete(()=>FixFinalScale(Vector3.one * minioncount/6f));
        }
    }
    void FixFinalScale(Vector3 finalScale)
    {
        transform.localScale = finalScale;
    }

    void ChangeToMinion()
    {
        Minions = new List<GameObject>();
        for (int i = 0; i < minioncount; i++)
        {
            GameObject go =  ObjectPool.Instance.GetObjFromPool(RandomCircle(transform.position, Random.Range(1,3), i));
            go.transform.parent = transform;
            go.transform.position = new Vector3(go.transform.position.x,0,go.transform.position.z);
            Minions.Add(go);
        }
        GiantModel.SetActive(false);
        transform.DOScale(1, 0.3f).SetEase(Ease.InBounce).OnComplete(()=>FixFinalScale(Vector3.one));
    }

    void RemoveMinions()
    {
        for (int i = 0; i < Minions.Count; i++)
        {
            Minions[i].gameObject.SetActive(false);
        }
        Minions.Clear();
        Minions.TrimExcess();
    }

    Vector3 RandomCircle(Vector3 center, float radius,int a)
    {
        float ang = 360 / minioncount * a;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);;
        return pos;
    }
    
}

