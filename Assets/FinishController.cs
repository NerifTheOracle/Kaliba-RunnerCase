using System;
using System.Collections;
using System.Collections.Generic;
using SA.Managers.Events;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blob"))
        {
            EventRunner.LevelSuccess();
        }
       
    }
}
