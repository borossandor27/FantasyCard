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
            Console.WriteLine("Program vége!");
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
            Console.WriteLine($"\n3. feladat: {fantasycards.Find(a => a.Name.Equals("Leeroy")).Race}");
        }
    }
}
