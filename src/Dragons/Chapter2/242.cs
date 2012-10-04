namespace Dragons.Chapter2
{
    /**
     * Construct a recursive descent parser for the following grammar:
     * 
     * S -> S ( S ) S | e
     */
    class _242
    {
        private SingleCharTokenizer tokenizer;
        private char nextChar;
        public _242(string source)
        {
            this.tokenizer = new SingleCharTokenizer(source);
            nextChar = tokenizer.nextToken();
        }

        public void Parse()
        {
            S();
            match('\0');
        }

        private void S()
        {
            if (nextChar == '(')
            {
                match('(');
                S();
                match(')');
            }
            if (nextChar == '(')
            {
                S();
            }

        }

        private void match(char expected)
        {
            if (nextChar == expected)
            {
                nextChar = tokenizer.nextToken();
            }
            else
            {
                throw new InvalidSyntaxException();
            }
        }


    }
}
