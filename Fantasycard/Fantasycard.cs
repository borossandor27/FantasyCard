using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasycard
{
    class Fantasycard
    {
        int power;
        string name;
        string faction;
        string race;
        string osztaly;

        public int Power { get => power; set => power = value; }
        public string Name { get => name; set => name = value; }
        public string Faction { get => faction; set => faction = value; }
        public string Race { get => race; set => race = value; }
        public string Osztaly { get => osztaly; set => osztaly = value; }

        public Fantasycard(int power, string name, string faction, string race, string osztaly)
        {
            Power = power;
            Name = name;
            Faction = faction;
            Race = race;
            Osztaly = osztaly;
        }
    }
}
