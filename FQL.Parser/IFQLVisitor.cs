using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace FQL.Parser;

public interface IFQLVisitor
{
    IStateManager StateManager { get; }
    IErrorManager ErrorManager { get; }
    void SetGrammarName(string grammarName);
    object VisitIf(FQLParser.IfContext context);
    object VisitDumpStatement(FQLParser.DumpStatementContext context);
    void DumpCallStack();
    object VisitGetStatement(FQLParser.GetStatementContext context);
    object VisitStatements(FQLParser.StatementsContext context);
    object VisitConnectionStatement(FQLParser.ConnectionStatementContext context);
    object VisitBreakStatement(FQLParser.BreakStatementContext context);
    object VisitCallStatement(FQLParser.CallStatementContext context);
    object VisitPrintString(FQLParser.PrintStringContext context);
    object VisitGetAtom(FQLParser.GetAtomContext context);
    object VisitIdentifierAtom(FQLParser.IdentifierAtomContext context);
    object VisitAdditiveExpr(FQLParser.AdditiveExprContext context);
    object VisitMultiplicativeExpr(FQLParser.MultiplicativeExprContext context);
    object VisitExponentationExpr(FQLParser.ExponentationExprContext context);
    object  VisitParenExpr(FQLParser.ParenExprContext context);
    object VisitPostIncDecStatement(FQLParser.PostIncDecIdentContext context);
    object VisitFloatAtom(FQLParser.FloatAtomContext context);

    /// <summary>
    /// This is the entry point of the Grammar
    /// </summary>
    /// <param name="context"></param>
    object VisitProgram(FQLParser.ProgramContext context);

    object VisitReturnParams(FQLParser.ReturnParamsContext context);
    object VisitJsonPath(FQLParser.JsonPathContext context);

    /// <summary>
    /// Visit a parse tree produced by <see cref="FQLParser.segment"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    Object VisitSegment([NotNull] FQLParser.SegmentContext context);

    object VisitFunctionCallAtom(FQLParser.FunctionCallAtomContext context);
    object VisitErrorNode(IErrorNode node);
    object VisitWhileLoop(FQLParser.WhileLoopContext context);
    object VisitInterpolationString(FQLParser.InterpolationStringContext context);
    object VisitStrLiteral(FQLParser.StrLiteralContext context);
    object VisitIntAtom(FQLParser.IntAtomContext context);
    object VisitFunctionDefinition(FQLParser.FunctionDefinitionContext context);
    object VisitBoolAtom(FQLParser.BoolAtomContext context);
    object VisitDoWhileLoop(FQLParser.DoWhileLoopContext context);
    object VisitStringAtom(FQLParser.StringAtomContext context);
    object VisitBoolExpression(FQLParser.BoolExpressionContext context);
    object VisitBoolTerm(FQLParser.BoolTermContext context);
    object VisitBoolFactor(FQLParser.BoolFactorContext context);
    object VisitBoolLiteral(FQLParser.BoolLiteralContext context);
    object VisitRelationalExpr(FQLParser.RelationalExprContext context);
    object VisitPrintIdentifier(FQLParser.PrintIdentifierContext context);

    /// <summary>
    /// var MyVariable = expression
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    object VisitAssignment(FQLParser.AssignmentContext context);

    object VisitIdent(FQLParser.IdentContext context);
    object VisitObjectAccess(FQLParser.ObjectAccessContext context);
    object VisitStatement(FQLParser.StatementContext context);
    object VisitBoolean(FQLParser.BooleanContext context);
    object VisitComplexAtom(FQLParser.ComplexAtomContext context);
    object VisitPostIncDecIdent(FQLParser.PostIncDecIdentContext context);
    object Visit(IParseTree tree);
    object VisitChildren(IRuleNode node);
    object VisitTerminal(ITerminalNode node);

    /// <summary>
    /// Visit a parse tree produced by <see cref="FQLParser.getParams"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    Object VisitGetParams([NotNull] FQLParser.GetParamsContext context);

    /// <summary>
    /// Visit a parse tree produced by <see cref="FQLParser.printStatement"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    Object VisitPrintStatement([NotNull] FQLParser.PrintStatementContext context);

    /// <summary>
    /// Visit a parse tree produced by <see cref="FQLParser.identifierOrString"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    Object VisitIdentifierOrString([NotNull] FQLParser.IdentifierOrStringContext context);

    /// <summary>
    /// Visit a parse tree produced by <see cref="FQLParser.readStatement"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    Object VisitReadStatement([NotNull] FQLParser.ReadStatementContext context);

    /// <summary>
    /// Visit a parse tree produced by <see cref="FQLParser.writeStatement"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    Object VisitWriteStatement([NotNull] FQLParser.WriteStatementContext context);

    /// <summary>
    /// Visit a parse tree produced by <see cref="FQLParser.return"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    Object VisitReturn([NotNull] FQLParser.ReturnContext context);

    /// <summary>
    /// Visit a parse tree produced by <see cref="FQLParser.paramList"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    Object VisitParamList([NotNull] FQLParser.ParamListContext context);

    /// <summary>
    /// Visit a parse tree produced by <see cref="FQLParser.callParamList"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    Object VisitCallParamList([NotNull] FQLParser.CallParamListContext context);

    /// <summary>
    /// Visit a parse tree produced by <see cref="FQLParser.identifierList"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    Object VisitIdentifierList([NotNull] FQLParser.IdentifierListContext context);

    /// <summary>
    /// Visit a parse tree produced by <see cref="FQLParser.expressionList"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    Object VisitExpressionList([NotNull] FQLParser.ExpressionListContext context);

    /// <summary>
    /// Visit a parse tree produced by the <c>ObjectAccessAtom</c>
    /// labeled alternative in <see cref="FQLParser.complexAtomPart"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    Object VisitObjectAccessAtom([NotNull] FQLParser.ObjectAccessAtomContext context);

    /// <summary>
    /// Visit a parse tree produced by <see cref="FQLParser.integer"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    Object VisitInteger([NotNull] FQLParser.IntegerContext context);

    /// <summary>
    /// Visit a parse tree produced by <see cref="FQLParser.operator"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    Object VisitOperator([NotNull] FQLParser.OperatorContext context);

    /// <summary>
    /// Visit a parse tree produced by <see cref="FQLParser.stringLiteral"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    Object VisitStringLiteral([NotNull] FQLParser.StringLiteralContext context);

    /// <summary>
    /// Visit a parse tree produced by <see cref="FQLParser.interpolatedString"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    Object VisitInterpolatedString([NotNull] FQLParser.InterpolatedStringContext context);

    /// <summary>
    /// Visit a parse tree produced by <see cref="FQLParser.interpolation"/>.
    /// <para>
    /// The default implementation returns the result of calling <see cref="AbstractParseTreeVisitor{Result}.VisitChildren(IRuleNode)"/>
    /// on <paramref name="context"/>.
    /// </para>
    /// </summary>
    /// <param name="context">The parse tree.</param>
    /// <return>The visitor result.</return>
    Object VisitInterpolation([NotNull] FQLParser.InterpolationContext context);
}