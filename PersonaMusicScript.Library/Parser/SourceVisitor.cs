﻿using Antlr4.Runtime.Misc;
using PersonaMusicScript.Library.Parser.Exceptions;

namespace PersonaMusicScript.Library.Parser;

internal class SourceVisitor : SourceBaseVisitor<MusicSource>
{
    public override MusicSource VisitSource([NotNull] SourceParser.SourceContext context)
    {
        var source = new MusicSource();

        var expressionVisitor = new ExpressionVisitor(source);
        var statementVisitor = new StatementVisitor(source, expressionVisitor);
        foreach (var statement in context.statement())
        {
            if (!statementVisitor.Visit(statement))
            {
                throw new ParsingException("Failed to parse statement.", statement);
            }
        }

        return source;
    }
}
