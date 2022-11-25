using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
   [SerializeField] private GameObject[] Levels;

   private void Start()
   {
      int currentlvl = PlayerPrefs.GetInt("Level");
      if (currentlvl > Levels.Length-1)
      {
         var rnd = Random.Range(0, Levels.Length);
         Levels[rnd].SetActive(true);
      }
      else
      {
         Levels[currentlvl].SetActive(true);
      }
   }
}
