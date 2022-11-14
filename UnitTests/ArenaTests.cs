using MortalKombat;
using MortalKombat.Fighters;
using Xunit;

namespace UnitTests
{
	public class ArenaTests
	{
		[Fact]
		public void ArenaConstructor_ShouldInitializeDefaultObjectWithDefaultValues()
		{
			//arrange
			var sut = new Arena();

			//act
			var actual = sut.Location == "empty" && sut.Size == 0 && sut.FirstTeam.Count == 0 && sut.SecondTeam.Count == 0;

			//assert
			Assert.True(actual);
		}

		[Fact]
		public void ArenaConstructor_ShouldInitializeObjectWithGivenValues()
		{
			//arrange
			var sut = new Arena(100, "Moon");

			//act
			var actual = sut.Location == "Moon" && sut.Size == 100 && sut.FirstTeam.Count == 0 && sut.SecondTeam.Count == 0;

			//assert
			Assert.True(actual);
		}

		[Fact]
		public void ArenaFirstPlayerAttacks_ShouldChangeBothPlayersHP()
		{
			//arrange
			var sut = new Arena(2, "Moon");
			var fighter1 = new Archer("Archer1", 0);
			var fighter2 = new Archer("Archer2", 0);
			sut.FirstTeam.Add(fighter1);
			sut.SecondTeam.Add(fighter2);
			sut.PlayerAttacks(fighter1, fighter2, sut.SecondTeam, 1);
			sut.PlayerAttacks(fighter2, fighter1, sut.FirstTeam, 2);

			//act
			var actual = ((fighter1.HP <= new Archer("", 0).HP) && (fighter2.HP <= new Archer("", 0).HP));

			//assert
			Assert.True(actual);
		}

		[Fact]

		public void ArenaFight_ShouldBeFinite()
		{
			var sut = new Arena(2, "Moon");
			var fighter1 = new Archer("Archer1", 0);
			var fighter2 = new Archer("Archer2", 0);
			sut.FirstTeam.Add(fighter1);
			sut.SecondTeam.Add(fighter2);

			sut.StartTheFight();

			var actual = sut.FirstTeam.Count == 0 || sut.SecondTeam.Count == 0;

			Assert.True(actual);
		}

		[Fact]

		public void ArenaFight_ShouldBeBalancedWithWarriors()
		{
			var sut = new Arena(2, "Moon");
			Fighter fighter1 = new Warrior("Scorpion", 1, 1);
			Fighter fighter2 = new Warrior("Liu Kang", 1, 1);
			sut.FirstTeam.Add(fighter1.Clone());
			sut.SecondTeam.Add(fighter2.Clone());
			var team1Wins = 0;
			var team2Wins = 0;

			for (int i = 0; i < 10; i++)
			{
				sut.StartTheFight();
				if (sut.FirstTeam.Count == 0)
				{
					sut.FirstTeam.Add(fighter1.Clone());
					team2Wins++;
				}
				else
				{
					sut.SecondTeam.Add(fighter2.Clone());
					team1Wins++;
				}
			}

			var actual = Math.Abs(team1Wins - team2Wins);
			Assert.InRange(actual, 0, 2);
		}

		[Fact]

		public void ArenaFight_ShouldBeBalancedWithArchers()
		{
			var sut = new Arena(2, "Moon");
			var fighter1 = new Archer("Archer1", 0);
			var fighter2 = new Archer("Archer2", 0);
			sut.FirstTeam.Add(fighter1.Clone());
			sut.SecondTeam.Add(fighter2.Clone());
			var team1Wins = 0;
			var team2Wins = 0;

			for (int i = 0; i < 100; i++)
			{
				sut.StartTheFight();
				if (sut.FirstTeam.Count == 0)
				{
					sut.FirstTeam.Add(fighter1.Clone());
					team2Wins++;
				}
				else
				{
					sut.SecondTeam.Add(fighter2.Clone());
					team1Wins++;
				}
			}
			var actual = Math.Abs(team1Wins - team2Wins);
			Assert.InRange(actual, 0, 20);
		}

		[Fact]

		public void ArenaFight_ShouldBeBalancedWithMages()
		{
			var sut = new Arena(2, "Moon");
			Fighter fighter1 = new Mage("Scorpion", 1);
			Fighter fighter2 = new Mage("Liu Kang", 1);
			sut.FirstTeam.Add(fighter1.Clone());
			sut.SecondTeam.Add(fighter2.Clone());
			var team1Wins = 0;
			var team2Wins = 0;

			for (int i = 0; i < 100; i++)
			{
				sut.StartTheFight();
				if (sut.FirstTeam.Count == 0)
				{
					sut.FirstTeam.Add(fighter1.Clone());
					team2Wins++;
				}
				else
				{
					sut.SecondTeam.Add(fighter2.Clone());
					team1Wins++;
				}
			}

			var actual = Math.Abs(team1Wins - team2Wins);
			Assert.InRange(actual, 0, 20);
		}

