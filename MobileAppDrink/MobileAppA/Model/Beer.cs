using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MobileAppA.Model
{
    public enum BeerType
    {
        [Description("PaleLager and Pilsner")]
        PaleLagerAndPilsner,

        [Description("Dark Lager")]
        DarkLager,

        [Description("German Bock")]
        GermanBock,

        [Description("Brown Ale")]
        BrownAle,

        [Description("Pale Ale")]
        PaleAle,

        [Description("India Pale Ale")]
        IndiaPaleAle,

        [Description("Porter")]
        Porter,

        [Description("Stout")]
        Stout,

        [Description("Belgian-Style Ale")]
        BelgianStyleAle,

        [Description("WheatBeer")]
        WheatBeer,

        [Description("Wild & Sour Ale")]
        WildAndSourAle
    }

    public class Beer : CarbonatedAlcohol
    {
        public Beer(string name, byte percentOfAlcohol, BeerType subtype) : base(name, percentOfAlcohol)
        {
            Subtype = subtype;
        }

        public override string Type => nameof(Beer);
        public override string Description =>
            $"{base.Description}, {SubtypeToDescriptionString}";
        public BeerType Subtype { get; set; }

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
