using ShellLang.Core.Models;

namespace ShellLang.Core.Nodes.Expressions
{
    public struct BinaryOperation : IExpression
    {
        private IExpression _leftHandExpression;
        //private string _operation;
        private IExpression _rightHandExpression;

        public Entity Result { get; }

        public INode Parse()
        {
            throw new NotImplementedException();
        }

        public void Evaluate(Context context)
        {
            _leftHandExpression.Evaluate(context);
            _rightHandExpression.Evaluate(context);

        }
    }
}
