namespace Server
{
    public static class Send
    {
        public static void SendAll(IdMsg id, string msg)
        {
            foreach (int i in Server.clients.Keys)
            {
                SendDataClient(i,id,msg);
            }
        }

        public static void SendDataClient(int idClient, IdMsg idMsg, string msg)
        {
            Packet p = new Packet(idMsg);
            p.Write(msg);
            Server.clients[idClient].SendData(p);
        }
        
        public static void SendEveryoneExcept(int idBadMan, IdMsg idMsg, string msg)
        {
            foreach (int i in Server.clients.Keys)
            {
                if (i != idBadMan)
                {
                    SendDataClient(i, idMsg, msg);
                }
            }
        }
        
        public static void SendWelcome(int idClient)
        {
            Packet p = new Packet(IdMsg.welcome);
            p.Write("Welcome connexion succedeed !");
            p.Write(idClient);
            Server.clients[idClient].SendData(p);
        }
    }
}