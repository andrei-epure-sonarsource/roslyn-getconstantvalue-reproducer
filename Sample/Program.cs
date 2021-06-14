using System;

namespace Sample
{
    public class Program
    {
        public void Method(UnknownType argument)
        {
            throw new ArgumentNullException(nameof(argument));
        }
    }
}
