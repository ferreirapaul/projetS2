using System.Collections.Generic;
using Game;
using UnityEngine;

namespace Technology
{
    public class Comunism : Technology
    {
        public GenMapScript genMapScript;
        public Game.Game game;
        public Comunism(List<Ressources.Ressources> r, List<Building.Building> b, List<Army.Army> a, GenMapScript genMapScript, Game.Game g)
            : base(r, b, a)
        {
            this.genMapScript = genMapScript;
            this.game = g;
            coast = 70;
            name = "Comunism";
            description = "This technology allow you hide yourself from the other player and to buff your army. \n" +
                          "But, you can't have this technology and the globalization.";
        }

        public override void Unlock()
        {
            isUnlock = true;
            string msg = "";
            foreach (City i in game.citiesOwn)
            {
                msg += i.ID + "-";
            }
            this.game.AddInfos(IdAction.UnlockCommunism, msg);
        }

        public override void Effects()
        {
            
        }

        public override void upgradePeriod()
        {
            
        }
    }
}