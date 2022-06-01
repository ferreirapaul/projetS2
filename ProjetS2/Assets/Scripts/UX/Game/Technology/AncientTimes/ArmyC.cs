using System.Collections.Generic;
using Ressources;
using Building;

namespace Technology
{
    public class ArmyC : Technology
    {
        public ArmyC(List<Ressources.Ressources> r, List<Building.Building> b, List<Army.Army> a)
            : base(r, b, a)
        {
            coast = 10;
            name = "Army";
            description = "This technology gives access to the army camp and allow to produce sword man. \n";
        }

        public override void Unlock()
        {
            this.availableBuildings.Add(new ArmyCamp((Gold) this.ressources[0],(Food) this.ressources[1]));
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