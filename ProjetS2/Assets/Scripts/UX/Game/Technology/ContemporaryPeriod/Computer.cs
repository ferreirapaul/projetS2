using System.Collections.Generic;

namespace Technology
{
    public class Computer : Technology
    {
        public Computer(List<Ressources.Ressources> r, List<Building.Building> b, List<Army> a)
            : base(r, b, a)
        {
            coast = 150;
            name = "Computer";
            description = "This technology allows you to WIN the game.";
        }

        public override void Unlock()
        {
            isUnlock = true;
            //TODO: rfeoijeriofd
        }

        public override void Effects()
        {
            
        }

        public override void upgradePeriod()
        {
            
        }
    }
}