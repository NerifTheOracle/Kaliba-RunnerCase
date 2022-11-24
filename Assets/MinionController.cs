using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class MinionController : MonoBehaviour
{
    [SerializeField] private GameObject[] Emotes;
    private void OnDisable()
    {
        ObjectPool.Instance.ReturnObjToPool(gameObject);
    }

    void Start()
    {
       
    }

    public void Die()
    {
        transform.parent = null;
        GetComponent<Animator>().SetTrigger("Dies");
        DOVirtual.DelayedCall(0.3f, ()=> gameObject.SetActive(false));
    }
    private void OnEnable()
    {
        OpenRandomEmote();
    }

    void OpenRandomEmote()
    {
        Emotes[Random.Range(0,Emotes.Length)].SetActive(true);
    }
}
