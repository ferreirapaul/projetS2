using Ressources;
using UnityEditor.Build.Content;

namespace Building
{
    public class School : Building
    {
        private Sciences sciences;
        private int gain;

        public School(Sciences s)
        {
            this.sciences = s;
            this.gain = 2;
        }

        public override void DoTurn()
        {
            this.sciences.Value += this.gain;
        }
        
        public override void LevelUp()
        {
            this.gain += 5;
        }
    }
}