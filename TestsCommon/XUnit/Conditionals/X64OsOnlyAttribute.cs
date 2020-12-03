using System;
using Xunit.Abstractions;

namespace TestsCommon.XUnit.Conditionals
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class X64OsOnlyAttribute : ConditionalTestBaseAttribute
    {
        public override bool CanExecute(ITestMethod testMethod)
        {
            return Environment.Is64BitOperatingSystem;
        }
    }
}
