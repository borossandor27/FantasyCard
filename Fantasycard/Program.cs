using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fantasycard
{
    class Program
    {
        static List<Fantasycard> fantasycards = new List<Fantasycard>();

        static void Main(string[] args)
        {
            Beolvas(@"..\..\fantasycard.csv");
            Feladat_03();
            Feladat_04();
            Feladat_05();
            Feladat_06();
            Feladat_07();
            Feladat_08();
            Feladat_09();
            Console.WriteLine("\nProgram vége!");
            Console.ReadKey();
        }
        static void Beolvas(string forras)
        {
            try
            {
                using (StreamReader sr = new StreamReader(forras))
                {
                    sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        string[] sor = sr.ReadLine().Split(';');
                        fantasycards.Add(new Fantasycard(int.Parse(sor[0]), sor[1], sor[2], sor[3], sor[4]));
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// 3. Határozza meg és írja ki a képernyőre a minta szerint, 
        ///    hogy Leeroy (name) milyen faj (race) 
        /// </summary>
        static void Feladat_03()
        {
            Fantasycard f = fantasycards.Find(a => a.Name.Equals("Leeroy"));
            Console.WriteLine($"\n3. feladat: {f.Race} {f.Kaszt}");
        }
        /// <summary>
        /// 4. Írd ki a legkisebb és a legnagyobb erejű lény nevét és erejét!
        /// </summary>
        static void Feladat_04()
        {
            Console.WriteLine("\n4. feladat:");
            Fantasycard f = fantasycards.Find(a => a.Power == fantasycards.Max(b => b.Power));
            Console.WriteLine($"\tname:\t{f.Name}");
            Console.WriteLine($"\tpower:\t{f.Power}");
        }
        /// <summary>
        /// 5. Határozza meg és írja ki a képernyőre a minta szerint, hogy mi volt 
        ///    a neve annak dwarf (race)-nek akinek 4000 ereje(power) van.
        /// </summary>
        static void Feladat_05()
        {
            Console.WriteLine("\n5. feladat:");
            Fantasycard f = fantasycards.Find(a => a.Power == 4000 && a.Race.Equals("Dwarf"));
            if (f != null)
            {
                Console.WriteLine($"\tname:\t{f.Name}");
            }
            else
            {
                Console.WriteLine("\tNem találtam olyat, olyan dwarf (race)-t akinek 4000 ereje(power) van. ");
            }
        }
        /// <summary>
        /// 6. Határozza meg és írja ki a képernyőre a minta szerint, 
        /// hogy mely Orc-oknak (race) van 4500-nál több ereje(power) 
        /// akik a Laughing Skull(faction)-hoz tartoznak.
        /// </summary>
        static void Feladat_06()
        {
            Console.WriteLine("\n6. feladat:");
            foreach (Fantasycard item in fantasycards.FindAll(a => a.Race.Equals("Orc") && a.Faction.Equals("Laughing Skull") && a.Power > 4500))
            {
                Console.WriteLine($"\t{item.Power}, {item.Name}, {item.Race}, {item.Kaszt}");
            }
        }
        /// <summary>
        /// 7. Határozza meg és írja ki a képernyőre, hogy hány darab 
        /// Human, Orc, Elf és Dwarf (race) kártya létezik.
        /// </summary>
        static void Feladat_07()
        {
            Console.WriteLine("\n7. feladat:");
            Console.WriteLine($"\tHuman:\t{fantasycards.Count(a => a.Race.Equals("Human")),3} db");
            Console.WriteLine($"\tOrc:\t{fantasycards.Count(a => a.Race.Equals("Orc")),3} db");
            Console.WriteLine($"\tElf:\t{fantasycards.Count(a => a.Race.Equals("Elf")),3} db");
            Console.WriteLine($"\tDwarf:\t{fantasycards.Count(a => a.Race.Equals("Dwarf")),3} db");
        }
        /// <summary>
        /// 8. Írja ki a képernyőre fajonként (race) a leggyengébb kártya nevét, faját és erejét!
        /// </summary>
        static void Feladat_08()
        {
            Console.WriteLine("\n8. feladat:");
            foreach (string race in fantasycards.GroupBy(a => a.Race ).Select(b => new {race=b.Key}.race))
            {
                Fantasycard min = fantasycards.FindAll(a => a.Race.Equals(race)).OrderBy(b => b.Power).First();
                Console.WriteLine($"\t{min.Name}, {race}: {min.Power} ");
            }
        }
        /// <summary>
        /// 9. Hozzon létre animal.txt néven egy UTF-8 kódolású szöveges állományt 
        ///    tartalmazza az összes animal(faction) adatait! 
        ///    A fájlban a minta szerint szerepeljen kettősponttal elválasztva a kártya
        ///    ereje(power) neve(name) faja(race) kasztja(class)! 
        ///    A sorok erő szerint növekvő rendben legyenek az állományban!
        /// </summary>
        static void Feladat_09()
        {
            using (StreamWriter sw = new StreamWriter("animal.txt"))
            {
                foreach (Fantasycard item in fantasycards.FindAll(a => a.Faction.Equals("Animal")).OrderBy(b => b.Power))
                {
                    sw.WriteLine(string.Join(";", item.Power, item.Name, item.Race, item.Kaszt));
                }
            }
        }
    }
}
