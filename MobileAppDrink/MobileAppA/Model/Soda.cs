using System;
using System.Collections.Generic;
using System.Text;

namespace MobileAppA.Model
{
    public class Soda : Carbonated
    {
        public Soda(string name, bool isDiet) : base(name)
        {
            IsDiet = isDiet;
        }

        public override string Type => nameof(Soda);
        public override string Description
        {
            get
            {
                var description = base.Description;
                if (IsDiet)
                    description += ", diet";
                return description;
            }
        }
        public bool IsDiet { get; set; }
    }
}
