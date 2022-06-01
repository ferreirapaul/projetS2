using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Network
{
    public class ClientHandle
    {
        private Client client;
        
        public ClientHandle(Client c)
        {
            this.client = c;
        }
        
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

        public void ClientActions(Packet p, IdMsg id)
        {
            string msg;
            switch(id)
            {
                case IdMsg.newPlayer:
                    msg = p.ReadString();
                    client.lobby.Join(GetValues(msg));
                    break;
                case IdMsg.sendInfos:
                    msg = p.ReadString();
                    Debug.Log(msg);
                    client.lobby.getinfosValues = GetValues(msg);
                    client.lobby.isGetInfo = true;
                    break;
                case IdMsg.launchGame:
                    client.lobby.StartGame();
                    break;
                default:
                    Welcome(p);
                    break;
            }
        }
        public void Welcome(Packet _packet)
        {
            string _msg = _packet.ReadString();
            int _myId = _packet.ReadInt();
            client.isConnected = true;
            client.myId = _myId;
        }
    }
}
