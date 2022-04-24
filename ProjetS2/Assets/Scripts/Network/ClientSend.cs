using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Network
{
    public class ClientSend : MonoBehaviour
    {
        public static void SendString(string msg, IdMsg id)
        {
            Packet p = new Packet(id);
            p.Write(Client.instance.myId);
            p.Write(msg);
            Client.instance.SendClientData(p);
        }
    }
}