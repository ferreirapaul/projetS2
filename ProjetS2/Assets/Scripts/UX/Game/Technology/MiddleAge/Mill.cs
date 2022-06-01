using System.Collections.Generic;

namespace Technology
{
    public class Mill : Technology
    {
        public int gain;
        public Mill(List<Ressources.Ressources> r, List<Building.Building> b, List<Army.Army> a)
            : base(r, b,a)
        {
            coast = 15;
            name = "Mill";
            description = "This technology give you 9 food per turn \n" +
                          "When upgraded it gives 15 food per turn";
            gain = 9;
        }

        public override void Unlock()
        {
            isUnlock = true;
        }

        public override void Effects()
        {
            if (isUnlock)
            {
                this.ressources[1].Value += gain;
            }
        }

        public override void upgradePeriod()
        {
            gain += 6;
        }
    }
}