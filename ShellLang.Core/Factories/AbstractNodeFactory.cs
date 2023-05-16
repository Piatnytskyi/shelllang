using ShellLang.Core.Nodes;

namespace ShellLang.Core.Factories
{
    abstract public class AbstractNodeFactory
    {
        public abstract INode Parse(IEnumerator<char> symbols);
    }
}
