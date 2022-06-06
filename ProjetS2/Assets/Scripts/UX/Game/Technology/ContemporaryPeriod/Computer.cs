using System.Collections.Generic;

namespace Technology
{
    public class Computer : Technology
    {
        public Game.Game game;
        public Computer(List<Ressources.Ressources> r, List<Building.Building> b, List<Army.Army> a, Game.Game g)
            : base(r, b, a)
        {
            coast = 150;
            name = "Computer";
            description = "This technology allows you to WIN the game.";
            game = g;
        }

        public override void Unlock()
        {
            isUnlock = true;
            this.game.Win();
        }

        public override void Effects()
        {
            
        }

        public override void upgradePeriod()
        {
            
        }
    }
}