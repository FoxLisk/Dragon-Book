using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dragons.Chapter2.Lexer
{
    public class Word : Token
    {
        public readonly string lexeme;
        public Word(int id, string lexeme)
            : base(id)
        {
            this.lexeme = lexeme;
        }
    }
}
