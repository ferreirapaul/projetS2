using System.Collections.Generic;

namespace Technology
{
    public class Sniper : Technology
    {
        public Sniper(List<Ressources.Ressources> r, List<Building.Building> b, List<Army.Army> a)
            : base(r, b, a)
        {
            coast = 60;
            name = "Sniper";
            description = "This technology gives you access to the sniper.";
        }

        public override void Unlock()
        {
            isUnlock = true;
            this.availableArmy.Add(new Army.Sniper());
        }

        public override void Effects()
        {
            
        }

        public override void upgradePeriod()
        {
            
        }
    }
}