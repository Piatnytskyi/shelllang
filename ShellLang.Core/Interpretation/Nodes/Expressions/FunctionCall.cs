using ShellLang.Core.Exceptions;
using ShellLang.Core.Interpretation.Models;
using ShellLang.Core.Syntax.Models;

namespace ShellLang.Core.Interpretation.Nodes.Expressions
{
    public struct FunctionCall : IExpression
    {
        private Function _function;
        private IExpression[] _argumentsExpressions;

        public Entity Result { get; }

        public void Evaluate(Context context)
        {
            if (!context.Functions.Contains(_function))
                throw new InterpreterException("Undeclared function used.");

            foreach (var _argumentExpression in _argumentsExpressions)
                _argumentExpression.Evaluate(context);

            Context localContext = (Context)context.Clone();

            for (int index = 0; index < _function.ParametersDeclarations.Length; ++index)
            {
                //var initialization =
                //    new Initialization(
                //        _function.ParametersDeclarations[index],
                //        new Assignment(, _argumentsExpressions[index].Result));
                //parameterDeclaration.Entity = argument.Result;
                //_function.ParametersDeclarations[index] = parameter;
            }

            _function.Body.Evaluate(localContext);
        }
    }
}
