using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortalKombat
{
    internal abstract class Fighter : ICloneable
    {
        public string Name { get; set; }
        public float HP { get; set; }
        public float Power { get; set; }
        public Category Category { get; set; }

        public int Agility { get; set; }// 0 - 50

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

        public abstract object Clone();
        /*{
            return new Fighter(Name, HP, Power, Category);
        }*/
        public abstract void SpecialAbility(Fighter fighter);
        public abstract void Deff(float attack);
        public abstract void SayLine();
    }
}
