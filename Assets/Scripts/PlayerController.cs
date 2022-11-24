using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using SA.Managers.Events;
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
        GameManager.Instance.EventManager.Register(EventTypes.Addblobs,AddBlobs);
        GameManager.Instance.EventManager.Register(EventTypes.AddBlob,AddBlob);
        AnimationController = GetComponent<AnimationController>();
        ChangeToGiant();
    }

    void AddBlobs(EventArgs args)
    {
        var addblobamount = args as IntArgs;
        for (int i = 0; i < addblobamount.value; i++)
        {
            GameObject go =  ObjectPool.Instance.GetObjFromPool(transform.position, Random.Range(2,5), i,minioncount);
            go.transform.parent = transform;
            go.transform.position = new Vector3(go.transform.position.x,0,go.transform.position.z);
            Minions.Add(go);
        }
    }
    void AddBlob(EventArgs args)
    {
        minioncount++;
        if (characterType == CharacterType.Minion)
        {
            GameObject go =  ObjectPool.Instance.GetObjFromPool(transform.position, Random.Range(2,5), 1,minioncount);
            go.transform.parent = transform; 
            go.transform.position = new Vector3(go.transform.position.x,0,go.transform.position.z); 
            Minions.Add(go);
            AnimationController.SetAnimation(1);
        }
        Scale(characterType);
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
        Scale(CharacterType.Giant);
        GiantModel.SetActive(true);
        RemoveMinions();
    }

    
    void FixFinalScale(Vector3 finalScale)
    {
        transform.localScale = finalScale;
    }

    void ChangeToMinion()
    {
        Minions = new List<GameObject>();
        EventRunner.AddBlobs(minioncount);
        GiantModel.SetActive(false);
       Scale(CharacterType.Minion);
    }

    public void Scale(CharacterType ct)
    {
        switch (ct)
        {
            case CharacterType.Giant:
                transform.DOScale(Vector3.one+Vector3.one * (minioncount*0.1f), 0.3f).SetEase(Ease.OutBounce).OnComplete(()=>FixFinalScale(Vector3.one+Vector3.one * (minioncount*0.1f)));
                break;
            case CharacterType.Minion:
                transform.DOScale(1, 0.3f).SetEase(Ease.InBounce).OnComplete(()=>FixFinalScale(Vector3.one));
                for (int i = 0; i < Minions.Count; i++)
                {
                    Minions[i].transform.localScale =Vector3.one/2;
                }
                break;
        }
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

   
    
}

