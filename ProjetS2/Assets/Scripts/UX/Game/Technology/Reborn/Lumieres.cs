﻿using System.Collections.Generic;

namespace Technology
{
    public class Lumieres : Technology
    {
        public int gain;
        public int loss;
        public Lumieres(List<Ressources.Ressources> r, List<Building.Building> b, List<Army.Army> a)
            : base(r, b,a)
        {
            coast = 40;
            name = "Philosophe des lumières";
            description = "This technology give you 15 golds per turn but it takes 10 population per turn.";
            gain = 15;
            loss = 10;
        }

        public override void Unlock()
        {
            isUnlock = true;
        }

        public override void Effects()
        {
            if (isUnlock)
            {
                this.ressources[1].Value += gain;
                this.ressources[2].Value -= loss;
            }
        }

        public override void upgradePeriod()
        {

        }
    }
}