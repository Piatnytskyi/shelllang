namespace ShellLang.Core.Nodes
{
    public struct BodyComposite : INode
    {
        private readonly IEnumerable<INode> _children;

        public BodyComposite(IEnumerable<INode> children)
        {
            _children = children;
        }

        public INode Parse()
        {
            throw new NotImplementedException();
        }

        public void Evaluate(Context context)
        {
            if (_children is not null)
                foreach (var child in _children)
                {
                    child.Evaluate(context);
                }
        }
    }
}
