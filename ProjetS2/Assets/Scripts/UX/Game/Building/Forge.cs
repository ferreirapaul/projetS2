using Ressources;

namespace Building
{
    public class Forge : Building
    {
        private ProductionPoints points;
        private int gain;

        public Forge(ProductionPoints p)
        {
            this.points = p;
            this.points.Value = 1;
            this.gain = 1;
        }

        public override void DoTurn()
        {
            this.points.Value += this.gain;
        }
        
        public override void LevelUp()
        {
            this.gain += 1;
        }
    }
}