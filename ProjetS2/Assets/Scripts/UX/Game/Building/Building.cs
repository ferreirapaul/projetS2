using UnityEngine;

namespace Building
{
    public abstract class Building
    {
        public string Name;
        public abstract void DoTurn();
        public abstract void LevelUp();
    }
}