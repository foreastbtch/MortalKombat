using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortalKombat
{
    internal class Fighter : ICloneable
    {
        public string Name { get; set; }
        public float HP { get; set; }
        public float Power { get; set; }
        public Category Category { get; set; }

        public Fighter()
        {
            Name = "";
            HP = 0;
            Power = 0;
            Category = new Category();
        }

        public Fighter(string name, float hp, float power, Category category)
        {
            Name = name;
            HP = hp;
            Power = power;
            Category = category;
        }

        public object Clone()
        {
            return new Fighter(Name, HP, Power, Category);
        }
    }
}
