using System.Text;
using Dragons.Chapter2;

namespace Dragons
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new _241("+aa");
            test.Parse();

            var test2 = new _242("(())()()()(())");
            test2.Parse();

            var test3 = new _243("0011");
            test3.Parse();
        }
    }
}
