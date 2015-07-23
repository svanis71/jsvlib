using System;
using System.Diagnostics;

namespace hemstatus.fam_svanstrom.se.Models
{
    public class Problem1 : IProblemSolver
    {
        public Problem Solve()
        {
            var result = new Problem(1, "<p>If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.</p><p>Find the sum of all the multiples of 3 or 5 below 1000.</p>");
            var start = DateTime.Now.Millisecond;
            Debug.WriteLine(string.Format("start: {0}", start));
            var sum = 0;
            for (var i = 0; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
            result.Code = @"var sum = 0;
for (var i = 0; i < 1000; i++)
{
    if (i % 3 == 0 || i % 5 == 0)
    {
        sum += i;
    }
}
";
            result.Result = sum.ToString();
            var end = DateTime.Now.Millisecond;
            Debug.WriteLine(string.Format("end: {0}", end));
            result.Duration = string.Format("{0} ms", end - start);
            return result;
        }
    }
}