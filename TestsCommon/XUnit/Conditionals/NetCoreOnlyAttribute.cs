using System;
using Xunit.Abstractions;

namespace TestsCommon.XUnit.Conditionals
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class NetCoreOnlyAttribute : ConditionalTestBaseAttribute
    {
        public override bool CanExecute(ITestMethod testMethod)
        {
#if NETCORE
            return true;
#else
            return false;
#endif
        }
    }
}
