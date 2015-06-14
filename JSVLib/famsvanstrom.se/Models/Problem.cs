// // famsvanstrom.se: Problem.cs
// // Author: Johan Svanström
// // Created: 2015-05-07
// //
// // Last changed: 2015-06-09
// //
// // Description:

#region

using System.Web.Mvc;

#endregion

namespace famsvanstrom.se.Models
{
    public class Problem
    {
        public Problem(int number, string description)
        {
            Number = number;
            Description = description;
        }

        public int Number { get; private set; }
        [AllowHtml]
        public string Description { get; private set; }
        public string Code { get; set; }
        public string Result { get; set; }
        public string Duration { get; set; }
    }

}