namespace MortalKombat.Fighters
{
	public class Warrior : Fighter
	{
		private readonly int gradArmura;
		private readonly int gradArma;

		public Warrior() : base()
		{

		}
		public Warrior(string name, int gradArmura, int gradArma) : base(name, 3500, 80, Category.Warrior, 15)
		{
			this.gradArmura = gradArmura;
			this.gradArma = gradArma;
			switch (this.gradArmura)
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
			switch (this.gradArma)
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
		public override Fighter Clone()
		{
			return new Warrior(Name, gradArmura, gradArma);
		}

		public override void Deff(float attack, Fighter enemy)
		{
			Console.WriteLine($"{Name} pareaza lovitura lui {enemy.Name} si primeste doar 25% damage");
			this.GotHit(0.25f * attack);
		}

		public override void GotHit(float damage)
		{
			HP -= damage;
		}

		public override void SayLine()
		{
			Console.WriteLine($"{Name}: I am a warrior.");
		}

		public override void SpecialAbility(Fighter fighter, List<Fighter> enemies)
		{
			var random = new Random();
			if (fighter.GetType() == typeof(Archer))
			{
				Console.WriteLine();
				Console.WriteLine($"[SPECIAL ABILITY] {Name} a sarit langa {fighter.Name} si a aplicat atacul surpriza - {Power * 1.5f} daune");
				Console.WriteLine();
				fighter.GotHit(Power * 1.5f);
			}
			else
			{
				float daune1 = random.Next((int)Power / 3, (int)Power);
				Console.WriteLine($"Special ability. {Name} a cauzat {daune1} daune lui {fighter.Name}!");
				fighter.GotHit(daune1);
			}
		}
	}
}
