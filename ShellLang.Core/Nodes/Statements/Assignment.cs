using ShellLang.Core.Exceptions;
using ShellLang.Core.Models;
using ShellLang.Core.Nodes.Expressions;

namespace ShellLang.Core.Nodes.Statements
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

        public INode Parse()
        {
            throw new NotImplementedException();
        }

        public void Evaluate(Context context)
        {
            if (!context.Variables.Contains(_variable))
                throw new ParserException("Undeclared variable used.");

            _assignExpression.Evaluate(context);
            context.Variables.Remove(_variable);
            _variable.Entity = _assignExpression.Result;
            context.Variables.Add(_variable);
        }
    }
}
