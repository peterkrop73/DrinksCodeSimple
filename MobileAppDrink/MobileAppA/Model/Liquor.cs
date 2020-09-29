using System;
using System.Collections.Generic;
using System.Text;

namespace MobileAppA.Model
{
    public class Liquor : Drink
    {
        public Liquor(string name, byte percentOfAlcohol) : base(name)
        {
            PercentOfAlcohol = percentOfAlcohol;
        }

        public override string Type => IsSoft ? "SoftLiquor" : "HardLiquor";
        public override string Description => 
            $"{Name}, {PercentOfAlcohol}%";
        public byte PercentOfAlcohol { get; set; }
        public bool IsSoft => PercentOfAlcohol < 30;
    }
}
