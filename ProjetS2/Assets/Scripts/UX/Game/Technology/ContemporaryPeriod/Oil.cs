using System.Collections.Generic;

namespace Technology
{
    public class Oil : Technology
    {
        public int gain;
        public int loss;
        public Oil(List<Ressources.Ressources> r, List<Building.Building> b, List<Army> a)
            : base(r, b, a)
        {
            coast = 60;
            name = "Oil";
            description = "This technology gives you 80 gold per turn but take you 60 population per turn.";
            gain = 80;
            loss = 60;
        }

        public override void Unlock()
        {
            isUnlock = true;
        }

        public override void Effects()
        {
            if (isUnlock)
            {
                this.ressources[0].Value += gain;
                this.ressources[2].Value -= loss;
            }
        }

        public override void upgradePeriod()
        {
            
        }
    }
}