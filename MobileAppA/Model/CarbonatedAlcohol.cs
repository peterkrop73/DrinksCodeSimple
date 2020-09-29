using System;
using System.Collections.Generic;
using System.Text;

namespace MobileAppA.Model
{
    public class CarbonatedAlcohol : Carbonated
    {
        public CarbonatedAlcohol(string name, byte percentOfAlcohol) : base(name)
        {
            PercentOfAlcohol = percentOfAlcohol;
        }

        public override string Type => nameof(CarbonatedAlcohol);
        public override string Description => $"{base.Description}, {PercentOfAlcohol}%";
        public byte PercentOfAlcohol { get; set; }
    }
}
