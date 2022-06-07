using System.Collections.Generic;

namespace Technology
{
    public class Globalization : Technology
    {
        public int gain;
        public GenMapScript genMapScript;
        public Globalization(List<Ressources.Ressources> r, List<Building.Building> b, List<Army.Army> a,GenMapScript genMapScript)
            : base(r, b, a)
        {
            this.genMapScript = genMapScript;
            coast = 70;
            name = "Globalization";
            description = "This technology allow to sse all the other player and to win 100 gold per turn. \n" +
                          "But, you can't have this technology and the communism.";
            gain = 100;
        }

        public override void Unlock()
        {
            isUnlock = true;
            genMapScript.map.AddVision(genMapScript.map.map_width,genMapScript.map.map_height,genMapScript.map.map_width);
            foreach (City city in game.citiesHidden)
            {
                genMapScript.map.RemoveVision(city.posX,city.posY,10);
            }
        }

        public override void Effects()
        {
            if (isUnlock)
            {
                this.ressources[0].Value += gain;
            }
        }

        public override void upgradePeriod()
        {
            
        }
    }
}