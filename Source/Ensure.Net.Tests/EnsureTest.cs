using System;
using Ensure.Net.Tests.Helpers;

namespace Ensure.Net.Tests
{
    [TestFixture]
    public class EnsureTest
    {

#if Expressions_Supported
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
            Exception ex = Assert.Throws<ArgumentNullException>(() => Ensure.NotNull<string>(variableName, nameof(variableName)));

            // Act
            Assert.Equal("Variable cannot be null.", ex.Message);
        }

        [Test]
        public void NotNullCheckShouldNotThrowArgumentNullExceptionIfVariableIsNotNull()
        {
            string variableName = "Test";

            string result = Ensure.NotNull<string>(variableName, nameof(variableName)).Value;

            Assert.Equal(result, variableName);
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

            string result = Ensure.NotNullOrEmpty(variableName, nameof(variableName)).Value;

            Assert.Equal(result, variableName);
        }
    }
}
