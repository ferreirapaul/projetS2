using Ressources;
using UnityEditor.Build.Content;

namespace Building
{
    public class Land : Building
    {
        private Food food;
        public int gain;

        public Land(Food f)
        {
            this.food = f;
            this.gain = 4;
        }

        public override void DoTurn()
        {
            this.food.Value += gain;
        }
        
        public override void LevelUp()
        {
            this.gain += 3;
        }
    }
}