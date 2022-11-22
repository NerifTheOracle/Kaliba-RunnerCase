using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovementData", menuName = "ScriptableObjects/MovementScriptable", order = 1)]
public class MovementScriptable : ScriptableObject
{
    public float runSpeed;
    public float slideSpeed;
    public float SlideRange = 2f;
    public float SWIPE_THRESHOLD = 20f;
    
}
