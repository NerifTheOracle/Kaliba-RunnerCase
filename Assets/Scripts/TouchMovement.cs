using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : MonoBehaviour
{
    [SerializeField] private MovementScriptable _movementScriptable;
    private float maxDisplacement = 0.01f;
    private Vector2 anchorPosition;
    private Vector2 anchorUpPosition;
    
    [SerializeField] private PlayerController _playerController;
    
    private void Update()
    {
        var inputX = GetInput();

        var displacementX = GetDisplacement(inputX);

        displacementX = SmoothOutDisplacement(displacementX)*_movementScriptable.slideSpeed;

        var newPosition = GetNewLocalPosition(displacementX);

        newPosition = GetLimitedLocalPosition(newPosition);

        _playerController.transform.localPosition = newPosition;
        MoveForward();
    }

    void MoveForward()
    {
        var step =  _movementScriptable.runSpeed * Time.deltaTime; // calculate distance to move
        _playerController.transform.position = Vector3.MoveTowards(  _playerController.transform.position,   _playerController.transform.position+new Vector3(0,0,1), step);
       
    }
    void DetectTap()
    {

        if (VerticalMoveValue() > _movementScriptable.SWIPE_THRESHOLD && VerticalMoveValue() > HorizontalMoveValue())
        {
            

        }
        else if (HorizontalMoveValue() > _movementScriptable.SWIPE_THRESHOLD && HorizontalMoveValue() > VerticalMoveValue())
        {
           
        }
        else
        {
            Debug.Log("Its Tap");
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
