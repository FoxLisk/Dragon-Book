using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dragons.Chapter3
{
    public class Failure
    {
        string b;
        public int[] failureFunction(string b)
        {
            this.b = b;
            //b = b1b2b3..bn
            int n = b.Length + 1;
            int[] f = new int[n];
            int t = 0;
            f[1] = 0;
            for (int s = 1; s < n - 1; s++)
            {
                while (t > 0 && getChar(s + 1) != getChar(t + 1))
                {
                    t = f[t];
                }
                if (getChar(s + 1) == getChar(t + 1))
                {
                    t = t + 1;
                    f[s + 1] = t;
                }
                else
                {
                    f[s + 1] = 0;
                }
            }
            return f;
        }
        private char getChar(int n)
        {
            return b[n - 1];
        }
    }
}
