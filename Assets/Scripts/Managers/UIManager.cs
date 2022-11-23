using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject StartPanel;
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject LosePanel;
    [SerializeField] private GameObject MainPanel;
    [Header("MENU ITEMS")] public Text leveltext;

    private void Start()
    {
        GameManager.Instance.EventManager.Register(EventTypes.LevelStart,GameStarted);
        GameManager.Instance.EventManager.Register(EventTypes.LevelSuccess,GameWin);
        GameManager.Instance.EventManager.Register(EventTypes.LevelFail,GameLose);
        GameManager.Instance.EventManager.Register(EventTypes.LevelRestart,GameRestarted);
        
    }

    void GameStarted(EventArgs args)
    {
        StartPanel.SetActive(false);
        MainPanel.SetActive(true);
    }
    void GameRestarted(EventArgs args)
    {
        StartPanel.SetActive(true);
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);
        MainPanel.SetActive(false);
    }
    void GameWin(EventArgs args)
    {
        WinPanel.SetActive(true);
        MainPanel.SetActive(false);
    }
    void GameLose(EventArgs args)
    {
        LosePanel.SetActive(true);
        MainPanel.SetActive(false);
    }
}
