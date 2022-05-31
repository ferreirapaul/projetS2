using System.Collections.Generic;
using Ressources;

namespace Technology
{
    public class School : Technology
    {
        public School(List<Ressources.Ressources> r, List<Building.Building> b, List<Army> a)
            : base(r, b, a)
        {
            coast = 5;
            name = "School";
            description = "This technology gives access to education through the education building.";
        }

        public override void Unlock()
        {
            isUnlock = true;
            this.availableBuildings.Add(new Building.School((Sciences) this.ressources[4]));
        }

        public override void Effects()
        {
            
        }

        public override void upgradePeriod()
        {
            
        }
    }
}