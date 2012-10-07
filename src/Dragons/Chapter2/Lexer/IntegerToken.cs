using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dragons.Chapter2.Lexer
{
    public class IntegerToken : Token
    {
        public readonly int value;
        public IntegerToken(int value)
            : base(Tag.INTEGER)
        {
            this.value = value;
        }
    }
}
