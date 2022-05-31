using System.Collections.Generic;
using Ressources;

namespace Technology
{
    public class Forge : Technology
    {
        public Forge(List<Ressources.Ressources> r, List<Building.Building> b, List<Army> a)
            : base(r, b, a)
        {
            coast = 10;
            name = "Forge";
            description = "This technology gives access to the forge building.";
        }

        public override void Unlock()
        {
            isUnlock = true;
            this.availableBuildings.Add(new Building.Forge((ProductionPoints) this.ressources[3]));
        }

        public override void Effects()
        {
            
        }

        public override void upgradePeriod()
        {
            
        }
    }
}