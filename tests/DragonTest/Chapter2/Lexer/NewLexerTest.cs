using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dragons.Chapter2.Lexer;
using System.IO;

namespace DragonTest.Chapter2.Lexer
{
    [TestClass]
    public class NewLexerTest
    {
        [TestMethod]
        public void TestReservedWords()
        {
            var lex = new NewLexer(new StringReader("true"));
            var token = lex.Scan();
            Assert.AreEqual(token.tag, Tag.TRUE);
            lex = new NewLexer(new StringReader("false"));
            token = lex.Scan();
            Assert.AreEqual(token.tag, Tag.FALSE);
        }

        [TestMethod]
        public void TestIdentifiers()
        {
            var lex = new NewLexer(new StringReader("asdf"));
            var token = lex.Scan();
            Assert.AreEqual(token.tag, Tag.IDENTIFIER);
        }

        [TestMethod]
        public void TestInteger()
        {
            var lex = new NewLexer(new StringReader("123"));
            var token = lex.Scan();
            Assert.AreEqual(token.tag, Tag.INTEGER);
        }
        [TestMethod]
        public void TestEndOfSource()
        {
            var lex = new NewLexer(new StringReader(""));
            var token = lex.Scan();
            Assert.IsNull(token);
        }
    }
}
