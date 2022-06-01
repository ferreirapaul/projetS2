using System.Collections.Generic;

namespace Technology
{
    public class Feudalism : Technology
    {
        public Feudalism(List<Ressources.Ressources> r, List<Building.Building> b, List<Army.Army> a)
            : base(r, b,a)
        {
            coast = 15;
            name = "Feudalism";
            description = "This technology gives you 25 goald per turn.";
        }

        public override void Unlock()
        {
            isUnlock = true;
        }

        public override void Effects()
        {
            if (isUnlock)
            {
                this.ressources[0].Value += 25;
            }
        }

        public override void upgradePeriod()
        {
            
        }
    }
}