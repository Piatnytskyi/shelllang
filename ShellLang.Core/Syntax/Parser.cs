using ShellLang.Core.Interpretation.Nodes;
using ShellLang.Core.Lexical.Models;

namespace ShellLang.Core.Parser
{
    public class Parser
    {
        private readonly IEnumerator<Token> _tokens;

        public Parser(IEnumerator<Token> tokens)
        {
            _tokens = tokens;
        }

        public IEnumerable<INode> FormTree()
        {
            throw new NotImplementedException();
            //QList<Node*> tree;

            //while (!tokens.isEmpty())
            //{
            //    current = tokens.takeFirst();

            //    if (current->tag == Tag::TYPE)
            //    {
            //        if (tokens.size() > 2 && tokens[1]->lexeme == '=')
            //            tree.push_back(initializationParse());
            //        else
            //            tree.push_back(declarationParse());

            //        if (tokens.isEmpty())
            //            throw ParserException(MISSINGSEMICOLON_PARSER_EXCEPTION);
            //        current = tokens.takeFirst();

            //        if (current->lexeme != ';')
            //            throw ParserException(MISSINGSEMICOLON_PARSER_EXCEPTION);

            //        continue;
            //    }

            //    if (current->tag == Tag::IDENTIFIER)
            //    {
            //        tree.push_back(assignmentParse());

            //        if (tokens.isEmpty())
            //            throw ParserException(MISSINGSEMICOLON_PARSER_EXCEPTION);
            //        current = tokens.takeFirst();

            //        if (current->lexeme != ';')
            //            throw ParserException(MISSINGSEMICOLON_PARSER_EXCEPTION);

            //        continue;
            //    }

            //    if (current->tag == Tag::KEYWORD)
            //    {
            //        if (current->lexeme == "if")
            //            tree.push_back(ifStatementParse());

            //        if (current->lexeme == "for")
            //            tree.push_back(forStatementParse());

            //        if (current->lexeme == "function")
            //            tree.push_back(functionStatementParse());

            //        if (current->lexeme == "return")
            //        {
            //            tree.push_back(functionReturnParse());

            //            if (tokens.isEmpty())
            //                throw ParserException(MISSINGSEMICOLON_PARSER_EXCEPTION);
            //            current = tokens.takeFirst();

            //            if (current->lexeme != ';')
            //                throw ParserException(MISSINGSEMICOLON_PARSER_EXCEPTION);
            //        }

            //        continue;
            //    }

            //    if (current->lexeme == "}")
            //        break;

            //    throw ParserException(MISSINGCLOSEBRACKET_PARSER_EXCEPTION);
            //}

            //return tree;
        }
    }
}
