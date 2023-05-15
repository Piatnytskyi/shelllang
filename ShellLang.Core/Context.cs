using ShellLang.Core.Models;

namespace ShellLang.Core
{
    public class Context
    {
        public HashSet<Variable> Variables { get; } = new HashSet<Variable>();
    }
}
