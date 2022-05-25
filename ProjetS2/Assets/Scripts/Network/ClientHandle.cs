using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Network
{
    public class ClientHandle
    {
        
        public static List<string> GetValues(string txt)
        {
            List<string> res = new List<string>();
            string temp ="";
            foreach (char c in txt)
            {
                if (c == ';')
                {
                    res.Add(temp);
                    temp = "";
                }
                else
                {
                    temp += c;
                }
            }

            return res;
        }

        public static void ClientActions(Packet p, IdMsg id)
        {
            string msg;
            switch(id)
            {
                case IdMsg.newPlayer:
                    msg = p.ReadString();
                    Client.instance.lobby.Join(GetValues(msg));
                    break;
                case IdMsg.sendInfos:
                    msg = p.ReadString();
                    Client.instance.lobby.GetInfos(GetValues(msg));
                    break;
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
