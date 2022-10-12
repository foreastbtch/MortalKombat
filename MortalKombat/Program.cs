using MortalKombat.Fighters;

namespace MortalKombat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Fighter f1 = new Fighter("Scorpion", 100f, 35f, Category.Assassin);
            Fighter f2 = new Fighter("Raiden", 80f, 45f, Category.Mage);
            Fighter f3 = new Fighter("Sub-Zero", 130f, 25f, Category.Ninja);
            Fighter f4 = new Fighter("Liu Kang", 120f, 50f, Category.Warrior);*/
            Fighter f1 = new Warrior("Scorpion", 1, 2);
            Fighter f2 = new Warrior("Liu Kang", 3, 3);
            Fighter f3 = new Archer("Varus", 3);
            Fighter f4 = new Archer("Draven", 1);
            List<Fighter> fightersList = new List<Fighter>();
            fightersList.Add(f1);
            fightersList.Add(f2);
            fightersList.Add(f3);
            fightersList.Add(f4);

            Arena arena1 = new Arena(4, "Pit");
            Arena arena2 = new Arena(2, "Sky");
            Arena arena3 = new Arena(3, "Cage");
            List<Arena> arenas = new List<Arena>();
            arenas.Add(arena1);
            arenas.Add(arena2);
            arenas.Add(arena3);

            /*Arena arena1 = new Arena(4, "Pit");
            arena1.addFighterToFirstTeam(f1);
            arena1.addFighterToFirstTeam(f2);
            arena1.addFighterToSecondTeam(f3);
            arena1.addFighterToSecondTeam(f4);

            arena1.startTheFight();*/

            Menu menu = new Menu(fightersList, arenas);
            /*menu.Fighters = fightersList;
            menu.Arenas = arenas;*/
            menu.start();
        }
    }
}