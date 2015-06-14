// // famsvanstrom.se: Problem2.cs
// // Author: Johan Svanström
// // Created: 2015-05-07
// //
// // Last changed: 2015-06-09
// //
// // Description:

#region

using System;
using System.Diagnostics;

#endregion

namespace famsvanstrom.se.Models
{
    public class Problem2 : IProblemSolver
    {
        public Problem Solve()
        {
            var result = new Problem(2, "<p>By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.</p>");
            var start = DateTime.Now.Millisecond;
            Debug.WriteLine(string.Format("start: {0}", start));

            var sum = 0;
            var prev = 1;
            var fibnr = 2;
            while (fibnr < 4000000)
            {
                if (fibnr%2 == 0)
                    sum += fibnr;
                var next = prev + fibnr;
                prev = fibnr;
                fibnr = next;
            }
            result.Result = sum.ToString();
            result.Code = @"var sum = 0;
var prev = 1;
var fibnr = 2;
while (fibnr < 4000000)
{
    if (fibnr%2 == 0)
        sum += fibnr;
    var next = prev + fibnr;
    prev = fibnr;
    fibnr = next;
}
";
            var end = DateTime.Now.Millisecond;
            Debug.WriteLine(string.Format("end: {0}", end));
            result.Duration = string.Format("{0} ms", end - start);
            return result;

        }
    }
}