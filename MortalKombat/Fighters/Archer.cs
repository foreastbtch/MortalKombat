using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortalKombat.Fighters
{
	internal class Archer : Fighter, ICloneable
	{
		int GradArc;

		public Archer(string name, int gradArc) : base(name, 280, 150, Category.Archer, 30)
		{
			GradArc = gradArc;
			switch (GradArc)
			{
				case 1:
					Power *= 1.25f;
					break;
				case 2:
					Power *= 1.35f;
					break;
				case 3:
					Power *= 1.5f;
					break;
				default:
					Power = Power;
					break;
			}
		}
		public override object Clone()
		{
			return new Archer(Name, GradArc);
		}

		public override void Deff(float attack)
		{
			HP -= 0.1f * attack;
		}

		public override void SayLine()
		{
			Console.WriteLine($"{Name}: Let's fight!");
		}

		public override void SpecialAbility(Fighter fighter)
		{
			if(fighter.GetType() == typeof(Warrior))
			{
				Console.WriteLine();
				Console.WriteLine($"[SPECIAL ABILITY] {Name} a aplicat lovitura speciala, lansand un atac dublu asupra lui {fighter.Name} - {Power * 2f} daune");
				fighter.HP -= Power * 2f;
			}
		}
	}
}
