using System;
using Xunit;
using playwithcanvas.Controllers;

namespace playwithcanvas.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()
        {
            HomeController c = new HomeController();
            var result = c.Breakout();
            
            Console.WriteLine(result.ToString());
        }

        [Fact]
        public void TestMethod2()
        {
            HomeController c = new HomeController();
            var result = c.Scroller();

            Console.WriteLine(result.ToString());
        }
    }
}
