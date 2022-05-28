using Ressources;
using UnityEngine.UI;

namespace Building
{
    public class Mine : Building
    {
        private Gold golds;
        public int gain;

        public Mine(Gold g)
        {
            this.golds = g;
            this.gain = 7;
        }

        public override void DoTurn()
        {
            this.golds.Value += gain;
        }
        
        public override void LevelUp()
        {
            this.gain += 3;
        }
    }
}