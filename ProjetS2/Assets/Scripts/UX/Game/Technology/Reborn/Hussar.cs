using System.Collections.Generic;

namespace Technology
{
    public class Hussar : Technology
    {
        public Hussar(List<Ressources.Ressources> r, List<Building.Building> b, List<Army> a)
            : base(r, b, a)
        {
            coast = 35;
            name = "Hussar";
            description = "This technology gives you access to the hussar soldier.";
        }

        public override void Unlock()
        {
            isUnlock = true;
            //TODO ???
        }

        public override void Effects()
        {
            
        }

        public override void upgradePeriod()
        {
            
        }
    }
}