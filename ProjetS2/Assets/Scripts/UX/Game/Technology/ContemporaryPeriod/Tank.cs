using System.Collections.Generic;

namespace Technology
{
    public class Tank : Technology
    {
        public Tank(List<Ressources.Ressources> r, List<Building.Building> b, List<Army.Army> a)
            : base(r, b, a)
        {
            coast = 63;
            name = "Tank";
            description = "This technology gives you access to the tank.";
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