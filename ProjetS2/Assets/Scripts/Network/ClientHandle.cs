using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Network
{
    public class ClientHandle
    {

        public static void ClientActions(Packet p, IdMsg id)
        {
            switch(id)
            {
                default:
                    Welcome(p);
                    break;
            }
        }
        public static void Welcome(Packet _packet)
        {
            string _msg = _packet.ReadString();
            int _myId = _packet.ReadInt();
            Client.isConnected = true;
            Client.instance.myId = _myId;
        }
    }
}
