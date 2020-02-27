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
        string kaszt;

        public int Power { get => power; set => power = value; }
        public string Name { get => name; set => name = value; }
        public string Faction { get => faction; set => faction = value; }
        public string Race { get => race; set => race = value; }
        public string Kaszt { get => kaszt; set => kaszt = value; }

        public Fantasycard(int power, string name, string faction, string race, string kaszt)
        {
            Power = power;
            Name = name;
            Faction = faction;
            Race = race;
            Kaszt = kaszt;
        }
    }
}
