using ShellLang.Core.Interpretation.Models;

namespace ShellLang.Core.Interpretation.Nodes
{
    public interface INode
    {
        void Evaluate(Context context);
    }
}
