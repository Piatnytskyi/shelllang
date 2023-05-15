using ShellLang.Core.Exceptions;
using ShellLang.Core.Models;

namespace ShellLang.Core.Nodes.Statements
{
    public struct Declaration : INode
    {
        public Variable _variable;

        public INode Parse()
        {
            throw new NotImplementedException();
        }

        public void Evaluate(Context context)
        {
            if (!context.Variables.Contains(_variable))
            {
                context.Variables.Add(_variable);
                return;
            }

            throw new ParserException("Variable already declared!");
        }
    }
}
