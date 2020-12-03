using TestsCommon.XUnit.Conditionals;
using Xunit;

namespace Lib.Tests
{
    public class Facts
    {
        [Fact]
        public void StuffWorks()
        {
            // Act
            var result = 2 + 2;

            // Assert
            Assert.Equal(4, result);
        }

        [Fact, LinuxOnly]
        public void Should_not_run()
        {
            // Act
            var result = 2 + 2;

            // Assert
            Assert.Equal(4, result);
        }
    }
}