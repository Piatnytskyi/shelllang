namespace ShellLang.Core.Nodes
{
    public interface INode
    {
        INode Parse();
        void Evaluate(Context context);
    }
}
