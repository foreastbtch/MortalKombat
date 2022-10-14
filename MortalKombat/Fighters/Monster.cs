using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortalKombat.Fighters
{
	internal class Monster : Fighter
	{
		int rage;
		public int GradArmura;

		public Monster(string name, int gradArmura) : base(name, 5000, 50, Category.Monster, 5)
		{
			GradArmura = gradArmura;
			rage = 0;
			switch (GradArmura)
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
			return new Monster(Name, GradArmura);
		}

		public override void Deff(float attack, Fighter enemy)
		{
			Console.WriteLine($"{Name} pareaza lovitura lui {enemy.Name} si primeste doar 5% daune");
			HP -= 0.05f * attack;
			//rage += 1;
		}

		public override void SayLine()
		{
			Console.WriteLine("ARGGGHHHH");
		}

		public override void SpecialAbility(Fighter fighter, List<Fighter> enemies)
		{
			//fura 20% din puterea adversarului
			if (rage >= 3)
			{
				Console.WriteLine();
				Console.WriteLine($"[SPECIAL ABILITY] {Name} a sarit langa {fighter.Name} si a furat 20% din damage-ul sau.");
				Console.WriteLine();
				Power += fighter.Power * 0.2f;
				fighter.Power -= fighter.Power * 0.2f;
				rage = 0;
			}
		}

		public override void GotHit(Fighter fighter)
		{
			rage++;
		}
	}
}
