using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortalKombat
{
    internal class Arena
    {
        public List<Fighter> firstTeam { get; set; }
        public List<Fighter> secondTeam { get; set; }
        public int size { get; set; }
        public string location { get; set; }

        public Arena(int size, string location)
        {
            firstTeam = new List<Fighter>();
            secondTeam = new List<Fighter>();
            this.size = size;
            this.location = location;
        }

        public Arena()
        {
            firstTeam = new List<Fighter>();
            secondTeam = new List<Fighter>();
            size = 0;
            location = "empty";
        }

        public void addFighterToFirstTeam(Fighter fighter)
        {
            if (fighter != null && firstTeam != null)
            {
                firstTeam.Add(fighter);
            }
            else
            {
                Console.WriteLine("Nu puteti adauga un luptator null sau echipa este null.");
            }
        }

        public void addFighterToSecondTeam(Fighter fighter)
        {
            if (fighter != null && secondTeam != null)
            {
                secondTeam.Add(fighter);
            }
            else
            {
                Console.WriteLine("Nu puteti adauga un luptator null sau echipa este null.");
            }
        }

        public void startTheFight()
        {
            Console.WriteLine("Lupta incepe..");
            Console.WriteLine(location);
            Console.WriteLine();
            Console.WriteLine("Prima echipa:");
            foreach(Fighter fighter in firstTeam)
            {
                Console.WriteLine(fighter.Name);
            }
            Console.WriteLine();
            Console.WriteLine("A doua echipa:");
            foreach (Fighter fighter in secondTeam)
            {
                Console.WriteLine(fighter.Name);
            }
            Console.WriteLine();
            Console.WriteLine("FIGHT!");
            fight();
            generics();
        }

        private void fight()
        {
            var random = new Random();
            while (!isGameOver())
            {
                int player1 = random.Next(0, firstTeam.Count);
                int player2 = random.Next(0, secondTeam.Count);
                Fighter fighter1 = firstTeam[player1];
                Fighter fighter2 = secondTeam[player2];

                float daune1 = random.Next(0, (int)fighter1.Power);
                Console.WriteLine($"1. {fighter1.Name} a cauzat {daune1} daune lui {fighter2.Name}!");
                fighter2.HP -= daune1;
                if (fighter2.HP <= 0f)
                {
                    Console.WriteLine($"{fighter2.Name} a fost ucis!");
                    secondTeam.Remove(fighter2);
                    Console.WriteLine();
                }
                else
                {
                    float daune2 = random.Next(0, (int)fighter2.Power);
                    Console.WriteLine($"2. {fighter2.Name} a ripostat impotriva lui {fighter1.Name} provocand daune de {daune2}!");
                    fighter1.HP -= daune2;
                    if (fighter1.HP <= 0f)
                    {
                        Console.WriteLine($"{fighter1.Name} a fost ucis!");
                        firstTeam.Remove(fighter1);
                        Console.WriteLine();
                    }
                    //Console.WriteLine();
                }
            }
        }

        private void generics()
        {
            if (firstTeam.Count > 0)
            {
                foreach (Fighter fighter in firstTeam)
                {
                    Console.Write(fighter.Name + ", ");
                }
                Console.Write("au castigat!");
                Console.WriteLine();
            }
            else
            {
                foreach (Fighter fighter in secondTeam)
                {
                    Console.Write(fighter.Name + ", ");
                }
                Console.Write("au castigat!");
                Console.WriteLine();
            }
        }

        private bool isGameOver()
        {
            return (firstTeam.Count == 0 || secondTeam.Count == 0 && !(totalLifePoints(firstTeam) > 0 && totalLifePoints(secondTeam) > 0)) ? true : false;
        }

        private float totalLifePoints(List<Fighter> list)
        {
            var sum = 0f;
            foreach(var fighter in list)
            {
                sum += fighter.HP;
            }
            return sum;
        }
    }
}
