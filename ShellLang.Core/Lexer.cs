using ShellLang.Core.Enums;
using ShellLang.Core.Exceptions;
using System.Text;

namespace ShellLang.Core
{
    public class Lexer
    {
        private StreamReader _sourceReader { get; set; }
        private Dictionary<string, Tag> _reservedWords = new Dictionary<string, Tag>();

        private char _peek { get; set; } = char.MinValue;

        public Lexer(Stream source, Dictionary<string, Tag> reservedWords)
        {
            _sourceReader = new StreamReader(source);
            _reservedWords = reservedWords;
        }

        public IEnumerable<KeyValuePair<string, Tag>> GetTokens()
        {
            while (_peek != char.MinValue)
            {
                var wordBuilder = new StringBuilder();

                if (char.IsWhiteSpace(_peek) || _peek == '\n')
                {
                    _peek = (char)_sourceReader.Read();
                    continue;
                }

                if (char.IsLetter(_peek))
                {
                    while (char.IsLetterOrDigit(_peek))
                    {
                        wordBuilder.Append(_peek);
                        _peek = (char)_sourceReader.Read();
                    }

                    string word = wordBuilder.ToString();
                    yield return _reservedWords.ContainsKey(word)
                        ? new KeyValuePair<string, Tag>(word, _reservedWords[word])
                        : new KeyValuePair<string, Tag>(word, Tag.IDENTIFIER);
                }

                if (char.IsDigit(_peek))
                {
                    while (char.IsDigit(_peek))
                    {
                        wordBuilder.Append(_peek);
                        _peek = (char)_sourceReader.Read();
                    }

                    yield return new KeyValuePair<string, Tag>(wordBuilder.ToString(), Tag.LITERAL);
                }

                if (_peek == '\"')
                {
                    _peek = (char)_sourceReader.Read();
                    while (_peek != '\"' && !_sourceReader.EndOfStream)
                    {
                        wordBuilder.Append(_peek);
                        _peek = (char)_sourceReader.Read();
                    }

                    if (_sourceReader.EndOfStream) //TODO: Exception! Unfinished string.
                        throw new LexerException("Unfinished string!");

                    wordBuilder.Append(_peek);
                    wordBuilder.Remove(wordBuilder.Length - 1, 1);
                    _peek = (char)_sourceReader.Read();

                    yield return new KeyValuePair<string, Tag>(wordBuilder.ToString(), Tag.LITERAL);
                }

                if (_peek == ';'
                    || _peek == '{'
                    || _peek == '}'
                    || _peek == '('
                    || _peek == ')')
                {
                    wordBuilder.Append(_peek);
                    _peek = (char)_sourceReader.Read();

                    yield return new KeyValuePair<string, Tag>(wordBuilder.ToString(), Tag.SEPARATOR);
                }

                if (_peek == '>'
                    || _peek == '<'
                    || _peek == '='
                    || _peek == '+'
                    || _peek == '-')
                {
                    wordBuilder.Append(_peek);
                    _peek = (char)_sourceReader.Read();

                    if (_peek == '=')
                    {
                        wordBuilder.Append(_peek);
                        _peek = (char)_sourceReader.Read();
                    }

                    yield return new KeyValuePair<string, Tag>(wordBuilder.ToString(), Tag.BINARYOPERATOR);
                }

                if (_peek == '#')
                {
                    while (_peek != '\n')
                        _peek = (char)_sourceReader.Read();
                }

                //TODO: Exception! Unknown lexeme encountered.
                throw new LexerException("Unknown lexeme encountered.");
            }
        }
    }
}
