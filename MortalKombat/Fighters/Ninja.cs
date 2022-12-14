namespace MortalKombat.Fighters
{
	public class Ninja : Fighter
	{
		private readonly int gradShuriken;

		public Ninja(string name, int gradShuriken) : base(name, 2000, 60, Category.Ninja, 50)
		{
			this.gradShuriken = gradShuriken;
			switch (this.gradShuriken)
			{
				case 1:
					Power *= 1.75f;
					break;
				case 2:
					Power *= 1.95f;
					break;
				case 3:
					//2.1
					Power *= 2.15f;
					break;
				default:
					Power = Power;
					break;
			}
		}

		public override Fighter Clone()
		{
			return new Ninja(Name, gradShuriken);
		}

		public override void Deff(float attack, Fighter enemy)
		{
			if (2 * Agility < attack)
			{
				Console.WriteLine($"{Name} pareaza lovitura lui {enemy.Name} si primeste 70% damage");
				this.GotHit(0.7f * attack);
			}
			else
			{
				Console.WriteLine($"{Name} se fereste de atacul lui {enemy.Name} si nu primeste damage datorita agilitatii.");
			}
		}

		public override void GotHit(float damage)
		{
			HP -= damage;
		}

		public override void SayLine()
		{
			Console.WriteLine("SHHHH!");
		}

		public override void SpecialAbility(Fighter fighter, List<Fighter> enemies)
		{
			if (Agility > 1.5f * fighter.Agility)
			{
				Console.WriteLine();
				Console.WriteLine($"[SPECIAL ABILITY] {Name} a sarit langa {fighter.Name} si a aplicat atacul dublu - {Power * 2f} daune");
				Console.WriteLine();
				fighter.GotHit(2 * Power);
			}
			else
			{
				var random = new Random();
				float daune1 = random.Next((int)Power / 3, (int)Power);
				Console.WriteLine($"Special ability. {Name} a cauzat {daune1} daune lui {fighter.Name}!");
				fighter.GotHit(daune1);
			}
		}
	}
}
