using System;
using System.Collections.Generic;
using System.Text;

namespace MobileAppA.Model
{
    public class Carbonated : Drink
    {
        public Carbonated(string name) : base(name) { }
        public override string Type => nameof(Carbonated);

        public override string Description => $"{Name}, carbonated";
    }
}
