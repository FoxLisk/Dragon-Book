using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dragons.Chapter2.Lexer
{
    public class FloatToken : Token
    {
        public readonly float value;
        public FloatToken(float value)
            : base(Tag.FLOAT)
        {
            this.value = value;
        }
    }
}
