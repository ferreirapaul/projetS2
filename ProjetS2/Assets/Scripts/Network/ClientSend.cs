using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace client
{
    public class ClientSend : MonoBehaviour
    {
        private static void SendTCPData(Packet _packet)
        {
            _packet.Write(_packet.buffer.Count);
            Client.instance.SendData(_packet);
        }
    }
}