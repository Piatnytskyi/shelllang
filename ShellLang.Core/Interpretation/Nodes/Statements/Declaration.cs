using ShellLang.Core.Exceptions;
using ShellLang.Core.Interpretation.Models;
using ShellLang.Core.Syntax.Models;

namespace ShellLang.Core.Interpretation.Nodes.Statements
{
    public struct Declaration : INode
    {
        public Variable _variable;

        public void Evaluate(Context context)
        {
            if (!context.Variables.Contains(_variable))
            {
                context.Variables.Add(_variable);
                return;
            }

            throw new InterpreterException("Variable already declared!");
        }
    }
}
