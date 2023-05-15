using ShellLang.Core.Models;

namespace ShellLang.Core.Nodes.Expressions
{
    public struct UnaryOperation : IExpression
    {
        public readonly IExpression _rightHandExpression;
        //public readonly UNARYOPERATOR oper;

        public Entity Result { get; }

        public INode Parse()
        {
            throw new NotImplementedException();
        }

        public void Evaluate(Context context)
        {
            _rightHandExpression.Evaluate(context);

            
        }
    }
}
