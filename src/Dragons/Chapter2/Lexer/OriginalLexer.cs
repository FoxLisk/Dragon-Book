using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dragons.Chapter2.Lexer
{
    class OriginalLexer
    {
        public int line = 1;
        private char peek = ' ';
        private Dictionary<String, Word> words = new Dictionary<string, Word>();
        void reserve(Word word)
        {
            words[word.lexeme] = word;
        }
        public OriginalLexer()
        {
            reserve(new Word(Tag.TRUE, "true"));
            reserve(new Word(Tag.FALSE, "false"));
        }
        public Token scan()
        {
            for (; ; peek = (char)Console.Read())
            {
                if (peek == ' ' || peek == '\t')
                {
                    continue;
                }
                else if (peek == '\n')
                {
                    ++line;
                }
                else
                {
                    break;
                }
            }
            if (Char.IsDigit(peek))
            {
                int v = 0;
                do
                {
                    v = 10 * v + int.Parse(peek.ToString()); //this is dumb is there a better way?
                    peek = (char)Console.Read();
                } while (Char.IsDigit(peek));
                return new IntegerToken(v);
            }
            if (Char.IsLetter(peek))
            {
                string wordValue = "";
                do
                {
                    wordValue += peek;
                    peek = (char)Console.Read();
                } while (Char.IsLetterOrDigit(peek));
                if (words.ContainsKey(wordValue))
                {
                    return words[wordValue];
                }
                else
                {
                    Word w = new Word(Tag.IDENTIFIER, wordValue);
                    words[wordValue] = w;
                    return w;
                }
            }
            Token t = new Token(peek);
            peek = ' ';
            return t;
        }
    }
}
