using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePooler : MonoBehaviour
{
   private void OnDisable()
   {
      ParticlePool.Instance.ReturnObjToPool(gameObject);
   }
}
