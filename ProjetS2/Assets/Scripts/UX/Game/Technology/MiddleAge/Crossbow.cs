using System.Collections.Generic;
using Army;

namespace Technology
{
    public class Crossbow : Technology
    {
        public Crossbow(List<Ressources.Ressources> r, List<Building.Building> b, List<Army.Army> a)
            : base(r, b,a)
        {
            coast = 17;
            name = "Crossbow";
            description = "This technology gives you access to the crossbow soldier.";
        }

        public override void Unlock()
        {
            isUnlock = true;
            this.availableArmy.Add(new Crossbowman());
        }

        public override void Effects()
        {
            
        }

        public override void upgradePeriod()
        {
            
        }
    }
}