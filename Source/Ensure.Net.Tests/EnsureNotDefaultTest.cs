using System;
using Vima.Ensure.Net.Tests.Helpers;

namespace Vima.Ensure.Net.Tests
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
        public void NotDefaultCheckShouldNotThrowExceptionIfGuidVariableIsSetToNewGuid()
        {
            // Arrange
            Guid variableName = Guid.NewGuid();

            // Act
            IEnsurable<Guid> result = Ensure.NotDefault(variableName, nameof(variableName));

            // Assert
            Assert.Equal(result.Value, variableName);
        }

        [Test]
        public void NotDefaultCheckShouldNotThrowExceptionIfVariableIsNotNull()
        {
            // Arrange
            string variableName = "Test";

            // Act
            IEnsurable<string> result = Ensure.NotDefault(variableName, nameof(variableName));

            // Assert
            Assert.Equal(result.Value, variableName);
        }

        [Test]
        public void NotDefaultCheckShouldNotThrowExceptionIfIntegerVariableHasNotDefaultValue()
        {
            // Arrange
            int variableName = 5;

            // Act
            IEnsurable<int> result = Ensure.NotDefault(variableName, nameof(variableName));

            // Assert
            Assert.Equal(result.Value, variableName);
        }

        [Test]
        public void NotDefaultCheckShouldNotThrowExceptionIfNullableStructIsNotNull()
        {
            // Arrange
            Guid? variableName = Guid.NewGuid();

            // Act
            IEnsurable<Guid> result = Ensure.NotDefault(variableName, nameof(variableName));

            // Assert
            Assert.Equal(result.Value, variableName);
        }

        [Test]
        public void NotDefaultCheckShouldThrowArgumentNullExceptionIfNullableStructIsNull()
        {
            // Arrange
            Guid? variableName = null;

            // Act
            Exception ex = Assert.Throws<ArgumentNullException>(() => Ensure.NotDefault(variableName, nameof(variableName)));

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot be null.", ex.Message);
        }

#if Expressions_Supported

        [Test]
        public void NotDefaultExpressionCheckShouldThrowArgumentExceptionIfVariableIsNull()
        {
            // Arrange
            string variableName = null;

            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotDefault(() => variableName));

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot be set to default value.", ex.Message);
        }

        [Test]
        public void NotDefaultExpressionCheckShouldThrowArgumentExceptionIfStringIsNullButIsNotDeclaredAsVariable()
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

        [Test]
        public void NotDefaultExpressionCheckShouldNotThrowExceptionIfNullableStructIsNotNull()
        {
            // Arrange
            Guid? variableName = Guid.NewGuid();

            // Act
            IEnsurable<Guid> result = Ensure.NotDefault(() => variableName);

            // Assert
            Assert.Equal(result.Value, variableName);
        }

        [Test]
        public void NotDefaultExpressionCheckShouldThrowArgumentNullExceptionIfNullableStructIsNull()
        {
            // Arrange
            Guid? variableName = null;

            // Act
            Exception ex = Assert.Throws<ArgumentNullException>(() => Ensure.NotDefault(() => variableName));

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot be null.", ex.Message);
        }
#endif
    }
}