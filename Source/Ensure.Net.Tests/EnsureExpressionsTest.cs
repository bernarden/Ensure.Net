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

        [Test]
        public void NotNullExpressionCheckShouldThrowArgumentExceptionIfExpressionIsNotMemberExpression()
        {
            // Assert
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNull(() => string.Empty + string.Empty));

            // Act
            Assert.Equal("Expression must be of type MemberExpression.", ex.Message);
        }

        [Test]
        public void NotNullOrEmptyExpressionCheckShouldThrowArgumentNullExceptionIfVariableIsNull()
        {
            // Arrange
            string variableName = null;

            // Assert
            Exception ex = Assert.Throws<ArgumentNullException>(() => Ensure.NotNullOrEmpty(() => variableName));

            // Act
            Assert.Equal($"{nameof(variableName)} cannot be null.", ex.Message);
        }

        [Test]
        public void NotNullOrEmptyExpressionCheckShouldThrowArgumentExceptionIfVariableIsEmpty()
        {
            // Arrange
            string variableName = string.Empty;

            // Assert
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrEmpty(() => variableName));

            // Act
            Assert.Equal($"{nameof(variableName)} cannot be an empty string.", ex.Message);
        }

        [Test]
        public void NotNullOrEmptyExpressionCheckShouldThrowArgumentNullExceptionIfInputIsNullButIsNotDeclaredAsVariable()
        {
            // Assert
            Exception ex = Assert.Throws<ArgumentNullException>(() => Ensure.NotNullOrEmpty(() => null));

            // Act
            Assert.Equal("Variable cannot be null.", ex.Message);
        }

        [Test]
        public void NotNullOrEmptyExpressionCheckShouldThrowArgumentExceptionIfInputIsEmptyStringButIsNotDeclaredAsVariable()
        {
            // Assert
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrEmpty(() => ""));

            // Act
            Assert.Equal("Variable cannot be an empty string.", ex.Message);
        }

        [Test]
        public void NotNullOrEmptyExpressionCheckShouldThrowArgumentExceptionIfInputIsStringDotEmptyButIsNotDeclaredAsVariable()
        {
            // Assert
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrEmpty(() => string.Empty));

            // Act
            Assert.Equal("Empty cannot be an empty string.", ex.Message);
        }

        [Test]
        public void NotNullOrEmptyExpressionCheckShouldThrowArgumentExceptionIfExpressionIsNull()
        {
            // Assert
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrEmpty(null));

            // Act
            Assert.Equal("Expression cannot be null.", ex.Message);
        }

        [Test]
        public void NotNullOrEmptyExpressionCheckShouldNotThrowExceptionIfVariableIsNotNull()
        {
            // Arrange
            string variableName = "Test";

            // Assert
            IEnsurable<string> ensurable = Ensure.NotNullOrEmpty(() => variableName);

            // Act
            Assert.Equal(ensurable.Value, variableName);
        }

        [Test]
        public void NotNullOrEmptyExpressionCheckShouldThrowArgumentExceptionIfExpressionIsNotMemberExpression()
        {
            // Assert
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrEmpty(() => string.Empty + string.Empty));

            // Act
            Assert.Equal("Expression must be of type MemberExpression.", ex.Message);
        }

        [Test]
        public void NotDefaultExpressionCheckShouldThrowArgumentNullExceptionIfVariableIsNull()
        {
            // Arrange
            string variableName = null;

            // Assert
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotDefault(() => variableName));

            // Act
            Assert.Equal($"{nameof(variableName)} cannot be set to default value.", ex.Message);
        }

        [Test]
        public void NotDefaultExpressionCheckShouldThrowArgumentNullExceptionIfStringIsNullButIsNotDeclaredAsVariable()
        {
            // Assert
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotDefault(() => (string)null));

            // Act
            Assert.Equal("Variable cannot be set to default value.", ex.Message);
        }

        [Test]
        public void NotDefaultExpressionCheckShouldThrowArgumentExceptionIfExpressionIsNull()
        {
            // Assert
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotDefault((Expression<Func<string>>)null));

            // Act
            Assert.Equal("Expression cannot be null.", ex.Message);
        }

        [Test]
        public void NotDefaultExpressionCheckShouldNotThrowExceptionIfVariableIsNotDefault()
        {
            // Arrange
            string variableName = "Test";

            // Assert
            IEnsurable<string> ensurable = Ensure.NotDefault(() => variableName);

            // Act
            Assert.Equal(ensurable.Value, variableName);
        }

        [Test]
        public void NotDefaultExpressionCheckShouldThrowArgumentExceptionIfExpressionIsNotMemberExpression()
        {
            // Assert
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotDefault(() => string.Empty + string.Empty));

            // Act
            Assert.Equal("Expression must be of type MemberExpression.", ex.Message);
        }
    }
}
#endif