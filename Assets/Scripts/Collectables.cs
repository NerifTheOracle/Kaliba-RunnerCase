using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using SA.Managers.Events;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Collectables : MonoBehaviour
{
    [SerializeField] private CollectableType collectableType;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Blob"))
        {
            switch (collectableType)
            {
                case CollectableType.Gold:
                    EventRunner.EarnCurrency(10);
                    ParticlePool.Instance.GetObjFromPool(transform.position);
                    break;
                case CollectableType.Blob:
                    EventRunner.AddBlob();
                    break;
            }
           Destroy(gameObject);
        }
    }
}
