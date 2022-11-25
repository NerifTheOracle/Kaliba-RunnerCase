using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
   [SerializeField] private CinemachineVirtualCamera[] VirtualCameras;

   private void Start()
   {
      GameManager.Instance.EventManager.Register(EventTypes.LevelStart,GameStarted);
   }
   void GameStarted(EventArgs args)
   {
      for (int i = 0; i < VirtualCameras.Length; i++)
      {
         VirtualCameras[i].gameObject.SetActive(false);
      }
      VirtualCameras[1].gameObject.SetActive(true);
   }
}
