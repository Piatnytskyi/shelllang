using ShellLang.Core.Exceptions;

namespace ShellLang.Core.Nodes.Statements
{
    public struct Function : INode
    {
        private Models.Function _function;

        public INode Parse()
        {
            throw new NotImplementedException();
        }

        public void Evaluate(Context context)
        {
            if (!context.Functions.Contains(_function))
            {
                context.Functions.Add(_function);

                return;
            }

            throw new ParserException("Function with that signature already declared!");
        }
    }
}
