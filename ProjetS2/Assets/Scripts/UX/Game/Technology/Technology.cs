using System.Collections.Generic;
using Army;
using UnityEngine;

namespace Technology
{
    public abstract class Technology
    {
        public int coast;
        protected List<Ressources.Ressources> ressources; //0: gold, 1: food, 2: pop, 3: production point, 4: sicence
        protected List<Building.Building> availableBuildings;
        protected List<Army.Army> availableArmy;
        protected bool isUnlock;
        protected Game.Game game;
        public string name;
        public string description;

        public int Coast => this.coast;
        public string Name => this.name;
        public string Descripiton => this.description;

        public Technology(List<Ressources.Ressources> r, List<Building.Building> b, List<Army.Army> a)
        {
            isUnlock = false;
            this.ressources = r;
            this.availableBuildings = b;
        }

        public abstract void Unlock(); 

        public abstract void Effects();

        public abstract void upgradePeriod();
        
    }
}