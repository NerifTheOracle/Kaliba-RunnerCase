using System;
using System.Collections;
using System.Collections.Generic;
using SA.Managers.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
 private EventManager eventManager;
 public EventManager EventManager { get => eventManager; }

 public PlayerController playerController;

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
  SceneManager.LoadScene(SceneManager.GetActiveScene().name);
 }
 public void LevelFailed()
 {
  EventRunner.LevelFail();
 }
 public void LevelSuccessful()
 {
  PlayerPrefs.SetInt("Level",PlayerPrefs.GetInt("Level")+1);
  Debug.Log(PlayerPrefs.GetInt("Level"));
  RestartGame();
 }
}
