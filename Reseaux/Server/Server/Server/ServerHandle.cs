using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Lobby;

namespace Server
{
    public class ServerHandle
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
        
        public static void ServerActions(Packet p, IdMsg id, int clientId)
        {
            switch (id)
            {
                case IdMsg.createLobby:
                    Lobby.Lobby l = new Lobby.Lobby(GetValues(p.ToString()), Server.clients[clientId]);
                    Server.lobbys.Add(l.IdSession, l);
                    Server.countLobby++;
                    break;
                case IdMsg.joinLobby:
                    List<string> value = GetValues(p.ToString());
                    if (Server.lobbys.ContainsKey(Int32.Parse(value[2])))
                    {
                        Server.lobbys[Int32.Parse(value[2])].AddPlayer(value, Server.clients[clientId]);
                    }//return false
                    break;
                default:
                    Console.Error.WriteLine("Unknow Id");
                    break;
            }
        }
    }
}