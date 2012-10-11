using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Dragons.Chapter2.Lexer
{
    /// <summary>
    /// This extends the lexer to account for &lt;, &lt;=, ==, !=, >=, >
    /// </summary>
    public class OperatorLexer : NewLexer
    {
        public OperatorLexer(TextReader source) : base(source) { }

        override protected Token BuildToken()
        {
            if (peek == '<' || peek == '>')
            {
                if ((char)sourceStream.Peek() == '=')
                {
                    Token t = new OperatorToken(peek + "=");
                    AdvancePeek();
                    AdvancePeek();
                    return t;
                }
                else
                {
                    Token t = new OperatorToken(peek.ToString());
                    AdvancePeek();
                    return t;
                }
            }
            else if (peek == '!' || peek == '=')
            {
                if ((char)sourceStream.Peek() == '=')
                {
                    Token t = new OperatorToken(peek + "=");
                    AdvancePeek();
                    AdvancePeek();
                    return t;
                }
            }
            return base.BuildToken();
        }
    }
}
