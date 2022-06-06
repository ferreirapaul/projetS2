using System.Collections.Generic;

namespace Technology
{
    public class Napoleon : Technology
    {
        public Game.Game game;
        public Napoleon(List<Ressources.Ressources> r, List<Building.Building> b, List<Army.Army> a, Game.Game g)
            : base(r, b, a)
        {
            coast = 37;
            name = "Napoleon";
            description = "This technology upgrade all of your troups";
            game = g;
        }

        public override void Unlock()
        {
            isUnlock = true;
            foreach (Army.Army i in this.game.UnlockArmy)
            {
                i.AttackDamage += 20;
            }
        }

        public override void Effects()
        {
            
        }

        public override void upgradePeriod()
        {
            
        }
    }
}