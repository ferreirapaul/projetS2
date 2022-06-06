using System.Collections.Generic;
using Army;

namespace Technology
{
    public class Missiles : Technology
    {
        public Missiles(List<Ressources.Ressources> r, List<Building.Building> b, List<Army.Army> a)
            : base(r, b, a)
        {
            coast = 65;
            name = "Missiles";
            description = "This technology gives  you access to the missiles.";
        }

        public override void Unlock()
        {
            isUnlock = true;
            this.availableArmy.Add(new MissileLauncher());
        }

        public override void Effects()
        {
            
        }

        public override void upgradePeriod()
        {
            
        }
    }
}