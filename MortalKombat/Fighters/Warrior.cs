using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortalKombat.Fighters
{
	internal class Warrior : Fighter, ICloneable
	{
		int GradArmura;//1,2,3
		int GradArma;//1,2,3
		public Warrior(string name, int gradArmura, int gradArma) : base(name, 450, 80, Category.Warrior, 15)
		{
			GradArmura = gradArmura;
			GradArma = gradArma;
			switch (GradArmura)
			{
				case 1:
					HP *= 1.25f;
					break;
				case 2:
					HP *= 1.35f;
					break;
				case 3:
					HP *= 1.5f;
					break;
				default:
					HP = HP;
					break;
			}
			switch (GradArma)
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
			return new Warrior(Name, GradArmura, GradArma);
		}

		public override void Deff(float attack)
		{
			HP -= 0.25f * attack;
		}

		public override void SayLine()
		{
			Console.WriteLine($"{Name}: I am a warrior.");
		}

		public override void SpecialAbility(Fighter fighter)
		{
			var random = new Random();
			if (fighter.GetType() == typeof(Archer))
			{
				Console.WriteLine();
				Console.WriteLine($"[SPECIAL ABILITY] {Name} a sarit langa {fighter.Name} si a aplicat atacul surpriza - {Power * 1.5f} daune");
				fighter.HP -= Power * 1.5f;
			}
			/*else
			{
				float daune1 = random.Next((int)Power / 3, (int)Power);
				Console.WriteLine($"1. {Name} a cauzat {daune1} daune lui {fighter.Name}!");
				fighter.HP -= daune1;
			}*/
		}
	}
}
