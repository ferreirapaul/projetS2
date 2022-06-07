using System;
using System.Collections.Generic;
using System.ComponentModel;
using Server;

namespace Lobby
{
    public class Lobby
    {
        public int IdSession;
        public int Seed;
        public Dictionary<int, Client> players;
        private List<int> clientsId;
        public int i;
        public int chooseWait;

        public Lobby(List<string> value, Client creator)
        {
            clientsId = new List<int>();
            clientsId.Add(creator.Id);
            i = 0;
            creator.name = value[0];
            creator.emperor = Int32.Parse(value[1]);
            creator.idlobby = Int32.Parse(value[3]);
            this.Seed = Int32.Parse(value[2]);
            this.IdSession = Int32.Parse(value[3]);
            
            this.players = new Dictionary<int, Client>();
            this.players.Add(creator.Id,creator);
        }

        public void AddPlayer(List<string> value, Client player)
        {
            player.name = value[0];
            player.emperor = Int32.Parse(value[1]);
            clientsId.Add(player.Id);
            Send.SendEveryoneExcept(player.Id,IdMsg.newPlayer, value[0]+ ";" + value[1]+ ";" + player.Id + ";");

            string res = this.Seed + ";";
            foreach (int i in players.Keys)
            {
                res += players[i].name + ";";
                res += players[i].emperor + ";";
                res += players[i].Id + ";";
            }
            this.players.Add(player.Id,player);
            
            Send.SendDataClient(player.Id,IdMsg.sendInfo,res);
        }

        public void EndTurn(string val, int clientId)
        {
            Send.SendEveryoneExcept(clientId,IdMsg.endTurn,val);
            i = (i + 1) % players.Count;
            Send.SendDataClient(clientsId[i],IdMsg.youTurn,"go go power rangers tutututu");
        }

        public void Win(int clientId)
        {
            Send.SendEveryoneExcept(clientId,IdMsg.winGame,"you loose eheheheheh"); 
        }

        public void Choose()
        {
            chooseWait++;
            if (chooseWait >= players.Count)
            {
                Send.SendDataClient(clientsId[i],IdMsg.youTurn,"go go power rangers tutututu");
            }
        }
    }
}