using System.Collections.Generic;

namespace Technology
{
    public class Pike : Technology
    {
        public Pike(List<Ressources.Ressources> r, List<Building.Building> b, List<Army.Army> a)
            : base(r, b, a)
        {
            coast = 17;
            name = "Pike";
            description = "This technology gives you access to the pike soldiers.";
        }

        public override void Unlock()
        {
            isUnlock = true;
            this.availableArmy.Add(new Army.Pike());
        }

        public override void Effects()
        {
            
        }

        public override void upgradePeriod()
        {
            
        }
    }
}