using ShellLang.Core.Nodes.Expressions;

namespace ShellLang.Core.Nodes.Statements
{
    public struct For : INode
    {
        private Initialization _initialization;
        private IExpression _testExpression;
        private IExpression _updateExpression;
        private BodyComposite _body;

        public void Evaluate(Context context)
        {
            Context localContext = (Context)context.Clone();
            _initialization.Evaluate(localContext);
            _testExpression.Evaluate(localContext);
            while ((bool)_testExpression.Result.Value)
            {
                _body.Evaluate(localContext);
                _updateExpression.Evaluate(localContext);
            }
        }
    }
}
