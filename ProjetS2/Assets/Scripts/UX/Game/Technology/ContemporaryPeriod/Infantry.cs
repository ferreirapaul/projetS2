using System.Collections.Generic;

namespace Technology
{
    public class Infantry : Technology
    {
        public Infantry(List<Ressources.Ressources> r, List<Building.Building> b, List<Army.Army> a)
            : base(r, b, a)
        {
            coast = 60;
            name = "Infantry";
            description = "This technology gives you access to the infantry.";
        }

        public override void Unlock()
        {
            isUnlock = true;
            //TODO : tu connais
        }

        public override void Effects()
        {
            
        }

        public override void upgradePeriod()
        {
            
        }
    }
}