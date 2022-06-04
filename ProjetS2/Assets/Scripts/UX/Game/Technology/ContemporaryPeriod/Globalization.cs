using System.Collections.Generic;

namespace Technology
{
    public class Globalization : Technology
    {
        public int gain;
        public Globalization(List<Ressources.Ressources> r, List<Building.Building> b, List<Army.Army> a)
            : base(r, b, a)
        {
            coast = 70;
            name = "Globalization";
            description = "This technology allow to sse all the other player and to win 100 gold per turn. \n" +
                          "But, you can't have this technology and the communism.";
            gain = 100;
        }

        public override void Unlock()
        {
            isUnlock = true;
            //TODO: jezhub
        }

        public override void Effects()
        {
            if (isUnlock)
            {
                this.ressources[0].Value += gain;
            }
        }

        public override void upgradePeriod()
        {
            
        }
    }
}