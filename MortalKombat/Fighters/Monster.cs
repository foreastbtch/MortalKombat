using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortalKombat.Fighters
{
	public class Monster : Fighter
	{
		private int rage;
		private readonly int gradArmura;

		public Monster(string name, int gradArmura) : base(name, 1200, 30, Category.Monster, 5)
		{
			this.gradArmura = gradArmura;
			rage = 0;
			switch (this.gradArmura)
			{
				case 1:
					HP *= 1.75f;
					break;
				case 2:
					HP *= 1.95f;
					break;
				case 3:
					HP *= 2.5f;
					break;
				default:
					HP = HP;
					break;
			}
		}

		public override object Clone()
		{
			return new Monster(Name, gradArmura);
		}

		public override void Deff(float attack, Fighter enemy)
		{
			Console.WriteLine($"{Name} pareaza lovitura lui {enemy.Name} si primeste doar 5% daune");
			//HP -= 0.05f * attack;
			this.GotHit(0.05f * attack);
		}

		public override void SayLine()
		{
			Console.WriteLine("ARGGGHHHH");
		}

		public override void SpecialAbility(Fighter fighter, List<Fighter> enemies)
		{
			if (rage >= 3)
			{
				Console.WriteLine();
				Console.WriteLine($"[SPECIAL ABILITY] {Name} a sarit langa {fighter.Name} si a furat 20% din damage-ul sau.");
				Console.WriteLine();
				Power += fighter.Power * 0.2f;
				fighter.Power -= fighter.Power * 0.2f;
				rage = 0;
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
			rage++;
		}
	}
}
