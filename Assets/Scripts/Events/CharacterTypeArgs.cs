using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTypeArgs : MonoBehaviour
{
    public CharacterType characterType;
    public CharacterTypeArgs(CharacterType tempcharacterTypes)
    {
        SelectType(tempcharacterTypes);
    }

    CharacterType SelectType(CharacterType tempcharacterTypes)
    {
        characterType = tempcharacterTypes;
        return tempcharacterTypes;
    }
}
