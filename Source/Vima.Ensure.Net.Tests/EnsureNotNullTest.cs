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
            Exception ex1 = Assert.Throws<ArgumentNullException>(() => Ensure.NotNull(variableName, nameof(variableName)));
            Exception ex2 = Assert.Throws<ArgumentNullException>(() => Ensure.NotNull(variableName));

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot be null.", ex1.Message);
            Assert.Equal("Variable cannot be null.", ex2.Message);
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

        [Test]
        public void NotNullCheckShouldThrowArgumentNullExceptionForNullStructValue()
        {
            // Arrange
            Guid? variableName = null;

            // Act
            Exception ex1 = Assert.Throws<ArgumentNullException>(() => Ensure.NotNull(variableName, nameof(variableName)));
            Exception ex2 = Assert.Throws<ArgumentNullException>(() => Ensure.NotNull(variableName));

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot be null.", ex1.Message);
            Assert.Equal("Variable cannot be null.", ex2.Message);
        }

        [Test]
        public void NotNullCheckShouldNotThrowArgumentNullExceptionForNotNullStructValue()
        {
            // Arrange
            int? variableName = 5;

            // Act
            IEnsurable<int> result = Ensure.NotNull(variableName, nameof(variableName));

            // Assert
            Assert.Equal(result.Value, variableName);
        }
    }
}