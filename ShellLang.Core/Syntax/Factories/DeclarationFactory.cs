using ShellLang.Core.Exceptions;
using ShellLang.Core.Interpretation.Nodes;
using ShellLang.Core.Lexical.Models;

namespace ShellLang.Core.Syntax.Factories
{
    public class DeclarationFactory : AbstractNodeFactory
    {
        public override INode Parse(IEnumerator<Token> tokens)
        {
            bool isEndReached = tokens.MoveNext();
            if (isEndReached)
                throw new ParserException("Missing identifier.");

            //Type* type = createType(current->lexeme);
            //current = tokens.takeFirst();

            //if (tokens.Current.Type == TokenType.Identifier)
            //    return new Declaration(
            //        current->lexeme, type);

            throw new ParserException("Missing identifier.");
        }
    }
}
