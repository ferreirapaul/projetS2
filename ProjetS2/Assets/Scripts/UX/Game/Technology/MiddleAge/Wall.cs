﻿using System.Collections.Generic;
using UnityEngine.Android;

namespace Technology
{
    public class Wall : Technology
    {
        public Wall(List<Ressources.Ressources> r, List<Building.Building> b, List<Army> a)
            : base(r, b, a)
        {
            coast = 30;
            name = "Wall";
            description = "This technology upgrade your city health. \n" +
                          "When upgraded it continue its upgrade";
        }

        public override void Unlock()
        {
            isUnlock = true;
            //TODO: fjihgi
        }

        public override void Effects()
        {
            
        }

        public override void upgradePeriod()
        {
            //TODO:fijehr
        }
    }
}