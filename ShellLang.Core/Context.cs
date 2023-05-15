using ShellLang.Core.Models;

namespace ShellLang.Core
{
    public struct Context : ICloneable
    {
        public HashSet<Variable> Variables { get; } = new HashSet<Variable>();
        public HashSet<Function> Functions { get; } = new HashSet<Function>();

        public Context(HashSet<Variable> variables)
        {
            Variables = variables;
        }

        public object Clone()
        {
            return new Context(new HashSet<Variable>(Variables));
        }
    }
}
