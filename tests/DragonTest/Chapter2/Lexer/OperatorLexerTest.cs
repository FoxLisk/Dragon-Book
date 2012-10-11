using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dragons.Chapter2.Lexer;
using System.IO;
using System.Collections.Generic;

namespace DragonTest.Chapter2.Lexer
{
    [TestClass]
    public class OperatorLexerTest
    {
        [TestMethod]
        public void TestOperatorsAndInts()
        {
            var lex = new OperatorLexer(new StringReader("1<2=<="));
            var tok = lex.Scan();
            Assert.AreEqual(tok.tag, Tag.INTEGER);
            tok = lex.Scan();
            Assert.AreEqual(tok.tag, Tag.OPERATOR);
            Assert.AreEqual(((OperatorToken)tok)._operator, "<");
            tok = lex.Scan();
            Assert.AreEqual(tok.tag, Tag.INTEGER);
            tok = lex.Scan();
            Assert.AreEqual(tok.tag, '=');
            tok = lex.Scan();
            Assert.AreEqual(tok.tag, Tag.OPERATOR);
            Assert.AreEqual(((OperatorToken)tok)._operator, "<=");
        }
        [TestMethod]
        public void TestAllOperators()
        {
            foreach (var op in new List<String>() { "<", "<=", "==", "!=", ">", ">=" })
            {
                var lex = new OperatorLexer(new StringReader(op));
                var tok = (OperatorToken)lex.Scan();
                Assert.AreEqual(tok.tag, Tag.OPERATOR);
                Assert.AreEqual(tok._operator, op);
            }
        }

    }
}
