using System.Collections.Generic;
using UnityEngine;

namespace Technology
{
    public class Ebeniste : Technology
    {
        public Ebeniste(List<Ressources.Ressources> r, List<Building.Building> b, List<Army.Army> a)
            : base(r, b,a)
        {
            coast = 6;
            name = "Ebeniste";
            description = "This technology gives access to the battering ram.";
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