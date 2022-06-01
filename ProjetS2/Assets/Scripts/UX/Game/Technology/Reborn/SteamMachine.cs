using System.Collections.Generic;

namespace Technology
{
    public class SteamMachine : Technology
    {
        public int goldGain;
        public int prodGain;
        public SteamMachine(List<Ressources.Ressources> r, List<Building.Building> b, List<Army.Army> a)
            : base(r, b, a)
        {
            coast = 50;
            name = "Steam Machine";
            description = "This technology gives you 40 gold and 6 production point per turn";
            goldGain = 40;
            prodGain = 6;
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
                this.ressources[3].Value += prodGain;
            }
        }

        public override void upgradePeriod()
        {
            
        }
    }
}