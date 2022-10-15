using MortalKombat.Fighters;

namespace MortalKombat
{
	internal class Program
	{
		static void Main(string[] args)
		{
			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
			Fighter f1 = new Warrior("Scorpion", 1, 1);
			Fighter f2 = new Warrior("Liu Kang", 1, 1);
			Fighter f3 = new Archer("Varus", 1);
			Fighter f4 = new Archer("Draven", 1);
			Fighter f5 = new Mage("Raiden", 2);
			Fighter f6 = new Ninja("Sub-Zero", 2);
			Fighter f7 = new Monster("Goro", 1);
			Fighter f8 = new Warrior("Johnny Cage", 1, 2);
			List<Fighter> fightersList = new List<Fighter>();
			fightersList.Add(f1);
			fightersList.Add(f2);
			fightersList.Add(f3);
			fightersList.Add(f4);
			fightersList.Add(f5);
			fightersList.Add(f6);
			fightersList.Add(f7);
			fightersList.Add(f8);

			Arena arena1 = new Arena(4, "Pit");
			Arena arena2 = new Arena(2, "Sky");
			Arena arena3 = new Arena(3, "Cage");
			List<Arena> arenas = new List<Arena>();
			arenas.Add(arena1);
			arenas.Add(arena2);
			arenas.Add(arena3);

			Menu menu = new Menu(fightersList, arenas);
			try
			{
				menu.Start();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			Console.WriteLine($"O exceptie unexpected a fost prinsa: {e.ExceptionObject}");
		}
	}
}