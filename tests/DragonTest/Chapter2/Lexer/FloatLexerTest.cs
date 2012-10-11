using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dragons.Chapter2.Lexer;
using System.IO;
using System.Collections.Generic;

namespace DragonTest.Chapter2.Lexer
{
    [TestClass]
    public class FloatLexerTest
    {
        [TestMethod]
        public void TestIntsNotFloats()
        {
            var lex = new FloatLexer(new StringReader("1"));
            var tok = lex.Scan();
            Assert.AreEqual(tok.tag, Tag.INTEGER);
        }

        [TestMethod]
        public void TestFloatsWithNoFractionalPart()
        {
            var lex = new FloatLexer(new StringReader("321."));
            var tok = lex.Scan();
            Assert.AreEqual(tok.tag, Tag.FLOAT);
            Assert.AreEqual(((FloatToken)tok).value, 321.0f);
        }

        [TestMethod]
        public void TestFloatsWithFractionalPart()
        {
            var lex = new FloatLexer(new StringReader("321.32"));
            var tok = lex.Scan();
            Assert.AreEqual(tok.tag, Tag.FLOAT);
            Assert.AreEqual(((FloatToken)tok).value, 321.32f);
        }

    }
}
