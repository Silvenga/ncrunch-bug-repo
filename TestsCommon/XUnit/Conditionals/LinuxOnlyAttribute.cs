using System;
using System.Runtime.InteropServices;
using Xunit.Abstractions;

namespace TestsCommon.XUnit.Conditionals
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class LinuxOnlyAttribute : ConditionalTestBaseAttribute
    {
        public override bool CanExecute(ITestMethod testMethod)
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        }
    }
}