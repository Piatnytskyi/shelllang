using ShellLang.Core.Enums;
using ShellLang.Core.Exceptions;
using ShellLang.Core.Models;
using System.Text;

namespace ShellLang.Core
{
    public class Lexer
    {
        private readonly IEnumerator<char> _symbols;
        private readonly HashSet<Token> _reservedWords = new HashSet<Token>();

        public Lexer(IEnumerator<char> symbols, HashSet<Token> reservedWords)
        {
            _symbols = symbols;
            _reservedWords = reservedWords;
        }

        public IEnumerable<Token> GetTokens()
        {
            bool isEndReached = false;
            while (isEndReached)
            {
                var wordBuilder = new StringBuilder();

                if (char.IsWhiteSpace(_symbols.Current) || _symbols.Current == '\n')
                {
                    isEndReached = _symbols.MoveNext();
                    continue;
                }

                if (char.IsLetter(_symbols.Current))
                {
                    while (char.IsLetterOrDigit(_symbols.Current))
                    {
                        wordBuilder.Append(_symbols.Current);
                        isEndReached = _symbols.MoveNext();
                    }

                    string word = wordBuilder.ToString();
                    var potentialIdentifier = new Token(word, Tag.Identifier);
                    Token actual;
                    yield return _reservedWords.TryGetValue(potentialIdentifier, out actual)
                        ? actual
                        : potentialIdentifier;
                }

                if (char.IsDigit(_symbols.Current))
                {
                    while (char.IsDigit(_symbols.Current))
                    {
                        wordBuilder.Append(_symbols.Current);
                        isEndReached = _symbols.MoveNext();
                    }

                    yield return new Token(wordBuilder.ToString(), Tag.Literal);
                }

                if (_symbols.Current == '\"')
                {
                    isEndReached = _symbols.MoveNext();
                    while (_symbols.Current != '\"' && !isEndReached)
                    {
                        wordBuilder.Append(_symbols.Current);
                        isEndReached = _symbols.MoveNext();
                    }

                    if (isEndReached)
                        throw new LexerException("Unfinished string!");

                    wordBuilder.Append(_symbols.Current);
                    wordBuilder.Remove(wordBuilder.Length - 1, 1);
                    isEndReached = _symbols.MoveNext();

                    yield return new Token(wordBuilder.ToString(), Tag.Literal);
                }

                if (_symbols.Current == ';'
                    || _symbols.Current == '{'
                    || _symbols.Current == '}'
                    || _symbols.Current == '('
                    || _symbols.Current == ')')
                {
                    wordBuilder.Append(_symbols.Current);
                    isEndReached = _symbols.MoveNext();

                    yield return new Token(wordBuilder.ToString(), Tag.Separator);
                }

                if (_symbols.Current == '>'
                    || _symbols.Current == '<'
                    || _symbols.Current == '='
                    || _symbols.Current == '+'
                    || _symbols.Current == '-')
                {
                    wordBuilder.Append(_symbols.Current);
                    isEndReached = _symbols.MoveNext();

                    if (_symbols.Current == '=')
                    {
                        wordBuilder.Append(_symbols.Current);
                        isEndReached = _symbols.MoveNext();
                    }

                    yield return new Token(wordBuilder.ToString(), Tag.BinaryOperator);
                }

                if (_symbols.Current == '#')
                {
                    while (_symbols.Current != '\n')
                        isEndReached = _symbols.MoveNext();

                    continue;
                }

                throw new LexerException("Unknown lexeme encountered.");
            }
        }
    }
}
