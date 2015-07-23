using System.Web.Mvc;

namespace hemstatus.fam_svanstrom.se.Models
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