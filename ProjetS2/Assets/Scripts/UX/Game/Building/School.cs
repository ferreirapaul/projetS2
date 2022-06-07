using Ressources;

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
            this.Name = "School";
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