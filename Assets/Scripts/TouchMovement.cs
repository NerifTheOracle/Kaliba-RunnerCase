using System;
using System.Collections;
using System.Collections.Generic;
using SA.Managers.Events;
using UnityEngine;

public class TouchMovement : MonoBehaviour
{
    [SerializeField] private MovementScriptable _movementScriptable;
    private float maxDisplacement = 0.01f;
    private Vector2 anchorPosition;
    private Vector2 anchorUpPosition;
    private bool checkTouch;
    private float cd;
    [SerializeField] private PlayerController _playerController;

    private void Start()
    {
        GameManager.Instance.EventManager.Register(EventTypes.LevelStart,StartTouch);
        GameManager.Instance.EventManager.Register(EventTypes.LevelFail,StopTouch);
        GameManager.Instance.EventManager.Register(EventTypes.LevelSuccess,StopTouch);
        GameManager.Instance.EventManager.Register(EventTypes.LevelRestart,StopTouch);
    }

    void StartTouch(EventArgs args)
    {
        checkTouch = true;
    }
    void StopTouch(EventArgs args)
    {
        checkTouch = false;
    }

    private void CheckTouch()
    {
        if (checkTouch)
        {
            var inputX = GetInput();

            var displacementX = GetDisplacement(inputX);

            displacementX = SmoothOutDisplacement(displacementX)*_movementScriptable.slideSpeed;

            var newPosition = GetNewLocalPosition(displacementX);

            newPosition = GetLimitedLocalPosition(newPosition);

            _playerController.transform.localPosition = newPosition;
            MoveForward();
        }
       
    }
    private void Update()
    {
       CheckTouch();
       cd -= Time.deltaTime;
    }

    void MoveForward()
    {
        var step =  _movementScriptable.runSpeed * Time.deltaTime; // calculate distance to move
        _playerController.transform.position = Vector3.MoveTowards(  _playerController.transform.position,   _playerController.transform.position+new Vector3(0,0,1), step);
       
    }
    void DetectTap()
    {

        if (VerticalMoveValue() < _movementScriptable.SWIPE_THRESHOLD && HorizontalMoveValue() < _movementScriptable.SWIPE_THRESHOLD && cd >0)
        {
            EventRunner.ChangeCharacterType();
        }
       
    }
    private Vector3 GetLimitedLocalPosition(Vector3 position)
    {
        position.x = Mathf.Clamp(position.x, -_movementScriptable.SlideRange, _movementScriptable.SlideRange);
        return position;
    }

    private Vector3 GetNewLocalPosition(float displacementX)
    {
        var lastPosition =  _playerController.transform.localPosition;
        var newPositionX = lastPosition.x + displacementX;
        var newPosition = new Vector3(newPositionX, lastPosition.y, lastPosition.z);
        return newPosition;
    }

    private float GetInput()
    {
        var inputX = 0f;
        if (Input.GetMouseButtonDown(0))
        {
            anchorPosition = Input.mousePosition;
            cd = 0.2f;
        }

        else if (Input.GetMouseButton(0))
        {
            inputX = (Input.mousePosition.x - anchorPosition.x);
            anchorPosition = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            anchorUpPosition =Input.mousePosition;
            DetectTap();
        }

        return inputX;
    }
    float VerticalMoveValue()
    {
        return Mathf.Abs(anchorPosition.y - anchorUpPosition.y);
    }

    float HorizontalMoveValue()
    {
        return Mathf.Abs(anchorPosition.x - anchorUpPosition.x);
    }

    private float GetDisplacement(float inputX)
    {
        var displacementX = 0f;
        displacementX = inputX * Time.deltaTime;
        return displacementX;
    }

    private float SmoothOutDisplacement(float displacementX)
    {
        return Mathf.Clamp(displacementX, -maxDisplacement , maxDisplacement);
    }
    
}
