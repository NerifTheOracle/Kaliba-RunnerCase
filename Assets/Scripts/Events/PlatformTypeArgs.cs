using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA.Managers.Events
{
    public class PlatformTypeArgs : EventArgs
    {
        public PlatformType platformType;
        public GameObject effectedGameObject;
        public CharacterType characterType;

        public PlatformTypeArgs(PlatformType platform, GameObject go,CharacterType character)
        {
            this.platformType = platform;
            this.effectedGameObject = go;
            this.characterType = character;
        }
    }
}
