using System.Collections.Generic;
using Ressources;

namespace Technology
{
    public class Market : Technology
    {
        public Market(List<Ressources.Ressources> r, List<Building.Building> b, List<Army> a)
            : base(r, b, a)
        {
            coast = 13;
            name = "Market";
            description = "This technology gives access to the market building.";
        }

        public override void Unlock()
        {
            this.availableBuildings.Add(new Building.Market((Gold) this.ressources[0]));
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