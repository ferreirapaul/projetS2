using System.Collections.Generic;
using Army;
using Ressources;
using Technology;
using UnityEngine;

namespace Building
{
    public class ArmyCamp : Building
    {
        private Gold golds;
        private Food food;
        public int LossGold;
        public int LossFood;
        public Game.Game game;
        
        public ArmyCamp(Gold g, Food f, Game.Game ga)
        {
            this.LossFood = 3;
            this.LossGold = 5;
            this.golds = g;
            this.food = f;
            this.game = ga;
            this.game.availableArmy.Add(new Hoplite());

            this.Name = "Army Camp";
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