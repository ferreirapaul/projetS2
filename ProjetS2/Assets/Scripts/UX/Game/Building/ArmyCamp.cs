using Ressources;

namespace Building
{
    public class ArmyCamp : Building
    {
        private Gold golds;
        private Food food;
        public int LossGold;
        public int LossFood;

        public ArmyCamp(Gold g, Food f)
        {
            this.LossFood = 3;
            this.LossGold = 5;
            this.golds = g;
            this.food = f;
        }

        public override void DoTurn()
        {
            this.golds.Value -= LossGold;
            this.food.Value -= LossFood;
        }
        
        public override void LevelUp()
        {
            LossFood += 1;
            LossGold += 5;
        }
    }
}