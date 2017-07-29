using System;
#if Expressions_Supported
using System.Linq.Expressions;
#endif
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
            Assert.Equal($"{nameof(variableName)} cannot be null.", ex.Message);
        }

        [Test]
        public void NotNullExpressionCheckShouldThrowArgumentNullExceptionIfInputIsNullButIsNotDeclaredAsVariable()
        {
            // Assert
            Exception ex = Assert.Throws<ArgumentNullException>(() => Ensure.NotNull(() => (string)null));

            // Act
            Assert.Equal("Variable cannot be null.", ex.Message);
        }

        [Test]
        public void NotNullExpressionCheckShouldThrowArgumentExceptionIfExpressionIsNull()
        {
            // Assert
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNull((Expression<Func<string>>)null));

            // Act
            Assert.Equal("Expression cannot be null.", ex.Message);
        }

        [Test]
        public void NotNullExpressionCheckShouldNotThrowExceptionIfVariableIsNotNull()
        {
            // Arrange
            string variableName = "Test";

            // Assert
            IEnsurable<string> ensurable = Ensure.NotNull(() => variableName);

            // Act
            Assert.Equal(ensurable.Value, variableName);
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
            Assert.Equal($"{nameof(variableName)} cannot be null.", ex.Message);
        }

        [Test]
        public void NotNullCheckShouldNotThrowArgumentNullExceptionIfVariableIsNotNull()
        {
            string variableName = "Test";

            string result = Ensure.NotNull(variableName, nameof(variableName)).Value;

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
            Assert.Equal($"{nameof(variableName)} cannot be null.", ex.Message);
        }

        [Test]
        public void NotNullOrEmptyCheckShouldThrowArgumentExceptionIfVariableIsEmptyString()
        {
            // Arrange
            string variableName = "";

            // Assert
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrEmpty(variableName, nameof(variableName)));

            // Act
            Assert.Equal($"{nameof(variableName)} cannot be an empty string.", ex.Message);
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
