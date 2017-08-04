using System;
using Ensure.Net.Tests.Helpers;

namespace Ensure.Net.Tests
{
    [TestFixture]
    public class EnsureNotDefaultTest
    {
        [Test]
        public void NotDefaultCheckShouldThrowArgumentExceptionIfStringVariableIsNull()
        {
            // Arrange
            string variableName = null;

            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotDefault(variableName, nameof(variableName)));

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot be set to default value.", ex.Message);
        }

        [Test]
        public void NotDefaultCheckShouldThrowArgumentExceptionIfGuidVariableIsEmpty()
        {
            // Arrange
            Guid variableName = Guid.Empty;

            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotDefault(variableName, nameof(variableName)));

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot be set to default value.", ex.Message);
        }

        [Test]
        public void NotDefaultCheckShouldNotThrowArgumentExceptionIfGuidVariableIsSetToNewGuid()
        {
            // Arrange
            Guid variableName = Guid.NewGuid();

            // Act
            IEnsurable<Guid> result = Ensure.NotDefault(variableName, nameof(variableName));

            // Assert
            Assert.Equal(result.Value, variableName);
        }

        [Test]
        public void NotDefaultCheckShouldNotThrowArgumentNullExceptionIfVariableIsNotNull()
        {
            // Arrange
            string variableName = "Test";

            // Act
            IEnsurable<string> result = Ensure.NotDefault(variableName, nameof(variableName));

            // Assert
            Assert.Equal(result.Value, variableName);
        }

#if Expressions_Supported

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
        public void NotDefaultExpressionCheckShouldNotThrowExceptionIfVariableIsNotDefault()
        {
            // Arrange
            string variableName = "Test";

            // Act
            IEnsurable<string> ensurable = Ensure.NotDefault(() => variableName);

            // Assert
            Assert.Equal(ensurable.Value, variableName);
        }
#endif
    }
}