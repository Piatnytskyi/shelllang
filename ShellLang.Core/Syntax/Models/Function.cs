using ShellLang.Core.Interpretation.Nodes;
using ShellLang.Core.Interpretation.Nodes.Statements;
using System.Diagnostics.CodeAnalysis;

namespace ShellLang.Core.Syntax.Models
{
    public struct Function : IEquatable<Function>
    {
        public readonly string Identifier { get; }
        public readonly Declaration[] ParametersDeclarations { get; }
        public readonly BodyComposite Body { get; }

        public Function(string identifier, Declaration[] parameters, BodyComposite body)
        {
            Identifier = identifier;
            ParametersDeclarations = parameters;
            Body = body;
        }

        public bool Equals(Function other)
        {
            return Identifier.Equals(other.Identifier) && ParametersDeclarations.SequenceEqual(other.ParametersDeclarations);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Identifier);

            foreach (var parameter in ParametersDeclarations)
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
