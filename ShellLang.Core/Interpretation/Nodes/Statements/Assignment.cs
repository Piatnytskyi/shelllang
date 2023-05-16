using ShellLang.Core.Exceptions;
using ShellLang.Core.Interpretation.Models;
using ShellLang.Core.Interpretation.Nodes.Expressions;
using ShellLang.Core.Syntax.Models;

namespace ShellLang.Core.Interpretation.Nodes.Statements
{
    public struct Assignment : INode
    {
        private Variable _variable;
        private IExpression _assignExpression;

        public Assignment(Variable variable, IExpression expression)
        {
            _variable = variable;
            _assignExpression = expression;
        }

        public void Evaluate(Context context)
        {
            if (!context.Variables.Contains(_variable))
                throw new InterpreterException("Undeclared variable used.");

            _assignExpression.Evaluate(context);
            context.Variables.Remove(_variable);
            _variable.Entity = _assignExpression.Result;
            context.Variables.Add(_variable);
        }
    }
}
