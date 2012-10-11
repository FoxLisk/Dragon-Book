using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dragons.Chapter2.Lexer;
using System.IO;

namespace DragonTest.Chapter2.Lexer
{
    [TestClass]
    public class CommentLexerTest
    {
        [TestMethod]
        public void TestLineComments()
        {
            var lex = new CommentLexer(new StringReader("//aasdf"));
            var tok = lex.Scan();
            Assert.IsNull(tok);

            lex = new CommentLexer(new StringReader("true\n//this is a comment\nfalse"));
            tok = lex.Scan();
            Assert.AreEqual(tok.tag, Tag.TRUE);
            tok = lex.Scan();
            Assert.AreEqual(tok.tag, Tag.FALSE);
        }

        [TestMethod]
        public void TestMultiLineComments()
        {
            var lex = new CommentLexer(new StringReader("/*aasdf"));
            var tok = lex.Scan();
            Assert.IsNull(tok);

            lex = new CommentLexer(new StringReader("true/*this is a comment*/false"));
            tok = lex.Scan();
            Assert.AreEqual(tok.tag, Tag.TRUE);
            tok = lex.Scan();
            Assert.AreEqual(tok.tag, Tag.FALSE);
        }
    }
}
