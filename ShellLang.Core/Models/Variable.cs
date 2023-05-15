using ShellLang.Core.Enums;
using System.Diagnostics.CodeAnalysis;

namespace ShellLang.Core.Models
{
    public struct Variable
    {
        public string Identifier { get; }
        public (string, PrimitiveType) Value { get; set; }

        public Variable(string identifier, (string, PrimitiveType) value)
        {
            Identifier = identifier;
            Value = value;
        }

        public override int GetHashCode()
        {
            return Identifier.GetHashCode();
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj == null || !(obj is Variable))
                return false;

            var other = (Variable)obj;

            return Identifier.Equals(other.Identifier);
        }
    }
}
