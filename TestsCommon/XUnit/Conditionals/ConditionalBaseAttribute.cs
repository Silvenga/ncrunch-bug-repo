using System;
using Xunit.Abstractions;

namespace TestsCommon.XUnit.Conditionals
{
    public abstract class ConditionalTestBaseAttribute : Attribute
    {
        public string Reason { get; set; }

        public abstract bool CanExecute(ITestMethod testMethod);
    }
}
