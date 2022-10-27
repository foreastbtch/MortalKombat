using Moq;
using MortalKombat;
using MortalKombat.Fighters;
using System;
using Xunit;

namespace UnitTests
{
	public class FighterTests
	{
		[Fact]
		public void ArcherConstructor_ShouldInitializePowerWith100WhenGradArcIs0()
		{
			//arrange
			var sut = new MortalKombat.Fighters.Archer("Test", 0);

			//act
			var actual = sut.Power;

			//assert
			Assert.Equal(100, actual);
		}

		[Fact]
		public void ArcherConstructor_ShouldInitializePowerWith125WhenGradArcIs1()
		{
			//arrange
			var sut = new MortalKombat.Fighters.Archer("Test", 1);

			//act
			var actual = sut.Power;

			//assert
			Assert.Equal(125, actual);
		}

		[Fact]
		public void ArcherConstructor_ShouldInitializePowerWith135WhenGradArcIs2()
		{
			//arrange
			var sut = new MortalKombat.Fighters.Archer("Test", 2);

			//act
			var actual = sut.Power;

			//assert
			Assert.Equal(135, actual);
		}

		[Fact]
		public void ArcherConstructor_ShouldInitializePowerWith150WhenGradArcIs3()
		{
			//arrange
			var sut = new MortalKombat.Fighters.Archer("Test", 3);

			//act
			var actual = sut.Power;

			//assert
			Assert.Equal(150, actual);
		}

		[Fact]
		public void ArcherDeff_ShouldGive10PercentOfPowerDamage()
		{
			//arrange
			var mock = new Mock<Warrior>();
			var sut = new MortalKombat.Fighters.Archer("Test", 3);
			var hp = sut.HP;
			sut.Deff(100, mock.Object);

			//act
			var actual = sut.HP;

			//assert
			Assert.Equal(hp - 10, actual);
		}

		[Fact]
		public void ArcherClone_ShouldCreateCopy()
		{
			var sut = new Archer("Test", 3);
			var sut2 = (Archer)sut.Clone();

			var actual = sut.Power == sut2.Power && sut.HP == sut2.HP && sut.Name == sut2.Name && sut.Agility == sut2.Agility && sut.Category == sut2.Category && !sut.Equals(sut2);

			Assert.True(actual);
		}

		[Fact]
		public void ArcherClone_ShouldCreateDeepCopy()
		{
			var sut = new Archer("Test", 3);
			var sut2 = (Archer)sut.Clone();

			sut2.Power = -1;
			sut2.Agility = 0;
			sut2.Category = Category.Assassin;
			sut2.HP = -1;
			sut2.Name = "Test2";

			var actual = sut.Power != sut2.Power && sut.HP != sut2.HP && sut.Name != sut2.Name && sut.Agility != sut2.Agility && sut.Category != sut2.Category && !sut.Equals(sut2);

			Assert.True(actual);
		}

		[Fact]
		public void ArcherSpecialAbility_ShouldFocusWarrior()
		{
			var sut = new Archer("Test", 3);
			var warrior = new Warrior("Warrior", 0, 0);
			var enemyHP = warrior.HP - 2 * sut.Power;

			sut.SpecialAbility(warrior, new List<Fighter>());
			var actual = warrior.HP;
			Assert.Equal(enemyHP, actual);
		}

		[Fact]
		public void ArcherSpecialAbility_ShouldMultiShotIfEnemyTeamCountIsGreaterThan1()
		{
			var sut = new Archer("Test", 3);
			var enemy1 = new Mage("Mage1", 0);
			var enemy2 = new Monster("Monster1", 0);
			var enemy3 = new Ninja("Ninja1", 0);
			var hpEnemy1 = enemy1.HP - 1 / 4f * sut.Power;
			var hpEnemy2 = enemy2.HP - 1 / 4f * sut.Power;
			var hpEnemy3 = enemy3.HP - 1 / 4f * sut.Power;
			List<Fighter> list = new List<Fighter>();
			list.Add(enemy1);
			list.Add(enemy2);
			list.Add(enemy3);

			sut.SpecialAbility(enemy1, list);

			var actual = hpEnemy1 == enemy1.HP && hpEnemy2 == enemy2.HP && hpEnemy3 == enemy3.HP;

			Assert.True(actual);
		}

