using Ressources;

namespace Building
{
    public class Market : Building
    {
        private Gold golds;
        private int gain;

        public Market(Gold g)
        {
            this.golds = g;
            this.gain = 20;

            this.Name = "Market";
        }

        public override void DoTurn()
        {
            this.golds.Value += this.gain;
        }
        
        public override void LevelUp()
        {
            this.gain += 10;
        }
    }
}