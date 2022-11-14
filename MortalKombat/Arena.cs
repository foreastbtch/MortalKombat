namespace MortalKombat
{
	public class Arena
	{
		public List<Fighter> FirstTeam { get; set; }
		public List<Fighter> SecondTeam { get; set; }
		public int Size { get; set; }
		public string Location { get; set; }

		public Arena(int size, string location)
		{
			FirstTeam = new List<Fighter>();
			SecondTeam = new List<Fighter>();
			this.Size = size;
			this.Location = location;
		}

		public Arena()
		{
			FirstTeam = new List<Fighter>();
			SecondTeam = new List<Fighter>();
			Size = 0;
			Location = "empty";
		}

		public void StartTheFight()
		{
			Console.WriteLine("Lupta incepe..");
			Console.WriteLine(Location);
			Console.WriteLine();
			Console.WriteLine("Prima echipa:");
			foreach (Fighter fighter in FirstTeam)
			{
				Console.WriteLine(fighter.Name);
			}
			Console.WriteLine();
			Console.WriteLine("A doua echipa:");
			foreach (Fighter fighter in SecondTeam)
			{
				Console.WriteLine(fighter.Name);
			}
			Console.WriteLine();
			Console.WriteLine("FIGHT!");
			Fight();
			Generics();
		}

		public void PlayerAttacks(Fighter player, Fighter enemy, List<Fighter> enemyTeam, int teamNumber)
		{
			var random = new Random();
			int abilityChance = random.Next(0, player.Agility);
			if (abilityChance > 0.75 * player.Agility)
			{
				player.SpecialAbility(enemy, enemyTeam);
			}
			else
			{
				float damage = random.Next((int)player.Power / 3, (int)player.Power);
				var defendChance = random.Next(0, enemy.Agility);
				if (defendChance > 0.6 * enemy.Agility)
				{
					enemy.Deff(damage, player);
				}
				else
				{
					if (teamNumber == 1)
					{
						Console.WriteLine($"{teamNumber}. {player.Name} a cauzat {damage} daune lui {enemy.Name}!");
					}
					else
					{
						Console.WriteLine($"{teamNumber}. {player.Name} a ripostat impotriva lui {enemy.Name} provocand daune de {damage}!");
					}
					enemy.GotHit(damage);
				}
			}
		}

		private void Fight()
		{
			var random = new Random();
			while (!IsGameOver())
			{
				int player1 = random.Next(0, FirstTeam.Count);
				int player2 = random.Next(0, SecondTeam.Count);
				Fighter fighter1 = FirstTeam[player1];
				Fighter fighter2 = SecondTeam[player2];

				PlayerAttacks(fighter1, fighter2, SecondTeam, 1);
				if (fighter2.HP <= 0f)
				{
					Console.WriteLine($"{fighter2.Name} a fost ucis!");
					SecondTeam.Remove(fighter2);
					Console.WriteLine();
				}
				else
				{
					PlayerAttacks(fighter2, fighter1, FirstTeam, 2);
					if (fighter1.HP <= 0f)
					{
						Console.WriteLine($"{fighter1.Name} a fost ucis!");
						FirstTeam.Remove(fighter1);
						Console.WriteLine();
					}
				}
			}
		}

		private void Generics()
		{
			if (FirstTeam.Count > 0)
			{
				ShowWinningTeam(FirstTeam);
			}
			else
			{
				ShowWinningTeam(SecondTeam);
			}
		}

		private static void ShowWinningTeam(List<Fighter> team)
		{
			if (team.Count == 1)
			{
				Console.Write(team[0].Name + " a castigat!");
			}
			else
			{
				foreach (Fighter fighter in team)
				{
					if (fighter.Equals(team.Last()))
					{
						Console.Write(fighter.Name + " ");
					}
					else
					{
						Console.Write(fighter.Name + ", ");
					}
				}
				Console.Write("au castigat!");
			}
			Console.WriteLine();
		}

		private bool IsGameOver()
		{
			return (FirstTeam.Count == 0 || SecondTeam.Count == 0 && !(TotalLifePoints(FirstTeam) > 0 && TotalLifePoints(SecondTeam) > 0)) ? true : false;
		}

		private static float TotalLifePoints(List<Fighter> list)
		{
			var sum = 0f;
			foreach (var fighter in list)
			{
				sum += fighter.HP;
			}
			return sum;
		}
	}
}
