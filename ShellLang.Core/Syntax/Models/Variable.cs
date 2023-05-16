using System.Diagnostics.CodeAnalysis;

namespace ShellLang.Core.Syntax.Models
{
    public struct Variable : IEquatable<Variable>
    {
        public readonly string Identifier { get; }
        public Entity Entity { get; set; }

        public Variable(string identifier, Entity entity)
        {
            Identifier = identifier;
            Entity = entity;
        }

        public bool Equals(Variable other)
        {
            return Identifier.Equals(other.Identifier);
        }

        public override int GetHashCode()
        {
            return Identifier.GetHashCode();
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj == null || !(obj is Variable))
                return false;

            return Equals((Variable)obj);
        }
    }
}
