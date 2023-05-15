using ShellLang.Core.Enums;
using System.Diagnostics.CodeAnalysis;

namespace ShellLang.Core.Models
{
    public struct Token : IEquatable<Token>
    {
        public string Value { get; set; }
        public Tag Type { get; set; }

        public Token(string value, Tag type)
        {
            Value = value;
            Type = type;
        }

        public bool Equals(Token other)
        {
            return Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj == null || !(obj is Token))
                return false;

            return Equals((Token)obj);
        }
    }
}
