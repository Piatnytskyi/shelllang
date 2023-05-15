using System.Diagnostics.CodeAnalysis;

namespace ShellLang.Core.Models
{
    public struct Function : IEquatable<Function>
    {
        public readonly string Identifier { get; }
        public readonly Variable[] Parameters { get; }

        public Function(string identifier, Variable[] parameters)
        {
            Identifier = identifier;
            Parameters = parameters;
        }

        public bool Equals(Function other)
        {
            return Identifier.Equals(other.Identifier) && Enumerable.SequenceEqual(Parameters, other.Parameters);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Identifier);

            foreach (var parameter in Parameters)
                hashCode.Add(parameter.GetHashCode());

            return hashCode.ToHashCode();
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj == null || !(obj is Function))
                return false;

            return Equals((Function)obj);
        }
    }
}
