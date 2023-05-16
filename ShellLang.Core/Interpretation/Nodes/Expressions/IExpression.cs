using ShellLang.Core.Syntax.Models;

namespace ShellLang.Core.Interpretation.Nodes.Expressions
{
    public interface IExpression : INode
    {
        Entity Result { get; }
    }
}
