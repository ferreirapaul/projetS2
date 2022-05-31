using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Game : MonoBehaviour
    {
        public LobbyInfos lobbby;
        public GenMapScript map;

        void Start()
        {
            map.Generate(lobbby.Seed);
            lobbby = (LobbyInfos) GameObject.FindObjectOfType(typeof(LobbyInfos));
        }

        
    }
}
