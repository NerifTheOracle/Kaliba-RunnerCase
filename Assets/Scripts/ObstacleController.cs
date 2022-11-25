using System;
using System.Collections;
using System.Collections.Generic;
using SA.Managers.Events;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObstacleController : MonoBehaviour
{
    [SerializeField] private PlatformType platformType;
    [SerializeField] private CharacterType characterType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blob"))
        {
           EventRunner.PlatformEffect(platformType,other.gameObject,characterType);
        }
    }
}
