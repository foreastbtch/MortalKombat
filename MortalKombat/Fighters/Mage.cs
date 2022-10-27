using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortalKombat.Fighters
{
	public class Mage : Fighter
	{
		private readonly int gradMagie;
		private int mana = 100;

		public Mage(string name, int gradMagie) : base(name, 2000, 100, Category.Mage, 35)
		{
			this.gradMagie = gradMagie;
			switch (this.gradMagie)
			{
				case 1:
					Power *= 1.2f;
					break;
				case 2:
					Power *= 1.3f;
					break;
				case 3:
					Power *= 1.7f;
					break;
				default:
					Power = Power;
					break;
			}
		}

		public override object Clone()
		{
			return new Mage(Name, gradMagie);
		}

		public override void Deff(float attack, Fighter enemy)
		{
			Console.WriteLine($"{Name} absoarbe daunele primite de la {enemy.Name} si isi creste viata cu 50% din atacul primit.");
			HP += 0.5f * attack;
			mana -= 20;
		}

		public override void SayLine()
		{
			Console.WriteLine("I like magic!");
		}

		public override void SpecialAbility(Fighter fighter, List<Fighter> enemies)
		{
			if (mana >= 20)
			{
				Console.WriteLine();
				Console.WriteLine($"[SPECIAL ABILITY] {Name} a aplicat abilitatea speciala, meditand si crescandu-si puterea cu 5%");
				Console.WriteLine();
				Power += Power * 0.05f;
				mana -= 20;
			}
			else
			{
				var random = new Random();
				float daune1 = random.Next((int)Power / 3, (int)Power);
				Console.WriteLine($"Special ability. {Name} a cauzat {daune1} daune lui {fighter.Name}!");
				//fighter.HP -= daune1;
				fighter.GotHit(daune1);
			}
		}

		public override void GotHit(float damage)
		{
			HP -= damage;
		}
	}
}
