using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dragons.Chapter2;

namespace DragonTest
{
    [TestClass]
    public class _241Test
    {
        [TestMethod]
        public void TestTrivialParsing()
        {
            var parser = new _241("+aa");
            parser.Parse();
            parser = new _241("-aa");
            parser.Parse();
        }

        [TestMethod]
        public void TestCombinedParsing()
        {
            var parser = new _241("+a-aa");
            parser.Parse();
        }

        [TestMethod]
        public void TestFailInvalidInput()
        {
            var parser = new _241("++a");
            try
            {
                parser.Parse();
                Assert.Fail();
                Console.WriteLine("try");
            }
            catch (InvalidSyntaxException)
            {
                Console.WriteLine("Catch");
                return;
            }
        }
    }
}
