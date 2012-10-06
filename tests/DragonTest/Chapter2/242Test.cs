using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dragons.Chapter2;
using System.Collections.Generic;

namespace DragonTest
{
    [TestClass]
    public class _242Test
    {
        [TestMethod]
        public void TestSuccesses()
        {
            List<String> validStrings = new List<String>()
            {
                "","()", "()()", "()(()())", "(())((((()))))","(()(()(()(()))))"
            };
            foreach (var code in validStrings)
            {
                var parser = new _242(code);
                parser.Parse();
            }
        }


        [TestMethod]
        public void TestFailures()
        {
            var invalidStrings = new List<String>() {
            "(", ")", "())", "(()", ")("
            };
            foreach (var code in invalidStrings)
            {
                try
                {
                    new _242(code).Parse();
                    Assert.Fail();
                }
                catch (InvalidSyntaxException)
                {
                }
            }
        }
    }
}
