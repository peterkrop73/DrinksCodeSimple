using System;
using System.Collections.Generic;
using System.Text;

namespace MobileAppA.Model
{
    public class Juice : Drink
    {
        public Juice(string name, string frouitsMadeFrom) : base(name)
        {
            FrouitsMadeFrom = frouitsMadeFrom;
        }

        public override string Type => nameof(Juice);
        public override string Description => 
               $"{Name} Juice, not carbonated, made from {FrouitsMadeFrom}"; // carbonated juice is soda
        public string FrouitsMadeFrom { get; set; }
    }
}
