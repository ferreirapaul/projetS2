using System.Collections.Generic;

namespace Technology
{
    public class Cannon : Technology
    {
        public Cannon(List<Ressources.Ressources> r, List<Building.Building> b, List<Army.Army> a)
            : base(r, b, a)
        {
            coast = 37;
            name = "Cannon";
            description = "This technology gives you access to the cannon.";
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