using System;

namespace Sample
{
    public class Program
    {
        public void Method(string first, UnknownType second)
        {
            var localVar = "value";

            // the values for c.SemanticModel.GetConstantValue(firstArgExpression);

            new Foo("literal");                           // hasValue=True, Value="literal"
            new Foo(1);                                   // hasValue=True, Value=1

            new Foo(localVar);                            // hasValue=False
            new Foo(known);                               // hasValue=False
            new Foo(unknown);                             // hasValue=False

            new Foo(nameof(localVar));                    // hasValue=True, Value="localVar"
            new Foo(nameof(first));                       // hasValue=True, Value="first"
            new Foo(nameof(second));                      // hasValue=True, Value="" (empty string)
                                                          // EXPECTED: I would expect either hasValue to be False or Value to be "second"
        }

        class Foo { public Foo(object o) { } }
    }
}
