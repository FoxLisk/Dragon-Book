namespace Dragons.Chapter2
{
    /**
     * Construct a recursive descent parser for the following grammar:
     * 
     * S -> + S S | - S S | a
     */
    class _241
    {
        private SingleCharTokenizer tokenizer;
        private char lookahead;
        public _241(string source)
        {
            this.tokenizer = new SingleCharTokenizer(source);
            lookahead = tokenizer.nextToken();
        }

        public void Parse()
        {
            S();
            match('\0');
        }

        private void S()
        {
            switch (lookahead)
            {
                case '+':
                    match('+');
                    S();
                    S();
                    break;
                case '-':
                    match('-');
                    S();
                    S(); 
                    break;
                case 'a':
                    match('a');
                    break;
                default:
                    throw new InvalidSyntaxException();
            }
        }

        private void match(char expected)
        {
            if (lookahead == expected)
            {
                lookahead = tokenizer.nextToken();
            }
            else
            {
                throw new InvalidSyntaxException();
            }
        }

    }
}
