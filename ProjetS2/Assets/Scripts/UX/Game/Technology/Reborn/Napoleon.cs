using System.Collections.Generic;

namespace Technology
{
    public class Napoleon : Technology
    {
        public Napoleon(List<Ressources.Ressources> r, List<Building.Building> b, List<Army> a)
            : base(r, b, a)
        {
            coast = 37;
            name = "Napoleon";
            description = "This technology upgrade all of your troups";
        }

        public override void Unlock()
        {
            isUnlock = true;
            //fe
        }

        public override void Effects()
        {
            
        }

        public override void upgradePeriod()
        {
            
        }
    }
}