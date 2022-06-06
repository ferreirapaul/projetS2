using System.Collections.Generic;
using Army;

namespace Technology
{
    public class Halberdier : Technology
    {
        public Halberdier(List<Ressources.Ressources> r, List<Building.Building> b, List<Army.Army> a)
            : base(r, b, a)
        {
            coast = 35;
            name = "Halberdier";
            description = "This technology gives you access to the harlderdier.";
        }

        public override void Unlock()
        {
            isUnlock = true;
            this.availableArmy.Add(new Hallebardeer());
        }

        public override void Effects()
        {
            
        }

        public override void upgradePeriod()
        {
            
        }
    }
}