using ShellLang.Core.Nodes.Expressions;

namespace ShellLang.Core.Nodes.Statements
{
    public struct If : INode
    {
        private IExpression _testExpression;
        private BodyComposite _ifBody;
        private BodyComposite _elseBody;

        public INode Parse()
        {
            throw new NotImplementedException();
        }

        public void Evaluate(Context context)
        {
            _testExpression.Evaluate(context);
            if ((bool)_testExpression.Result.Value)
            {
                Context localContext = (Context)context.Clone();
                _ifBody.Evaluate(localContext);
            }
            else
            {
                Context localContext = (Context)context.Clone();
                _elseBody.Evaluate(localContext);
            }
        }
    }
}
