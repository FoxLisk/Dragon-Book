using Dragons.Chapter2.Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new OriginalLexer();
            x.scan();
        }
    }
}
