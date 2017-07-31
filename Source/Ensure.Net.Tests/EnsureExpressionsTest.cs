#if Expressions_Supported
using System;
using System.Linq.Expressions;
using Ensure.Net.Tests.Helpers;

namespace Ensure.Net.Tests
{
    public partial class EnsureTest
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
            Exception ex = Assert.Throws<ArgumentNullException>(() => Ensure.NotNull(() => (string) null));

            // Act
            Assert.Equal("Variable cannot be null.", ex.Message);
        }

        [Test]
        public void NotNullExpressionCheckShouldThrowArgumentExceptionIfExpressionIsNull()
        {
            // Assert
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNull((Expression<Func<string>>) null));

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
    }
}
#endif