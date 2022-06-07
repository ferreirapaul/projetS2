using System.Collections.Generic;

namespace Technology
{
    public class Comunism : Technology
    {
        public GenMapScript genMapScript;

        public Comunism(List<Ressources.Ressources> r, List<Building.Building> b, List<Army.Army> a, GenMapScript genMapScript)
            : base(r, b, a)
        {
            this.genMapScript = genMapScript;
            coast = 70;
            name = "Comunism";
            description = "This technology allow you hide yourself from the other player and to buff your army. \n" +
                          "But, you can't have this technology and the globalization.";
        }

        public override void Unlock()
        {
            isUnlock = true;
            //TODO
        }

        public override void Effects()
        {
            
        }

        public override void upgradePeriod()
        {
            
        }
    }
}