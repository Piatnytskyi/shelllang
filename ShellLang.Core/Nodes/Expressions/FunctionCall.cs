using ShellLang.Core.Exceptions;
using ShellLang.Core.Models;

namespace ShellLang.Core.Nodes.Expressions
{
    public struct FunctionCall : IExpression
    {
        private Models.Function _function;
        private IExpression[] _argumentsExpressions;

        public Entity Result { get; }

        public void Evaluate(Context context)
        {
            if (!context.Functions.Contains(_function))
                throw new ParserException("Undeclared function used.");

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
