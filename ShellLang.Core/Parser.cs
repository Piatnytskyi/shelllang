using ShellLang.Core.Enums;
using ShellLang.Core.Models.Nodes;

namespace ShellLang.Core
{
    public class Parser
    {
        private readonly IEnumerable<KeyValuePair<string, Tag>> _tokens;

        public Parser(IEnumerable<KeyValuePair<string, Tag>> tokens)
        {
            _tokens = tokens;
        }

        public IEnumerable<INode> FormTree()
        {
            throw new NotImplementedException();
            
        }
    }
}
