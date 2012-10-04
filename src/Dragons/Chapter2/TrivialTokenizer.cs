
namespace Dragons.Chapter2
{
    class SingleCharTokenizer
    {
        private string source;
        private int cur = 0;
        public SingleCharTokenizer(string source)
        {
            this.source = source;
        }

        public char nextToken()
        {
            if (cur >= source.Length)
            {
                return '\0';
            }
            while (char.IsWhiteSpace(source[cur]))
            {
                cur++;
            }
            if (cur >= source.Length)
            {
                return '\0';
            }
            var next = source[cur];
            ++cur;
            return next;
        }
    }
}
