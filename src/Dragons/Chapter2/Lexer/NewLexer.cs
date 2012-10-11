using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Dragons.Chapter2.Lexer
{
    public class NewLexer
    {
        protected int line = 1;
        private int currentChar = ' ';
        protected char peek
        {
            get
            {
                return (char)currentChar;
            }
            set
            {
                currentChar = value;
            }
        }
        protected Dictionary<String, Word> words = new Dictionary<string, Word>();
        protected TextReader sourceStream;

        public NewLexer(TextReader source)
        {
            sourceStream = source;

            Reserve(new Word(Tag.TRUE, "true"));
            Reserve(new Word(Tag.FALSE, "false"));
            AdvancePeek();
        }
        protected bool EndOfSource()
        {
            return currentChar == -1;
            //return sourceStream.Peek() == -1;
        }
        private void Reserve(Word word)
        {
            words[word.lexeme] = word;
        }

        protected void AdvancePeek()
        {
            currentChar = sourceStream.Read();
        }

        /// <summary>
        /// Scans the input and returns the next token
        /// </summary>
        /// <returns>Token</returns>
        virtual public Token Scan()
        {
            if (EndOfSource())
            {
                return null;
            }
            do
            {
                if (peek == ' ' || peek == '\t')
                {
                    AdvancePeek();
                    continue;
                }
                else if (peek == '\n')
                {
                    AdvancePeek();
                    ++line;
                }
                else
                {
                    break;
                }
                AdvancePeek();
            } while (true);
            return BuildToken();
        }

        virtual protected Token BuildToken()
        {
            if (EndOfSource())
            {
                return null;
            }
            if (Char.IsDigit(peek))
            {
                return Integer();
            }
            if (Char.IsLetter(peek))
            {
                return Word();
            }
            Token t = new Token(peek);
            peek = ' ';
            return t;
        }

        private Token Word()
        {
            string wordValue = "";
            do
            {
                wordValue += peek;
                AdvancePeek();
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

        private Token Integer()
        {
            int v = 0;
            do
            {
                v = 10 * v + int.Parse(peek.ToString()); //this is dumb is there a better way?
                AdvancePeek();
            } while (Char.IsDigit(peek));
            return new IntegerToken(v);
        }
    }
}
