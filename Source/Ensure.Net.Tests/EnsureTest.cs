using System;
using Ensure.Net.Tests.Helpers;

namespace Ensure.Net.Tests
{
#if !NET20
    [TestFixture]
    public class EnsureTest
    {
        [Test]
        public void NotNullExpressionCheckShouldThrowExceptionIfVariableIsNull()
        {
            // Arrange
            string variableName = null;

            // Assert
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNull(() => variableName));

            // Act
            Assert.Equal("'variableName' cannot be null.", ex.Message);
        }
    }
#endif
}
