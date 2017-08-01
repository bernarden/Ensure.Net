using System;
using System.Collections.Generic;
using Ensure.Net.Tests.Helpers;

namespace Ensure.Net.Tests
{
    [TestFixture]
    public class EnsureTest
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

        [Test]
        public void NotNullOrEmptyCheckShouldThrowArgumentNullExceptionIfVariableIsNull()
        {
            // Arrange
            string variableName = null;

            // Act
            Exception ex = Assert.Throws<ArgumentNullException>(() => Ensure.NotNullOrEmpty(variableName, nameof(variableName)));

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot be null.", ex.Message);
        }

        [Test]
        public void NotNullOrEmptyCheckShouldThrowArgumentExceptionIfVariableIsEmptyString()
        {
            // Arrange
            string variableName = "";

            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrEmpty(variableName, nameof(variableName)));

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot be an empty string.", ex.Message);
        }

        [Test]
        public void NotNullOrEmptyCheckShouldNotThrowExceptionIfVariableIsNotNull()
        {
            // Arrange
            string variableName = "Test";

            // Act
            IEnsurable<string> result = Ensure.NotNullOrEmpty(variableName, nameof(variableName));

            // Assert
            Assert.Equal(result.Value, variableName);
        }

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

        [Test]
        public void NotNullOrEmptyListCheckShouldNotThrowExceptionIfVariableIsNotEmpty()
        {
            // Arrange
            List<string> variableName = new List<string> { "element" };

            // Act
            IEnsurable<IEnumerable<string>> result = Ensure.NotNullOrEmpty(variableName, nameof(variableName));

            // Assert
            Assert.Equal(result.Value, variableName);
        }

        [Test]
        public void NotNullOrEmptyListCheckShouldNotThrowExceptionIfQueueVariableIsNotEmpty()
        {
            // Arrange
            Queue<string> variableName = new Queue<string>();
            variableName.Enqueue("element-1");
            variableName.Enqueue("element-2");

            // Act
            IEnsurable<IEnumerable<string>> result = Ensure.NotNullOrEmpty(variableName, nameof(variableName));

            // Assert
            Assert.Equal(result.Value, variableName);
        }

        [Test]
        public void NotNullOrEmptyListCheckShouldThrowArgumentExceptionIfVariableIsEmpty()
        {
            // Arrange
            string[] variableName = new string[0];

            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrEmpty(variableName, nameof(variableName)));

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot be an empty.", ex.Message);
        }

        [Test]
        public void NotNullOrEmptyListCheckShouldThrowArgumentNullExceptionIfVariableIsNull()
        {
            // Arrange
            List<string> variableName = null;

            // Act
            Exception ex = Assert.Throws<ArgumentNullException>(() => Ensure.NotNullOrEmpty(variableName, nameof(variableName)));

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot be null.", ex.Message);
        }

        [Test]
        public void NotNullOrEmptyListCheckShouldThrowArgumentNullExceptionWithCorrectMessageIfVariableNameIsNull()
        {
            // Act
            Exception ex = Assert.Throws<ArgumentNullException>(() => Ensure.NotNullOrEmpty(null, null));

            // Assert
            Assert.Equal("Variable cannot be null.", ex.Message);
        }
    }
}
