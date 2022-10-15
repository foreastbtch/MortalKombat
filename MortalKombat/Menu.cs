using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortalKombat
{
	internal class Menu
	{
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
		}

		public void Start()
		{
			while (Option != 0)
			{
				try
				{
					Console.WriteLine("Alege o optiune: ");
					Console.WriteLine("1.Stabileste prima echipa.");
					Console.WriteLine("2.Stabileste a doua echipa.");
					Console.WriteLine("3.Stabileste arena.");
					Console.WriteLine("4.Incepe lupta.");
					Console.WriteLine("0.Iesire.");

					Option = Convert.ToInt32(Console.ReadLine());
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}

				switch (Option)
				{
					case 0:
						Console.WriteLine("Sfarsit.");
						break;
					case 1:
						SetTeam1();
						break;
					case 2:
						SetTeam2();
						break;
					case 3:
						SetArena();
						break;
					case 4:
						if (Team1.Count + Team2.Count > Arena.Size)
						{
							Console.WriteLine("Arena este prea mica.");
						}
						else
						{
							if (Team1.Count == 0 || Team2.Count == 0)
							{
								Console.WriteLine("Te rog, selecteaza echipele");
							}
							else
							{
								Arena.FirstTeam = new List<Fighter>();
								foreach (Fighter fighter in Team1)
								{
									Arena.FirstTeam.Add((Fighter)fighter.Clone());
								}
								Arena.SecondTeam = new List<Fighter>();
								foreach (Fighter fighter in Team2)
								{
									Arena.SecondTeam.Add((Fighter)fighter.Clone());
								}
								Arena.StartTheFight();
								/*Team1.Clear();
                                Team2.Clear();*/
							}
						}
						break;
					default:
						Console.WriteLine("Optiune invalida.");
						break;
				}
			}
		}

		private void SetTeam1()
		{
			Team1.Clear();
			Console.WriteLine("Dati dimensiunea primei echipe: ");
			try
			{
				var Team1Size = Convert.ToInt32(Console.ReadLine());
				for (int i = 0; i < Team1Size; i++)
				{
					for (int j = 0; j < Fighters.Count; j++)
					{
						Console.WriteLine($"{j + 1}.{Fighters[j].Name} - {Fighters[j].Power} - {Fighters[j].HP} - {Fighters[j].Category}");
					}
					var position = Convert.ToInt32(Console.ReadLine());
					Team1.Add((Fighter)Fighters[position - 1].Clone());
					Fighters[position - 1].SayLine();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		private void SetTeam2()
		{
			Team2.Clear();
			Console.WriteLine("Dati dimensiunea celei de a doua echipe: ");
			try
			{
				var Team2Size = Convert.ToInt32(Console.ReadLine());
				for (int i = 0; i < Team2Size; i++)
				{
					for (int j = 0; j < Fighters.Count; j++)
					{
						Console.WriteLine($"{j + 1}.{Fighters[j].Name} - {Fighters[j].Power} - {Fighters[j].HP} - {Fighters[j].Category}");
					}
					var position = Convert.ToInt32(Console.ReadLine());
					Team2.Add((Fighter)Fighters[position - 1].Clone());
					Fighters[position - 1].SayLine();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		private void SetArena()
		{
			Console.WriteLine("Alegeti o arena: ");
			for (int i = 0; i < Arenas.Count; i++)
			{
				Console.WriteLine($"{i + 1}. {Arenas[i].Location} - {Arenas[i].Size} locuri.");
			}
			try
			{
				var position = Convert.ToInt32(Console.ReadLine());
				Arena = Arenas[position - 1];
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

	}
}
