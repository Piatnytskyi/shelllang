namespace ShellLang.Core.Nodes.Statements
{
    public class Initialization : INode
    {
        private Declaration _declaration;
        private Assignment _assign;

        public Initialization(Declaration declaration, Assignment assignment)
        {
            _declaration = declaration;
            _assign = assignment;
        }

        public INode Parse()
        {
            throw new NotImplementedException();
        }

        public void Evaluate(Context context)
        {
            _declaration.Evaluate(context);
            _assign.Evaluate(context);
        }
    }
}
