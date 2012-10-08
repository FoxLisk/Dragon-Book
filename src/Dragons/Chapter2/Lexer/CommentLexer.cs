using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Dragons.Chapter2.Lexer
{
    class CommentLexer : NewLexer
    {
        public CommentLexer(TextReader source) : base(source) { }

        /// <summary>
        /// Scans the input and returns the next token
        /// </summary>
        /// <returns>Token</returns>
        public Token Scan()
        {
            int next = sourceStream.Peek();
            if (next == -1)
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
                    if ((char)next == '/')
                    {
                        AdvancePeek();
                        while (peek != '\n')
                        {
                            AdvancePeek();
                        }
                    }
                    else if ((char)next == '*')
                    {
                        AdvancePeek();
                        while (true)
                        {
                            AdvancePeek();
                            if (peek == '*' && (char)sourceStream.Peek() == '/')
                            {
                                AdvancePeek();
                            }
                            break;
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
