using Antlr4.Runtime.Misc;
using PersonaMusicScript.Library.Models;
using PersonaMusicScript.Library.Parser.Exceptions;

namespace PersonaMusicScript.Library.Parser.Functions;

internal class SituationalBgmFunction : IFunction<SituationalBgm>
{
    private readonly MusicSource source;
    private readonly ExpressionVisitor expressionVisitor;

    public SituationalBgmFunction(MusicSource source, ExpressionVisitor expressionVisitor)
    {
        this.source = source;
        this.expressionVisitor = expressionVisitor;
    }

    public string Name { get; } = "situational_bgm";

    public SituationalBgm Invoke([NotNull] SourceParser.FunctionContext context)
    {
        if (context.exprList() == null)
        {
            throw new FunctionException(this.Name, 2, 0, context);
        }

        var argExps = context.exprList().expression();
        if (argExps.Length < 2)
        {
            throw new FunctionException(this.Name, 2, argExps.Length, context);
        }
        else if (argExps.Length > 3)
        {
            throw new FunctionException(this.Name, 3, argExps.Length, context);
        }

        var normalExp = argExps[0];
        var advantageExp = argExps[1];
        var disadvantageExp = argExps.Length > 2 ? argExps[2] : null;

        var normalValue = this.expressionVisitor.Visit(normalExp);
        var advantageValue = this.expressionVisitor.Visit(advantageExp);
        var disadvantageValue = disadvantageExp != null ? this.expressionVisitor.Visit(disadvantageExp) : null;

        if (normalValue is IMusic normalBgm
            && advantageValue is IMusic advantageBgm)
        {
            var disadvantageBgm = disadvantageValue as IMusic;

            // Validate disadvantage bgm if exists.
            if (argExps.Length > 2 && disadvantageBgm == null)
            {
                throw new ParsingException("Invalid function arguments.", context);
            }

            try
            {
                var situationalBgm = new SituationalBgm(normalBgm, advantageBgm, disadvantageBgm);
                if (!this.source.SituationalBgms.Contains(situationalBgm))
                {
                    this.source.SituationalBgms.Add(situationalBgm);
                }

                return situationalBgm;
            }
            catch (Exception ex)
            {
                throw new ParsingException("Failed to create Situational BGM.", context, ex);
            }
        }
        else
        {
            throw new ParsingException("Invalid function arguments.", context);
        }
    }
}
