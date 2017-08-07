using System;
using Vima.Ensure.Net.Tests.Helpers;

namespace Vima.Ensure.Net.Tests
{
    [TestFixture]
    public class EnsureNotNullTest
    {
        [Test]
        public void NotNullCheckShouldThrowArgumentNullExceptionIfVariableIsNull()
        {
            // Arrange
            string variableName = null;

            // Act
            Exception ex = Assert.Throws<ArgumentNullException>(() => Ensure.NotNull(variableName, nameof(variableName)));

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot be null.", ex.Message);
        }

        [Test]
        public void NotNullCheckShouldNotThrowArgumentNullExceptionIfVariableIsNotNull()
        {
            // Arrange
            string variableName = "Test";

            // Act
            IEnsurable<string> result = Ensure.NotNull(variableName, nameof(variableName));

            // Assert
            Assert.Equal(result.Value, variableName);
        }

#if Expressions_Supported

        [Test]
        public void NotNullExpressionCheckShouldThrowArgumentNullExceptionIfVariableIsNull()
        {
            // Arrange
            string variableName = null;

            // Act
            Exception ex = Assert.Throws<ArgumentNullException>(() => Ensure.NotNull(() => variableName));

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot be null.", ex.Message);
        }

        [Test]
        public void NotNullExpressionCheckShouldThrowArgumentNullExceptionIfInputIsNullButIsNotDeclaredAsVariable()
        {
            // Act
            Exception ex = Assert.Throws<ArgumentNullException>(() => Ensure.NotNull(() => (string)null));

            // Assert
            Assert.Equal("Variable cannot be null.", ex.Message);
        }

        [Test]
        public void NotNullExpressionCheckShouldNotThrowExceptionIfVariableIsNotNull()
        {
            // Arrange
            string variableName = "Test";

            // Act
            IEnsurable<string> ensurable = Ensure.NotNull(() => variableName);

            // Assert
            Assert.Equal(ensurable.Value, variableName);
        }
#endif
    }
}