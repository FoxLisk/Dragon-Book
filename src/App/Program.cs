using Dragons.Chapter2.Lexer;
using Dragons.Chapter3;
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
            int[] f = new Failure().failureFunction("ababaa");
            for (int i = 0; i < f.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + f[i]);
            }
        }
    }
}