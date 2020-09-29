using System;
using System.Collections.Generic;
using System.Text;

namespace MobileAppA.Model
{
    public class Drink
    {
        public Drink(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public virtual string Type => nameof(Drink);
        public virtual string Description => $"{Name}, not carbonated";

        public override string ToString() => Description;
    }
}
