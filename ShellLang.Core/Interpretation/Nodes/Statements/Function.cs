using ShellLang.Core.Exceptions;
using ShellLang.Core.Interpretation.Models;

namespace ShellLang.Core.Interpretation.Nodes.Statements
{
    public struct Function : INode
    {
        private Syntax.Models.Function _function;

        public void Evaluate(Context context)
        {
            if (!context.Functions.Contains(_function))
            {
                context.Functions.Add(_function);

                return;
            }

            throw new InterpreterException("Function with that signature already declared!");
        }
    }
}
