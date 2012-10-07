using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dragons.Chapter2.Lexer
{
    public class Token
    {
        public readonly int tag;
        public Token(int t)
        {
            tag = t;
        }
    }
}
