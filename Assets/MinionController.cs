using System;
using System.Collections;
using System.Collections.Generic;
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

    private void OnEnable()
    {
        OpenRandomEmote();
    }

    void OpenRandomEmote()
    {
        Emotes[Random.Range(0,Emotes.Length)].SetActive(true);
    }
}
