using System.Collections.Generic;

namespace Technology
{
    public class Revolution : Technology
    {
        public int gain;
        public int loss;
        public Revolution(List<Ressources.Ressources> r, List<Building.Building> b, List<Army> a)
            : base(r, b, a)
        {
            coast = 45;
            name = "Revolution !";
            description = "This technology gives you 30 gold per turn but take you 40 population per turn.";
            gain = 30;
            loss = 40;
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