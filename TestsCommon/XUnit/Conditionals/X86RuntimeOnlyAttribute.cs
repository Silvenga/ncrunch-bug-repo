using System;
using System.Runtime.InteropServices;
using Xunit.Abstractions;

namespace TestsCommon.XUnit.Conditionals
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class X86RuntimeOnlyAttribute : ConditionalTestBaseAttribute
    {
        public override bool CanExecute(ITestMethod testMethod)
        {
            return RuntimeInformation.ProcessArchitecture == Architecture.X86;
        }
    }
}
