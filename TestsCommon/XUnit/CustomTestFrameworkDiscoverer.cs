using System.Linq;
using TestsCommon.XUnit.Conditionals;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace TestsCommon.XUnit
{
    public class CustomTestFrameworkDiscoverer : XunitTestFrameworkDiscoverer
    {
        public CustomTestFrameworkDiscoverer(IAssemblyInfo assemblyInfo, ISourceInformationProvider sourceProvider, IMessageSink diagnosticMessageSink,
                                             IXunitTestCollectionFactory collectionFactory = null)
            : base(assemblyInfo, sourceProvider, diagnosticMessageSink, collectionFactory)
        {
        }

        protected override bool FindTestsForMethod(ITestMethod testMethod, bool includeSourceInformation, IMessageBus messageBus,
                                                   ITestFrameworkDiscoveryOptions discoveryOptions)
        {
            var list = testMethod.Method
                                 .GetCustomAttributes(typeof(ConditionalTestBaseAttribute))
                                 .Cast<IReflectionAttributeInfo>()
                                 .Select(x => x.Attribute)
                                 .Cast<ConditionalTestBaseAttribute>()
                                 .ToList();

            var skip = list.Any(x => !x.CanExecute(testMethod));
            if (skip)
            {
                return true;
            }

            return base.FindTestsForMethod(testMethod, includeSourceInformation, messageBus, discoveryOptions);
        }
    }
}