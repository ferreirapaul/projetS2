using System.Collections.Generic;
using Army;

namespace Technology
{
    public class Bow : Technology
    {
        public Bow(List<Ressources.Ressources> r, List<Building.Building> b, List<Army.Army> a)
            : base(r, b, a)
        {
            coast = 5;
            name = "Bow";
            description = "This technology gives access to archer.";
        }

        public override void Unlock()
        {
            isUnlock = true;
            this.availableArmy.Add(new Archer());
        }

        public override void Effects()
        {
            
        }

        public override void upgradePeriod()
        {
            
        }
    }
}