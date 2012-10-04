namespace Dragons.Chapter2
{
        /**
         * Construct a recursive descent parser for the following grammar:
         * 
         * S -> 0 S 1 | 0 1
         * 
         * Not predictable? 0 can start either production.
         */
    class _243
    {
            private SingleCharTokenizer tokenizer;
            private char next;
            private char second;
            public _243(string source)
            {
                this.tokenizer = new SingleCharTokenizer(source);
                next = tokenizer.nextToken();
                second = tokenizer.nextToken();
            }

            public void Parse()
            {
                S();
                match('\0');
            }

            private void S()
            {
                switch ("" + next + second)
                {
                    case "01":
                        match('0');
                        match('1');
                        break;
                    default:
                        match('0');
                        S();
                        match('1'); 
                        break;
                }
            }

            private void match(char expected)
            {
                if (next == expected)
                {
                    next = second;
                    second = tokenizer.nextToken();
                }
                else
                {
                    throw new InvalidSyntaxException();
                }
            }

        
    }
}
