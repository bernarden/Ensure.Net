#if Expressions_Supported
using System;
using System.Linq.Expressions;
using Ensure.Net.Tests.Helpers;

namespace Ensure.Net.Tests
{
    [TestFixture]
    public class EnsureExpressionsTest
    {
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
        public void NotNullExpressionCheckShouldThrowArgumentExceptionIfExpressionIsNull()
        {
            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNull((Expression<Func<string>>)null));

            // Assert
            Assert.Equal("Expression cannot be null.", ex.Message);
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

        [Test]
        public void NotNullExpressionCheckShouldThrowArgumentExceptionIfExpressionIsNotMemberExpression()
        {
            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNull(() => string.Empty + string.Empty));

            // Assert
            Assert.Equal("Expression must be of type MemberExpression.", ex.Message);
        }

        [Test]
        public void NotNullOrEmptyExpressionCheckShouldThrowArgumentNullExceptionIfVariableIsNull()
        {
            // Arrange
            string variableName = null;

            // Act
            Exception ex = Assert.Throws<ArgumentNullException>(() => Ensure.NotNullOrEmpty(() => variableName));

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot be null.", ex.Message);
        }

        [Test]
        public void NotNullOrEmptyExpressionCheckShouldThrowArgumentExceptionIfVariableIsEmpty()
        {
            // Arrange
            string variableName = string.Empty;

            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrEmpty(() => variableName));

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot be an empty string.", ex.Message);
        }

        [Test]
        public void NotNullOrEmptyExpressionCheckShouldThrowArgumentNullExceptionIfInputIsNullButIsNotDeclaredAsVariable()
        {
            // Act
            Exception ex = Assert.Throws<ArgumentNullException>(() => Ensure.NotNullOrEmpty(() => null));

            // Assert
            Assert.Equal("Variable cannot be null.", ex.Message);
        }

        [Test]
        public void NotNullOrEmptyExpressionCheckShouldThrowArgumentExceptionIfInputIsEmptyStringButIsNotDeclaredAsVariable()
        {
            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrEmpty(() => ""));

            // Assert
            Assert.Equal("Variable cannot be an empty string.", ex.Message);
        }

        [Test]
        public void NotNullOrEmptyExpressionCheckShouldThrowArgumentExceptionIfInputIsStringDotEmptyButIsNotDeclaredAsVariable()
        {
            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrEmpty(() => string.Empty));

            // Assert
            Assert.Equal("Empty cannot be an empty string.", ex.Message);
        }

        [Test]
        public void NotNullOrEmptyExpressionCheckShouldThrowArgumentExceptionIfExpressionIsNull()
        {
            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrEmpty(null));

            // Assert
            Assert.Equal("Expression cannot be null.", ex.Message);
        }

        [Test]
        public void NotNullOrEmptyExpressionCheckShouldNotThrowExceptionIfVariableIsNotNull()
        {
            // Arrange
            string variableName = "Test";

            // Act
            IEnsurable<string> ensurable = Ensure.NotNullOrEmpty(() => variableName);

            // Assert
            Assert.Equal(ensurable.Value, variableName);
        }

        [Test]
        public void NotNullOrEmptyExpressionCheckShouldThrowArgumentExceptionIfExpressionIsNotMemberExpression()
        {
            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrEmpty(() => string.Empty + string.Empty));

            // Assert
            Assert.Equal("Expression must be of type MemberExpression.", ex.Message);
        }

        [Test]
        public void NotDefaultExpressionCheckShouldThrowArgumentNullExceptionIfVariableIsNull()
        {
            // Arrange
            string variableName = null;

            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotDefault(() => variableName));

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot be set to default value.", ex.Message);
        }

        [Test]
        public void NotDefaultExpressionCheckShouldThrowArgumentNullExceptionIfStringIsNullButIsNotDeclaredAsVariable()
        {
            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotDefault(() => (string)null));

            // Assert
            Assert.Equal("Variable cannot be set to default value.", ex.Message);
        }

        [Test]
        public void NotDefaultExpressionCheckShouldThrowArgumentExceptionIfExpressionIsNull()
        {
            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotDefault((Expression<Func<string>>)null));

            // Assert
            Assert.Equal("Expression cannot be null.", ex.Message);
        }

        [Test]
        public void NotDefaultExpressionCheckShouldNotThrowExceptionIfVariableIsNotDefault()
        {
            // Arrange
            string variableName = "Test";

            // Act
            IEnsurable<string> ensurable = Ensure.NotDefault(() => variableName);

            // Assert
            Assert.Equal(ensurable.Value, variableName);
        }

        [Test]
        public void NotDefaultExpressionCheckShouldThrowArgumentExceptionIfExpressionIsNotMemberExpression()
        {
            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotDefault(() => string.Empty + string.Empty));

            // Assert
            Assert.Equal("Expression must be of type MemberExpression.", ex.Message);
        }
    }
}
#endif