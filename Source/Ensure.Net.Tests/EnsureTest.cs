using System;
using Ensure.Net.Tests.Helpers;

namespace Ensure.Net.Tests
{
    [TestFixture]
    public class EnsureTest
    {
#if !NET20 
        [Test]
        public void NotNullCheckShouldThrowExceptionIfVariableIsNull()
        {
            // Arrange
            string variableName = null;

            // Assert
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNull(() => variableName));

            // Act
            Assert.Equal("'variableName' cannot be null.", ex.Message);
        }
#endif
    }
}