		[Fact]
		public void MageDeff_ShouldHeal50PercentOfPowerDamage()
		{
			//arrange
			var mock = new Mock<Warrior>();
			var sut = new MortalKombat.Fighters.Mage("Test", 3);
			var hp = sut.HP;
			sut.Deff(100, mock.Object);

			//act
			var actual = sut.HP;

			//assert
			Assert.Equal(hp + 0.5f * 100, actual);
		}

		[Fact]
		public void MageSpecialAbility_ShouldIncreasePowerWith5Percent()
		{
			//arrange
			var mock = new Mock<Warrior>();
			var sut = new MortalKombat.Fighters.Mage("Test", 3);
			var power = sut.Power;
			sut.SpecialAbility(mock.Object, new List<Fighter>());

			//act
			var actual = sut.Power;

			//assert
			Assert.Equal(1.05f * power, actual, 0.0001);
		}

		[Fact]
		public void MonsterDeff_ShouldTake5PercentOfPowerDamage()
		{
			//arrange
			var mock = new Mock<Warrior>();
			var sut = new MortalKombat.Fighters.Monster("Test", 3);
			var hp = sut.HP;
			sut.Deff(100, mock.Object);

			//act
			var actual = sut.HP;

			//assert
			Assert.Equal(hp - 0.05f * 100, actual);
		}

		[Fact]
		public void MonsterSpecialAbility_ShouldSteal20PercentOfEnemyPower()
		{
			//arrange
			var enemy = new Warrior("enemy", 0, 0);
			var sut = new MortalKombat.Fighters.Monster("Test", 3);
			var power = sut.Power;
			var enemyPower = enemy.Power;
			sut.GotHit(0);
			sut.GotHit(0);
			sut.GotHit(0);

			sut.SpecialAbility(enemy, new List<Fighter>());

			//act
			var actualPower = sut.Power;
			var actualEnemyPower = enemy.Power;
			var actual = (actualPower == power + 0.2 * enemyPower) && (actualEnemyPower == enemyPower - 0.2 * enemyPower);

			//assert
			Assert.True(actual);
		}

		[Fact]
		public void NinjaDeff_ShouldDodge()
		{
			//arrange
			var enemy = new Warrior();
			//enemy.Agility = 0;
			var sut = new MortalKombat.Fighters.Ninja("Test", 3);
			var hp = sut.HP;
			sut.Deff(100, enemy);

			//act
			var actual = sut.HP;

			//assert
			Assert.Equal(hp, actual);
		}

		[Fact]
		public void NinjaDeff_ShouldDefend()
		{
			//arrange
			var enemy = new Warrior();
			var sut = new MortalKombat.Fighters.Ninja("Test", 3);
			var hp = sut.HP;
			sut.Deff(105, enemy);

			//act
			var actual = sut.HP;

			//assert
			Assert.Equal(hp - 0.7 * 105, actual);
		}

		[Fact]
		public void NinjaSpecialAbility_ShouldGiveDoubleDamageBasedOnAgility()
		{
			//arrange
			var enemy = new Warrior("enemy", 0, 0);
			enemy.Agility = 0;
			var sut = new MortalKombat.Fighters.Ninja("Test", 3);
			var hp = enemy.HP;

			sut.SpecialAbility(enemy, new List<Fighter>());

			//act
			var actual = enemy.HP;

			//assert
			Assert.Equal(hp - 2 * sut.Power, actual);
		}

		[Fact]
		public void WarriorDeff_ShouldTake25PercentOfPowerDamage()
		{
			//arrange
			var mock = new Mock<Warrior>();
			var sut = new MortalKombat.Fighters.Warrior("Test", 3, 3);
			var hp = sut.HP;
			sut.Deff(100, mock.Object);

			//act
			var actual = sut.HP;

			//assert
			Assert.Equal(hp - 0.25f * 100, actual);
		}

		[Fact]
		public void WarriorSpecialAbility_ShouldFocusArcher()
		{
			var sut = new Warrior("Test", 3, 3);
			var archer = new Archer("Archer", 0);
			var enemyHP = archer.HP;

			sut.SpecialAbility(archer, new List<Fighter>());
			var actual = archer.HP;

			Assert.Equal(enemyHP - 1.5f * sut.Power, actual);
		}
	}
}