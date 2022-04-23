using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Network
{
    public class Network_global : MonoBehaviour
    {
        public GameObject Client;
        private void Start()
        {
            Instantiate(Client);
        }

        public static void SendString(string msg, IdMsg id)
        {
            ClientSend.SendString(msg, id);
        }

    }

    
}