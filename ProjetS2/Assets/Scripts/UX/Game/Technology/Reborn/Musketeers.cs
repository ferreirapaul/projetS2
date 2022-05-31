using System.Collections.Generic;

namespace Technology
{
    public class Musketeers : Technology
    {
        public Musketeers(List<Ressources.Ressources> r, List<Building.Building> b, List<Army> a)
            : base(r, b, a)
        {
            coast = 35;
            name = "Musketeers";
            description = "This technology gives you access to the musketeers.";
        }

        public override void Unlock()
        {
            isUnlock = true;
            //TODO:grupegopfng
        }

        public override void Effects()
        {
            
        }

        public override void upgradePeriod()
        {
            
        }
    }
}