using System.Collections.Generic;

namespace Technology
{
    public class Aqueduct : Technology
    {
        private int gain;
        public Aqueduct(List<Ressources.Ressources> r, List<Building.Building> b, List<Army> a)
            : base(r, b, a)
        {
            coast = 20;
            this.gain = 3;
            name = "Aqueduct";
            description = "This technology gives 3 food per turn. \n" +
                          "At each period it gives 3 food mores per turn.";
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
            gain += 3;
        }
    }
}