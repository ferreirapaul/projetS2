using System;
using System.Collections.Generic;
using Server;

namespace Lobby
{
    public class Lobby
    {
        public int IdSession;
        public int Seed;
        public Dictionary<int, Client> players;

        public Lobby(List<string> value, Client creator)
        {
            creator.name = value[0];
            creator.emperor = Int32.Parse(value[1]);
            this.Seed = Int32.Parse(value[2]);
            this.IdSession = Int32.Parse(value[3]);
            
            this.players = new Dictionary<int, Client>();
            this.players.Add(creator.Id,creator);
        }

        public void AddPlayer(List<string> value, Client player)
        {
            player.name = value[0];
            player.emperor = Int32.Parse(value[1]);
            this.players.Add(player.Id,player);
            Send.SendEveryoneExcept(player.Id,IdMsg.newPlayer, value[0]+ ";" + value[1]+ ";" + player.Id + ";");

            string res = this.Seed + ";";
            foreach (int i in players.Keys)
            {
                res += players[i].name + ";";
                res += players[i].emperor + ";";
                res += players[i].Id + ";";
            }
            
            Send.SendDataClient(player.Id,IdMsg.sendInfo,res);
        }
    }
}