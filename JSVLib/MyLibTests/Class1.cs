using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib.Extensions;
using NUnit.Framework;

namespace MyLibTests
{
    [TestFixture]
    public class Class1
    {
        private const string EmptyString = "";
        private const string WhitespaceOnlyString = "   ";
        private const string NonEmptyString = "ABCDEFGH";

        [Test]
        public void TestNullOrEmptyReturnsFalseForNoEmptyString()
        {
           Assert.False(NonEmptyString.NullOrEmpty());     
        }

        [Test]
        public void TestNullOrEmptyReturnsTrueForEmptyString()
        {
            Assert.True(EmptyString.NullOrEmpty());
        }

        [Test]
        public void TestNullOrEmptyReturnsTrueForEmptyStringWithWhiteSpaceWithTrim()
        {
            Assert.True(WhitespaceOnlyString.NullOrEmpty(trim: true));
        }

        [Test]
        public void TestNullOrEmptyReturnsFalseForEmptyStringWithWhiteSpace()
        {
            Assert.False(WhitespaceOnlyString.NullOrEmpty());
        }

        [Test]
        public void TestLeft()
        {
            Assert.AreEqual("ABC", NonEmptyString.Left(3));
        }

        [Test]
        public void TestLeftWithEmptyString()
        {
            Assert.AreEqual(EmptyString, EmptyString.Left(3));
        }

        [Test]
        public void TestLeftWithNumberGreaterThanLength()
        {
            Assert.AreEqual(NonEmptyString, NonEmptyString.Left(NonEmptyString.Length + 1));
        }
    }
}
