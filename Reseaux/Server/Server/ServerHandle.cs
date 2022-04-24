using System;

namespace Server
{
    public class ServerHandle
    {
        public static void ServerActions(Packet p, IdMsg id)
        {
            switch (id)
            {
                case IdMsg.createLobby:
                    Console.WriteLine(p.ReadString());
                    break;
                default:
                    break;
            }
        }
    }
}