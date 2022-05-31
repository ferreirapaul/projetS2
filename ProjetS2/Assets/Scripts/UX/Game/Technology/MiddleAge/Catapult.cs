using System.Collections.Generic;

namespace Technology
{
    public class Catapult : Technology
    {
        public Catapult(List<Ressources.Ressources> r, List<Building.Building> b, List<Army> a)
            : base(r, b, a)
        {
            coast = 20;
            name = "Catapult";
            description = "This technology gives you access to the Catapult.";
        }

        public override void Unlock()
        {
            isUnlock = true;
            //TODO:....
        }

        public override void Effects()
        {
            
        }

        public override void upgradePeriod()
        {
            
        }
    }
}