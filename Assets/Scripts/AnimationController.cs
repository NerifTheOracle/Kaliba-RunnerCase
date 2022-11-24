using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
  private PlayerController _playerController;
  
  private void Start()
  {
    _playerController = GetComponent<PlayerController>();
    GameManager.Instance.EventManager.Register(EventTypes.LevelStart,GameStart);
    GameManager.Instance.EventManager.Register(EventTypes.LevelSuccess,GameWin);
  }

  void GameStart(EventArgs args)
  { SetAnimation(1); }
  void GameWin(EventArgs args)
  { SetAnimation(3); }
  public void SetAnimation(int animindex)
  {
    for (int i = 0; i < _playerController.Minions.Count; i++)
    {
      _playerController.Minions[i].GetComponent<Animator>().SetFloat("AnimIndex",animindex);
    }
    _playerController.GiantModel.GetComponent<Animator>().SetFloat("AnimIndex",animindex);
  }

  public void Dies(Animator animator)
  {
    animator.SetTrigger("Dies");
  }
}
