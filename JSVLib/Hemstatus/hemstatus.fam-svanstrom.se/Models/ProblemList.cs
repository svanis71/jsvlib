using System.Collections.Generic;

namespace hemstatus.fam_svanstrom.se.Models
{
    public class ProblemList : List<Problem>
    {
        private readonly List<IProblemSolver> _problemList;

        public ProblemList()
        {
            _problemList = new List<IProblemSolver>()
                {
                    new Problem1()
                };
        }

        public IEnumerable<Problem> GetResults()
        {
            _problemList.ForEach(p => Add(p.Solve()));
            return this;
        }
    }
}