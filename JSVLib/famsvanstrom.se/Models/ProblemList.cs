// // famsvanstrom.se: ProblemList.cs
// // Author: Johan Svanström
// // Created: 2015-05-07
// //
// // Last changed: 2015-06-09
// //
// // Description:

#region

using System.Collections.Generic;

#endregion

namespace famsvanstrom.se.Models
{
    public class ProblemList : List<Problem>
    {
        private readonly List<IProblemSolver> _problemList;

        public ProblemList()
        {
            _problemList = new List<IProblemSolver>()
                {
                    new Problem1(),
                    new Problem2()
                };
        }

        public IEnumerable<Problem> GetResults()
        {
            _problemList.ForEach(p => Add(p.Solve()));
            return this;
        }
    }
}