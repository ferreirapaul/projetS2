using System.Collections.Generic;

namespace Technology
{
    public class Halberdier : Technology
    {
        public Halberdier(List<Ressources.Ressources> r, List<Building.Building> b, List<Army> a)
            : base(r, b, a)
        {
            coast = 35;
            name = "Halberdier";
            description = "This technology gives you access to the harlderdier.";
        }

        public override void Unlock()
        {
            isUnlock = true;
            //TODO:??
        }

        public override void Effects()
        {
            
        }

        public override void upgradePeriod()
        {
            
        }
    }
}