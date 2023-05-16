namespace ShellLang.Core.Nodes
{
    public interface INode
    {
        void Evaluate(Context context);
    }
}
