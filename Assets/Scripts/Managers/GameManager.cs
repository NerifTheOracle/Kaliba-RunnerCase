using System;
using System.Collections;
using System.Collections.Generic;
using SA.Managers.Events;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
 private EventManager eventManager;
 public EventManager EventManager { get => eventManager; }

 public void Initialize()
 {
  eventManager = new EventManager();
  eventManager.Initialize();
 }

 private void Awake()
 {
  Initialize();
 }

 public void StartGame()
 {
  EventRunner.LevelStart();
 }
 public void RestartGame()
 {
  EventRunner.LevelRestart();
 }
 public void LevelFailed()
 {
  EventRunner.LevelFail();
 }
 public void LevelSuccessful()
 {
  EventRunner.LevelSuccess();
 }
}
