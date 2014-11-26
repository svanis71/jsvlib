using JSVLib.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JSVLib.Test
{
    [TestClass]
    public class StringExtensionTests
    {
        [TestMethod]
        public void TestLShift1()
        {
            const string s = "ABCD";
            const string expected = "BCDA";
            Assert.AreEqual(expected, s.LShift());
        }

        [TestMethod]
        public void TestLShift3()
        {
            const string s = "ABCDEFG";
            const string expected = "DEFGABC";
            Assert.AreEqual(expected, s.LShift(3));
        }

        private const string EmptyString = "";
        private const string WhitespaceOnlyString = "   ";
        private const string NonEmptyString = "ABCDEFGH";

        [TestMethod]
        public void TestNullOrEmptyReturnsFalseForNoEmptyString()
        {
            Assert.IsFalse(NonEmptyString.NullOrEmpty());
        }

        [TestMethod]
        public void TestNullOrEmptyReturnsTrueForEmptyString()
        {
            Assert.IsTrue(EmptyString.NullOrEmpty());
        }

        [TestMethod]
        public void TestNullOrEmptyReturnsTrueForEmptyStringWithWhiteSpaceWithTrim()
        {
            Assert.IsTrue(WhitespaceOnlyString.NullOrEmpty(trim: true));
        }

        [TestMethod]
        public void TestNullOrEmptyReturnsFalseForEmptyStringWithWhiteSpace()
        {
            Assert.IsFalse(WhitespaceOnlyString.NullOrEmpty());
        }

        [TestMethod]
        public void TestLeft()
        {
            Assert.AreEqual("ABC", NonEmptyString.Left(3));
        }

        [TestMethod]
        public void TestLeftWithEmptyString()
        {
            Assert.AreEqual(EmptyString, EmptyString.Left(3));
        }

        [TestMethod]
        public void TestLeftWithNumberGreaterThanLength()
        {
            Assert.AreEqual(NonEmptyString, NonEmptyString.Left(NonEmptyString.Length + 1));
        }

    }
}
