using UnityEngine.UI;
namespace Ressources
{
    public abstract class Ressources
    {
        private int value;
        public int Value
        {
            get => value;
            set => this.value = value;
        }

        public Ressources()
        {
            this.value = 0;
        }
    }
}