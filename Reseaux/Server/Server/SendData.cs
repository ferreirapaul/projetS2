namespace Server
{
    public static class SendData
    {
        public static void SendAll(IdMsg id, string msg)
        {
            Packet p = new Packet(id);
            p.Write(msg);
            foreach (Client i in Server.clients)
            {
                i.SendData(p);
            }
        }

        public static void SendDataClient(int idClient, IdMsg idMsg, string msg)
        {
            Packet p = new Packet(idMsg);
            p.Write(msg);
            Server.clients[idClient].SendData(p);
        }
    }
}