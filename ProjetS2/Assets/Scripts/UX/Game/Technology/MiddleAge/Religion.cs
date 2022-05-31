using System.Collections.Generic;

namespace Technology
{
    public class Religion : Technology
    {
        public int goldGain;
        public int popGain;
        public Religion(List<Ressources.Ressources> r, List<Building.Building> b, List<Army> a)
            : base(r, b, a)
        {
            coast = 10;
            name = "Religion";
            description = "This technology gives you 6 gold and 15 people per turn. \n" +
                          "When upgraded it gives 9 gold and 25 people per turn";
            goldGain = 6;
            popGain = 15;
        }

        public override void Unlock()
        {
            isUnlock = true;
        }

        public override void Effects()
        {
            if (isUnlock)
            {
                this.ressources[0].Value += goldGain;
                this.ressources[2].Value += popGain;
            }
        }

        public override void upgradePeriod()
        {
            goldGain += 3;
            popGain += 10;
        }
    }
}