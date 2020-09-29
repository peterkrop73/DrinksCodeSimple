using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MobileAppA.Model
{
    public enum SparklingWineType
    {
        [Description("Extra Brut")]
        ExtraBrut,

        [Description("Brut")]
        Brut,

        [Description("Extra Dry ")]
        ExtraDry,

        [Description("Demi-Sec")]
        DemiSec,
    }

    public class SparklingWine : CarbonatedAlcohol
    {
        public SparklingWine(string name, byte percentOfAlcohol, SparklingWineType subtype) : base(name, percentOfAlcohol)
        {
            Subtype = subtype;
        }

        public override string Type => nameof(SparklingWine);
        public override string Description =>
            $"{base.Description}, {SubtypeToDescriptionString}";
        public SparklingWineType Subtype { get; set; }

        private string SubtypeToDescriptionString
        {
            get
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])Subtype
                    .GetType()
                    .GetField(Subtype.ToString())
                    .GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attributes.Length > 0 ? attributes[0].Description : string.Empty;
            }
        }
    }
}
