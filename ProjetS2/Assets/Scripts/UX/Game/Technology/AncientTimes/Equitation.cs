using System.Collections.Generic;
using Army;

namespace Technology
{
    public class Equitation : Technology
    {
        public Equitation(List<Ressources.Ressources> r, List<Building.Building> b, List<Army.Army> a)
            : base(r, b, a)
        {
            coast = 6;
            name = "Equitation";
            description = "This technology gives access to the horse man.";
        }

        public override void Unlock()
        {
            isUnlock = true;
            this.availableArmy.Add(new Cavalier());
        }

        public override void Effects()
        {
            
        }

        public override void upgradePeriod()
        {
            
        }
    }
}