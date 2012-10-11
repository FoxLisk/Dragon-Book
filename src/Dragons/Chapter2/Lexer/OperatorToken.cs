using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dragons.Chapter2.Lexer
{
    public class OperatorToken : Token
    {
        public readonly string _operator;
        public OperatorToken(string _operator)
            : base(Tag.OPERATOR)
        {
            this._operator = _operator;
        }
    }
}
