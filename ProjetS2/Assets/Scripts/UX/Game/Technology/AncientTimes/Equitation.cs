using System.Collections.Generic;

namespace Technology
{
    public class Equitation : Technology
    {
        public Equitation(List<Ressources.Ressources> r, List<Building.Building> b, List<Army> a)
            : base(r, b, a)
        {
            coast = 6;
            name = "Equitation";
            description = "This technology gives access to the horse man.";
        }

        public override void Unlock()
        {
            isUnlock = true;
            //TODO : tu connais
        }

        public override void Effects()
        {
            
        }

        public override void upgradePeriod()
        {
            
        }
    }
}