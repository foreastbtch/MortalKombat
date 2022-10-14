﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortalKombat.Fighters
{
	internal class Archer : Fighter, ICloneable
	{
		int GradArc;

		public Archer(string name, int gradArc) : base(name, 2800, 100, Category.Archer, 30)
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

		public override void Deff(float attack, Fighter enemy)
		{
			Console.WriteLine($"{Name} se fereste de atacul lui {enemy.Name} si primeste doar 10% damage");
			HP -= 0.1f * attack;
		}

		public override void GotHit(Fighter fighter)
		{
			
		}

		public override void SayLine()
		{
			Console.WriteLine($"{Name}: Let's fight!");
		}

		public override void SpecialAbility(Fighter fighter, List<Fighter> enemies)
		{
			var random = new Random();
			if (fighter.GetType() == typeof(Warrior))
			{
				Console.WriteLine();
				Console.WriteLine($"[SPECIAL ABILITY] {Name} a aplicat lovitura speciala, lansand un atac dublu asupra lui {fighter.Name} - {Power * 2f} daune");
				Console.WriteLine();
				fighter.HP -= Power * 2f;
			}
			else
			{
				if (enemies.Count > 1)
				{
					Console.WriteLine();
					Console.WriteLine($"[SPECIAL ABILITY] {Name} a aplicat lovitura speciala, realizand un atac MULTISHOT impotriva intregii echipe inamice - {Power / 4} daune pentru fiecare inamic");
					Console.WriteLine();
					MultiShot(enemies, Power / 4);
				}
				else
				{
					float daune1 = random.Next((int)Power / 3, (int)Power);
					Console.WriteLine($"Special ability. {Name} a cauzat {daune1} daune lui {fighter.Name}!");
					fighter.HP -= daune1;
				}
			}
		}

		public void MultiShot(List<Fighter> enemies, float damage)
		{
			foreach(Fighter fighter in enemies)
			{
				fighter.HP -= damage;
			}
		}
	}
}