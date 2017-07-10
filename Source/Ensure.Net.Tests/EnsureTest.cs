using System;
using Xunit;

namespace Ensure.Net.Tests
{
    public class EnsureTest
    {
        [Fact]
        public void NotNullCheckShouldThrowExceptionIfVariableIsNull()
        {
            // Arrange
            string variableName = null;

            // Assert
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNull(() => variableName));

            // Act
            Assert.Equal("'variableName' cannot be null.", ex.Message);
        }
    }
}
