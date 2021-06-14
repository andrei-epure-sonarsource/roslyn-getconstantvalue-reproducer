using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;

namespace Analyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class AnalyzerAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "Repro";

        private const string Category = "Naming";

        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, "Reproduce GetConstantValue with nameof() unknown type variable", "{0}", Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: "Reproducer for the Roslyn team");

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterCompilationStartAction(
                cc =>
                {
                    cc.RegisterSyntaxNodeAction(
                        c =>
                        {
                            ObjectCreationExpressionSyntax node = (ObjectCreationExpressionSyntax)c.Node;
                            if (node.ArgumentList.Arguments.Count == 1)
                            {
                                var firstArgExpression = node.ArgumentList.Arguments[0].Expression;
                                var value = c.SemanticModel.GetConstantValue(firstArgExpression);
                                var diagnostic = Diagnostic.Create(Rule, c.Node.GetLocation(), $"GetConstantValue hasValue='{value.HasValue}'. Argument constant value is '{value.Value}'.");
                                c.ReportDiagnostic(diagnostic);
                            }
                        }, SyntaxKind.ObjectCreationExpression);
                });
        }
    }
}
