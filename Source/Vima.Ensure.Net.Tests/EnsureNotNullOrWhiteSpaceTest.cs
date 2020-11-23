using System;
using Vima.Ensure.Net.Tests.Helpers;

namespace Vima.Ensure.Net.Tests
{
    [TestFixture]
    public class EnsureNotNullOrWhiteSpaceTest
    {
        [Test]
        public void NotNullOrWhiteSpaceShouldThrowArgumentNullExceptionIfVariableIsNull()
        {
            // Arrange
            string? variableName = null;

            // Act
            Exception ex1 = Assert.Throws<ArgumentNullException>(() => Ensure.NotNullOrWhiteSpace(variableName, nameof(variableName)));
            Exception ex2 = Assert.Throws<ArgumentNullException>(() => Ensure.NotNullOrWhiteSpace(variableName));

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot be null.", ex1.Message);
            Assert.Equal("Variable cannot be null.", ex2.Message);
        }

        [Test]
        public void NotNullOrWhiteSpaceCheckShouldThrowArgumentExceptionIfVariableIsEmptyString()
        {
            // Arrange
            string variableName = "";

            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrWhiteSpace(variableName, nameof(variableName)));

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot be an empty string.", ex.Message);
        }

        [Test]
        public void NotNullOrWhiteSpaceCheckShouldNotThrowExceptionIfVariableIsNotNullOrContainsWhiteSpaceCharacters()
        {
            // Arrange
            string variableName = "Test";

            // Act
            IEnsurable<string> result = Ensure.NotNullOrWhiteSpace(variableName, nameof(variableName));

            // Assert
            Assert.Equal(result.Value, variableName);
        }

        [Test]
        public void NotNullOrWhiteSpaceCheckShouldNotThrowExceptionIfVariableStartsAndEndsWithWhiteSpaceCharacters()
        {
            // Arrange
            string variableName = " . ";

            // Act
            IEnsurable<string> result = Ensure.NotNullOrWhiteSpace(variableName, nameof(variableName));

            // Assert
            Assert.Equal(result.Value, variableName);
        }

        [Test]
        public void NotNullOrWhiteSpaceCheckShouldThrowArgumentExceptionIfVariableContainsOnlyWhiteSpaceCharacters()
        {
            // Arrange
            string variableName = "  ";

            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrWhiteSpace(variableName, nameof(variableName)));

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot contain only white space characters.", ex.Message);
        }

        [Test]
        public void NotNullOrWhiteSpaceListCheckShouldThrowArgumentNullExceptionWithCorrectMessageIfVariableNameIsNull()
        {
            // Act
            Exception ex = Assert.Throws<ArgumentNullException>(() => Ensure.NotNullOrWhiteSpace(null));

            // Assert
            Assert.Equal("Variable cannot be null.", ex.Message);
        }
    }
}