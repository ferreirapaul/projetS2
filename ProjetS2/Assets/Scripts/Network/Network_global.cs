using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Network
{
    public class Network_global : MonoBehaviour
    {
        public Client Client;

        public void SendString(string msg, IdMsg id)
        {
            if (Client.isConnected)
            {
                ClientSend.SendString(msg, id);
            }
            else
            {
                Debug.Log("Not Connected");
            }
        }

    }

    
}