using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Dragons.Chapter2.Lexer
{
    /// <summary>
    /// This extends the lexer to ignore // and /* */ comments.
    /// </summary>
    public class CommentLexer : NewLexer
    {
        public CommentLexer(TextReader source) : base(source) { }

        /// <summary>
        /// Scans the input and returns the next token
        /// </summary>
        /// <returns>Token</returns>
        public Token Scan()
        {
            if (EndOfSource())
            {
                return null;
            }
            do
            {
                if (peek == ' ' || peek == '\t')
                {
                    continue;
                }
                else if (peek == '\n')
                {
                    ++line;
                }
                else if (peek == '/')
                {
                    if ((char)sourceStream.Peek() == '/')
                    {
                        AdvancePeek();
                        while (peek != '\n' && !EndOfSource())
                        {
                            AdvancePeek();
                        }
                    }
                    else if ((char)sourceStream.Peek() == '*')
                    {
                        AdvancePeek();
                        while (!EndOfSource())
                        {
                            AdvancePeek();
                            if (peek == '*' && (char)sourceStream.Peek() == '/')
                            {
                                AdvancePeek();
                                break;
                            }
                        }
                    }
                }
                else
                {
                    break;
                }
                AdvancePeek();
            } while (true);
            return BuildToken();
        }
    }
}
