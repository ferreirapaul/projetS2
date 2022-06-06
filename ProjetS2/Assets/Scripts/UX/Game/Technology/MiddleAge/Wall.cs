using System.Collections.Generic;
using Game;
using UnityEngine;
using UnityEngine.Android;

namespace Technology
{
    public class Wall : Technology
    {
        public int gain;
        public Game.Game game;
        public Wall(List<Ressources.Ressources> r, List<Building.Building> b, List<Army.Army> a, Game.Game g)
            : base(r, b, a)
        {
            this.game = g;
            coast = 30;
            gain = 1000;
            name = "Wall";
            description = "This technology upgrade your city health. \n" +
                          "When upgraded it continue its upgrade";
        }

        public override void Unlock()
        {
            isUnlock = true;
            foreach (Game.City i in this.game.citiesOwn)
            {
                i.Health += gain;
            }
        }

        public override void Effects()
        {
            
        }

        public override void upgradePeriod()
        {
            foreach (Game.City i in this.game.citiesOwn)
            {
                i.Health += gain;
            }
        }
    }
}