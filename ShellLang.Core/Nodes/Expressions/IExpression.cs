using ShellLang.Core.Models;

namespace ShellLang.Core.Nodes.Expressions
{
    public interface IExpression : INode
    {
        Entity Result { get; }
    }
}
