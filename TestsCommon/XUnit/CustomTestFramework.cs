using System.Collections.Generic;
using System.Reflection;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace TestsCommon.XUnit
{
    public class CustomTestFramework : XunitTestFramework
    {
        public const string FullName = "TestsCommon.XUnit.CustomTestFramework";
        public const string Assembly = "TestsCommon";

        public CustomTestFramework(IMessageSink messageSink) : base(messageSink)
        {
        }

        protected override ITestFrameworkDiscoverer CreateDiscoverer(
            IAssemblyInfo assemblyInfo)
        {
            return new CustomTestFrameworkDiscoverer(assemblyInfo, SourceInformationProvider, DiagnosticMessageSink);
        }

        protected override ITestFrameworkExecutor CreateExecutor(AssemblyName assemblyName)
        {
            return new ContrastTestFrameworkExecutor(assemblyName, SourceInformationProvider, DiagnosticMessageSink);
        }

        private class ContrastTestFrameworkExecutor : XunitTestFrameworkExecutor
        {
            public ContrastTestFrameworkExecutor(AssemblyName assemblyName,
                                                 ISourceInformationProvider sourceInformationProvider,
                                                 IMessageSink diagnosticMessageSink)
                : base(assemblyName, sourceInformationProvider, diagnosticMessageSink)
            {
            }

            public override void RunTests(IEnumerable<ITestCase> testCases, IMessageSink executionMessageSink, ITestFrameworkExecutionOptions executionOptions)
            {
                // Logging setup.

                base.RunTests(testCases, executionMessageSink, executionOptions);
            }
        }
    }
}