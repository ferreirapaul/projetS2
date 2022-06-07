using System.Collections.Generic;
using Ressources;
using Building;
using UnityEngine;

namespace Technology
{
    public class ArmyC : Technology
    {
        public Game.Game game;
        public ArmyC(List<Ressources.Ressources> r, List<Building.Building> b, List<Army.Army> a, Game.Game g)
            : base(r, b, a)
        {
            this.game = g;
            coast = 10;
            name = "Army";
            description = "This technology gives access to the army camp and allow to produce sword man. \n";
        }

        public override void Unlock()
        {
            this.availableBuildings.Add(new ArmyCamp((Gold) this.ressources[0],(Food) this.ressources[1], game));
            isUnlock = true;
        }

        public override void Effects()
        {
            
        }

        public override void upgradePeriod()
        {
            
        }
    }
}