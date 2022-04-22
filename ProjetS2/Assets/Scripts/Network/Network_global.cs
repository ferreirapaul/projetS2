using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Network
{
    public class Network_global : MonoBehaviour
    {
        public static Client instance;
        private void Start()
        {
            instance = new Client(instance);
        }

        private static void SendString(string msg, IdMsg id)
        {
            ClientSend.SendString(msg, id);
        }

    }

    
}