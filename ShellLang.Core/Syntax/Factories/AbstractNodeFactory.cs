using ShellLang.Core.Interpretation.Nodes;
using ShellLang.Core.Lexical.Models;

namespace ShellLang.Core.Syntax.Factories
{
    abstract public class AbstractNodeFactory
    {
        public abstract INode Parse(IEnumerator<Token> tokens);
    }
}
