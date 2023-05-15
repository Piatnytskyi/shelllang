
using System.Diagnostics.CodeAnalysis;

namespace ShellLang.Core.Models
{
    public struct Variable
    {
        public string Identifier { get; }
        public Entity Entity { get; set; }

        public Variable(string identifier, Entity entity)
        {
            Identifier = identifier;
            Entity = entity;
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
