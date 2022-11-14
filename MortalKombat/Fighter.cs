namespace MortalKombat
{
	public abstract class Fighter
	{
		public string Name { get; set; }
		public float HP { get; set; }
		public float Power { get; set; }
		public Category Category { get; set; }

		public int Agility { get; set; }

		public Fighter()
		{
			Name = "";
			HP = 0;
			Power = 0;
			Category = new Category();
			Agility = 0;
		}

		public Fighter(string name, float hp, float power, Category category, int agility)
		{
			Name = name;
			HP = hp;
			Power = power;
			Category = category;
			Agility = agility;
		}

		public abstract Fighter Clone();
		public abstract void SpecialAbility(Fighter fighter, List<Fighter> enemies);
		public abstract void Deff(float attack, Fighter enemy);
		public abstract void SayLine();
		public abstract void GotHit(float damage);
	}
}
