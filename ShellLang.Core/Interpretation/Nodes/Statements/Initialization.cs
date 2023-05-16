using ShellLang.Core.Interpretation.Models;

namespace ShellLang.Core.Interpretation.Nodes.Statements
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

        public void Evaluate(Context context)
        {
            _declaration.Evaluate(context);
            _assign.Evaluate(context);
        }
    }
}
