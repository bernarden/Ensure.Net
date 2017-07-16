using System;
using Ensure.Net.Tests.Helpers;

namespace Ensure.Net.Tests
{
    [TestFixture]
    public class EnsureTest
    {
#if !NET20
        [Test]
        public void NotNullExpressionCheckShouldThrowArgumentNullExceptionIfVariableIsNull()
        {
            // Arrange
            string variableName = null;

            // Assert
            Exception ex = Assert.Throws<ArgumentNullException>(() => Ensure.NotNull(() => variableName));

            // Act
            Assert.Equal("'variableName' cannot be null.", ex.Message);
        }
#endif
        [Test]
        public void NotNullCheckShouldThrowArgumentNullExceptionIfVariableIsNull()
        {
            // Arrange
            string variableName = null;

            // Assert
            Exception ex = Assert.Throws<ArgumentNullException>(() => Ensure.NotNull(variableName, nameof(variableName)));

            // Act
            Assert.Equal("Variable cannot be null.", ex.Message);
        }

        [Test]
        public void NotNullCheckShouldNotThrowArgumentNullExceptionIfVariableIsNotNull()
        {
            string variableName = "Test";

            Ensure.NotNull(variableName, nameof(variableName));
        }

        [Test]
        public void NotNullOrEmptyCheckShouldThrowArgumentNullExceptionIfVariableIsNull()
        {
            // Arrange
            string variableName = null;

            // Assert
            Exception ex = Assert.Throws<ArgumentNullException>(() => Ensure.NotNullOrEmpty(variableName, nameof(variableName)));

            // Act
            Assert.Equal("Variable cannot be null.", ex.Message);
        }

        [Test]
        public void NotNullOrEmptyCheckShouldThrowArgumentExceptionIfVariableIsEmptyString()
        {
            // Arrange
            string variableName = "";

            // Assert
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrEmpty(variableName, nameof(variableName)));

            // Act
            Assert.Equal("Variable cannot be an empty string.", ex.Message);
        }

        [Test]
        public void NotNullOrEmptyCheckShouldNotThrowExceptionIfVariableIsNotNull()
        {
            // Arrange
            string variableName = "Test";

            Ensure.NotNullOrEmpty(variableName, nameof(variableName));
        }
    }
}