		[Fact]

		public void ArenaFight_ShouldBeBalancedWithMonsters()
		{
			var sut = new Arena(2, "Moon");
			Fighter fighter1 = new Monster("Scorpion", 1);
			Fighter fighter2 = new Monster("Liu Kang", 1);
			sut.FirstTeam.Add(fighter1.Clone());
			sut.SecondTeam.Add(fighter2.Clone());
			var team1Wins = 0;
			var team2Wins = 0;

			for (int i = 0; i < 100; i++)
			{
				sut.StartTheFight();
				if (sut.FirstTeam.Count == 0)
				{
					sut.FirstTeam.Add(fighter1.Clone());
					team2Wins++;
				}
				else
				{
					sut.SecondTeam.Add(fighter2.Clone());
					team1Wins++;
				}
			}

			var actual = Math.Abs(team1Wins - team2Wins);
			Assert.InRange(actual, 0, 20);
		}

		[Fact]

		public void ArenaFight_ShouldBeBalancedWithNinjas()
		{
			var sut = new Arena(2, "Moon");
			Fighter fighter1 = new Ninja("Scorpion", 1);
			Fighter fighter2 = new Ninja("Liu Kang", 1);
			sut.FirstTeam.Add(fighter1.Clone());
			sut.SecondTeam.Add(fighter2.Clone());
			var team1Wins = 0;
			var team2Wins = 0;

			for (int i = 0; i < 100; i++)
			{
				sut.StartTheFight();
				if (sut.FirstTeam.Count == 0)
				{
					sut.FirstTeam.Add(fighter1.Clone());
					team2Wins++;
				}
				else
				{
					sut.SecondTeam.Add(fighter2.Clone());
					team1Wins++;
				}
			}

			var actual = Math.Abs(team1Wins - team2Wins);
			Assert.InRange(actual, 0, 20);
		}

		[Fact]

		public void ArenaFight_ShouldBeBalancedWithNinjasAndMages()
		{
			var sut = new Arena(2, "Moon");
			Fighter fighter1 = new Ninja("Scorpion", 3);
			Fighter fighter2 = new Mage("Liu Kang", 1);
			sut.FirstTeam.Add(fighter1.Clone());
			sut.SecondTeam.Add(fighter2.Clone());
			var team1Wins = 0;
			var team2Wins = 0;

			for (int i = 0; i < 100; i++)
			{
				sut.StartTheFight();
				if (sut.FirstTeam.Count == 0)
				{
					sut.FirstTeam.Add(fighter1.Clone());
					team2Wins++;
				}
				else
				{
					sut.SecondTeam.Add(fighter2.Clone());
					team1Wins++;
				}
			}

			var actual = Math.Abs(team1Wins - team2Wins);
			Assert.InRange(actual, 0, 30);
		}

		[Fact]

		public void ArenaFight_ShouldBeBalancedWithWarriorsAndArchers()
		{
			var sut = new Arena(2, "Moon");
			Fighter fighter1 = new Warrior("Scorpion", 1, 1);
			Fighter fighter2 = new Archer("Liu Kang", 1);
			sut.FirstTeam.Add(fighter1.Clone());
			sut.SecondTeam.Add(fighter2.Clone());
			var team1Wins = 0;
			var team2Wins = 0;

			for (int i = 0; i < 100; i++)
			{
				sut.StartTheFight();
				if (sut.FirstTeam.Count == 0)
				{
					sut.FirstTeam.Add(fighter1.Clone());
					team2Wins++;
				}
				else
				{
					sut.SecondTeam.Add(fighter2.Clone());
					team1Wins++;
				}
			}

			var actual = Math.Abs(team1Wins - team2Wins);
			Assert.InRange(actual, 0, 30);
		}

		[Fact]

		public void ArenaFight_ShouldBeBalancedWithMonstersAndArchers()
		{
			var sut = new Arena(2, "Moon");
			Fighter fighter1 = new Archer("Scorpion", 1);
			Fighter fighter2 = new Monster("Liu Kang", 1);
			sut.FirstTeam.Add(fighter1.Clone());
			sut.SecondTeam.Add(fighter2.Clone());
			var team1Wins = 0;
			var team2Wins = 0;

			for (int i = 0; i < 100; i++)
			{
				sut.StartTheFight();
				if (sut.FirstTeam.Count == 0)
				{
					sut.FirstTeam.Add(fighter1.Clone());
					team2Wins++;
				}
				else
				{
					sut.SecondTeam.Add(fighter2.Clone());
					team1Wins++;
				}
			}

			var actual = Math.Abs(team1Wins - team2Wins);
			Assert.InRange(actual, 0, 30);
		}
	}
}
