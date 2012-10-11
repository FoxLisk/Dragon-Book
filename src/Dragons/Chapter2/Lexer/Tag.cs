using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dragons.Chapter2.Lexer
{
    public sealed class Tag
    {
        public static readonly int
            INTEGER = 256, IDENTIFIER = 257, TRUE = 258, FALSE = 259, OPERATOR = 260, FLOAT = 261;
    }
}
