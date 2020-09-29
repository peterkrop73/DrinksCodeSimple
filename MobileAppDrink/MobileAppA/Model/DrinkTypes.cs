using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MobileAppA.Model
{
    public enum DrinkType
    {
        [Description("Soda")]
        Soda,

        [Description("Juice")]
        Juice,

        [Description("Beer")]
        Beer,

        [Description("Sparkling Wine")]
        SparklingWine,

        [Description("Liquor")]
        Liquor
    }
}
