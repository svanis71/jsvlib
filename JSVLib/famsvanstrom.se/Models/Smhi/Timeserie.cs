// // famsvanstrom.se: Timeserie.cs
// // Author: Johan Svanström
// // Created: 2015-06-09
// //
// // Last changed: 2015-06-09
// //
// // Description:

#region

using System;

#endregion

namespace famsvanstrom.se.Models.Smhi
{
    public class Timeserie
    {
        public double gust { get; set; } // Byvind
        public double hcc { get; set; } // Höga moln mängd
        public double lcc { get; set; } // Läga moln mängd
        public double mcc { get; set; } // Medelhöga moln mängd
        public double msl { get; set; } // Lufttryck reducerat till havsytans nivå.
        public double pcat { get; set; } // Nederbördsform
        public double pis { get; set; } // Nederbörd som snö
        public double pit { get; set; } // Nederbörd totalt
        public double r { get; set; } // Luftfuktighet
        public double t { get; set; } // Temp
        public double tcc { get; set; } // Total molnmängd
        public double tstm { get; set; } // Sannolikhet för åska
        public DateTime validTime { get; set; } // Prognostid   
        public double vis { get; set; } // Sikt
        public double wd { get; set; } // Vindriktning
        public double ws { get; set; } // Medelvind
    }
}