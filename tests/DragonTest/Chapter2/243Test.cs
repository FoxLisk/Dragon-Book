using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dragons.Chapter2;
using System.Collections.Generic;

namespace DragonTest
{
    [TestClass]
    public class _243Test
    {
        [TestMethod]
        public void TestSuccseses()
        {
            List<String> validStrings = new List<String>()
            {
                "01", "0011"
            };
            foreach (var code in validStrings)
            {
                new _243(code).Parse();
            }
        }


        [TestMethod]
        public void TestFailures()
        {
            var invalidStrings = new List<String>() {
            "", "0", "00", "011", "00111"
            };
            foreach (var code in invalidStrings)
            {
                try
                {
                    new _243(code).Parse();
                    Assert.Fail();
                }
                catch (InvalidSyntaxException)
                {
                }
            }
        }
    }
}
