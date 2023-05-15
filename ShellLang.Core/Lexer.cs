using ShellLang.Core.Enums;
using ShellLang.Core.Exceptions;
using System.Text;

namespace ShellLang.Core
{
    public class Lexer
    {
        private IEnumerator<char> _symbols;
        private Dictionary<string, Tag> _reservedWords = new Dictionary<string, Tag>();

        public Lexer(IEnumerator<char> symbols, Dictionary<string, Tag> reservedWords)
        {
            _symbols = symbols;
            _reservedWords = reservedWords;
        }

        public IEnumerable<KeyValuePair<string, Tag>> GetTokens()
        {
            while (_symbols.Current != char.MinValue)
            {
                var wordBuilder = new StringBuilder();

                if (char.IsWhiteSpace(_symbols.Current) || _symbols.Current == '\n')
                {
                    _symbols.MoveNext();
                    continue;
                }

                if (char.IsLetter(_symbols.Current))
                {
                    while (char.IsLetterOrDigit(_symbols.Current))
                    {
                        wordBuilder.Append(_symbols.Current);
                        _symbols.MoveNext();
                    }

                    string word = wordBuilder.ToString();
                    yield return _reservedWords.ContainsKey(word)
                        ? new KeyValuePair<string, Tag>(word, _reservedWords[word])
                        : new KeyValuePair<string, Tag>(word, Tag.Identifier);
                }

                if (char.IsDigit(_symbols.Current))
                {
                    while (char.IsDigit(_symbols.Current))
                    {
                        wordBuilder.Append(_symbols.Current);
                        _symbols.MoveNext();
                    }

                    yield return new KeyValuePair<string, Tag>(wordBuilder.ToString(), Tag.Literal);
                }

                if (_symbols.Current == '\"')
                {
                    bool isEnd = _symbols.MoveNext();
                    while (_symbols.Current != '\"' && !isEnd)
                    {
                        wordBuilder.Append(_symbols.Current);
                        isEnd = _symbols.MoveNext();
                    }

                    if (isEnd)
                        throw new LexerException("Unfinished string!");

                    wordBuilder.Append(_symbols.Current);
                    wordBuilder.Remove(wordBuilder.Length - 1, 1);
                    _symbols.MoveNext();

                    yield return new KeyValuePair<string, Tag>(wordBuilder.ToString(), Tag.Literal);
                }

                if (_symbols.Current == ';'
                    || _symbols.Current == '{'
                    || _symbols.Current == '}'
                    || _symbols.Current == '('
                    || _symbols.Current == ')')
                {
                    wordBuilder.Append(_symbols.Current);
                    _symbols.MoveNext();

                    yield return new KeyValuePair<string, Tag>(wordBuilder.ToString(), Tag.Separator);
                }

                if (_symbols.Current == '>'
                    || _symbols.Current == '<'
                    || _symbols.Current == '='
                    || _symbols.Current == '+'
                    || _symbols.Current == '-')
                {
                    wordBuilder.Append(_symbols.Current);
                    _symbols.MoveNext();

                    if (_symbols.Current == '=')
                    {
                        wordBuilder.Append(_symbols.Current);
                        _symbols.MoveNext();
                    }

                    yield return new KeyValuePair<string, Tag>(wordBuilder.ToString(), Tag.BinaryOperator);
                }

                if (_symbols.Current == '#')
                {
                    while (_symbols.Current != '\n')
                        _symbols.MoveNext();

                    continue;
                }

                throw new LexerException("Unknown lexeme encountered.");
            }
        }
    }
}
