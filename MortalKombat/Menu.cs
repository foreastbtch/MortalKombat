using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortalKombat
{
    internal class Menu
    {
        public int Team1Size { get; set; }
        public int Team2Size { get; set; }
        public List<Fighter>? Fighters { get; set; }
        public List<Arena>? Arenas { get; set; }
        public int Option { get; set; }

        public Arena? Arena { get; set; }
        public List<Fighter>? Team1 { get; set; }
        public List<Fighter>? Team2 { get; set; }

        public Menu(List<Fighter>? fighters, List<Arena>? arenas)
        {
            Fighters = fighters;
            Arenas = arenas;
            Arena = new Arena();
            Team1 = new List<Fighter>();
            Team2 = new List<Fighter>();
            Option = -1;
            Team1Size = 0;
            Team2Size = 0;
        }

        public void start()
        {
            while (Option != 0)
            {
                Console.WriteLine("Alege o optiune: ");
                Console.WriteLine("1.Stabileste prima echipa.");
                Console.WriteLine("2.Stabileste a doua echipa.");
                Console.WriteLine("3.Stabileste arena.");
                Console.WriteLine("4.Incepe lupta.");
                Console.WriteLine("0.Iesire.");

                Option = Convert.ToInt32(Console.ReadLine());
                //Console.WriteLine(Option);
                switch (Option)
                {
                    case 0:
                        Console.WriteLine("Sfarsit.");
                        break;
                    case 1:
                        setTeam1();
                        break;
                    case 2:
                        setTeam2();
                        break;
                    case 3:
                        setArena();
                        break;
                    case 4:
                        if (Team1Size + Team2Size > Arena.size)
                        {
                            Console.WriteLine("Arena este prea mica.");
                        }
                        else
                        {
                            if (Team1Size == 0 || Team2Size == 0 || Team1.Count() == 0 || Team2.Count() == 0)
                            {
                                Console.WriteLine("Te rog, selecteaza echipele");
                            }
                            else
                            {
                                /*Arena.firstTeam = Team1;
                                Arena.secondTeam = Team2;*/
                                Arena.firstTeam = new List<Fighter>(Team1);
                                Arena.secondTeam = new List<Fighter>(Team2);
                                Arena.startTheFight();
                                Team1.Clear();
                                Team2.Clear();
                                Team1Size = 0;
                                Team2Size = 0;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Optiune invalida.");
                        break;
                }
            }
        }

        private void setTeam1()
        {
            Team1.Clear();
            Console.WriteLine("Dati dimensiunea primei echipe: ");
            Team1Size = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < Team1Size; i++)
            {
                for(int j = 0; j < Fighters.Count; j++)
                {
                    Console.WriteLine($"{j + 1}.{Fighters[j].Name} - {Fighters[j].Power} - {Fighters[j].HP} - {Fighters[j].Category}");
                }
                var position = Convert.ToInt32(Console.ReadLine());
                Team1.Add((Fighter)Fighters[position - 1].Clone());
                //Arena.firstTeam.Add(Fighters[position - 1]);
            }
        }

        private void setTeam2()
        {
            Team2.Clear();
            Console.WriteLine("Dati dimensiunea celei de a doua echipe: ");
            Team2Size = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < Team2Size; i++)
            {
                for (int j = 0; j < Fighters.Count; j++)
                {
                    Console.WriteLine($"{j + 1}.{Fighters[j].Name} - {Fighters[j].Power} - {Fighters[j].HP} - {Fighters[j].Category}");
                }
                var position = Convert.ToInt32(Console.ReadLine());
                Team2.Add((Fighter)Fighters[position - 1].Clone());
                //Arena.secondTeam.Add(Fighters[position - 1]);
            }
        }

        private void setArena()
        {
            Console.WriteLine("Alegeti o arena: ");
            for(int i = 0; i < Arenas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Arenas[i].location}");
            }
            var position = Convert.ToInt32(Console.ReadLine());
            Arena = Arenas[position - 1];
        }

    }
}
