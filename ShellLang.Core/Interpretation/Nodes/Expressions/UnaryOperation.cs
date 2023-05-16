using ShellLang.Core.Interpretation.Models;
using ShellLang.Core.Syntax.Models;

namespace ShellLang.Core.Interpretation.Nodes.Expressions
{
    public struct UnaryOperation : IExpression
    {
        public readonly IExpression _rightHandExpression;
        //public readonly UNARYOPERATOR oper;

        public Entity Result { get; }

        public void Evaluate(Context context)
        {
            _rightHandExpression.Evaluate(context);


        }
    }
}
