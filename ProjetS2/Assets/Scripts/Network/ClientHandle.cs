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
                    client.lobby.getinfosValues = GetValues(msg);
                    client.lobby.isGetInfo = true;
                    break;
                case IdMsg.launchGame:
                    client.lobby.StartGame();
                    break;
                case IdMsg.endTurn:
                    msg = p.ReadString();
                    client.game.DecryptTurn(GetValues(msg));
                    break;
                case IdMsg.youTurn:
                    client.game.youTurn = true;
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
