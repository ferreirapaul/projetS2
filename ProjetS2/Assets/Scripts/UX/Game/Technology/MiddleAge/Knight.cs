using System.Collections.Generic;

namespace Technology
{
    public class Knight : Technology
    {
        public Knight(List<Ressources.Ressources> r, List<Building.Building> b, List<Army.Army> a)
            : base(r, b, a)
        {
            coast = 17;
            name = "Knight";
            description = "This technology gives you access to the knights";
        }

        public override void Unlock()
        {
            isUnlock = true;
            //TODO:0..622611
        }

        public override void Effects()
        {
            
        }

        public override void upgradePeriod()
        {
            
        }
    }
}