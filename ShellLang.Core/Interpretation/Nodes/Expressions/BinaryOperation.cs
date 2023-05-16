using ShellLang.Core.Interpretation.Models;
using ShellLang.Core.Syntax.Models;

namespace ShellLang.Core.Interpretation.Nodes.Expressions
{
    public struct BinaryOperation : IExpression
    {
        private IExpression _leftHandExpression;
        //private string _operation;
        private IExpression _rightHandExpression;

        public Entity Result { get; }

        public void Evaluate(Context context)
        {
            _leftHandExpression.Evaluate(context);
            _rightHandExpression.Evaluate(context);

        }
    }
}
