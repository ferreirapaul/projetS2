using System;

namespace Server
{
    public class ServerHandle
    {
        public static void ServerActions(Packet p, IdMsg id, int clientId)
        {
            switch (id)
            {
                case IdMsg.createLobby:
                    Console.WriteLine(clientId + ":" + p.ReadString());
                    break;
                default:
                    break;
            }
        }
    }
}