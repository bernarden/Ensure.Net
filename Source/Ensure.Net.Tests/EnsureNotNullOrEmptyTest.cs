using System;
using Ensure.Net.Tests.Helpers;
using System.Collections.Generic;

namespace Ensure.Net.Tests
{
    [TestFixture]
    public class EnsureNotNullOrEmptyTest
    {
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

#if Expressions_Supported

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
        public void
            NotNullOrEmptyExpressionCheckShouldThrowArgumentNullExceptionIfInputIsNullButIsNotDeclaredAsVariable()
        {
            // Act
            Exception ex = Assert.Throws<ArgumentNullException>(() => Ensure.NotNullOrEmpty(() => null));

            // Assert
            Assert.Equal("Variable cannot be null.", ex.Message);
        }

        [Test]
        public void
            NotNullOrEmptyExpressionCheckShouldThrowArgumentExceptionIfInputIsEmptyStringButIsNotDeclaredAsVariable()
        {
            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrEmpty(() => ""));

            // Assert
            Assert.Equal("Variable cannot be an empty string.", ex.Message);
        }

        [Test]
        public void
            NotNullOrEmptyExpressionCheckShouldThrowArgumentExceptionIfInputIsStringDotEmptyButIsNotDeclaredAsVariable()
        {
            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrEmpty(() => string.Empty));

            // Assert
            Assert.Equal("Empty cannot be an empty string.", ex.Message);
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
        public void NotNullOrEmptyListExpressionCheckShouldThrowArgumentNullExceptionIfVariableIsNull()
        {
            // Arrange
            List<string> variableName = null;

            // Act
            Exception ex = Assert.Throws<ArgumentNullException>(() => Ensure.NotNullOrEmpty(() => variableName));

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot be null.", ex.Message);
        }

        [Test]
        public void NotNullOrEmptyListExpressionCheckShouldNotThrowExceptionIfVariableIsNotEmpty()
        {
            // Arrange
            List<string> variableName = new List<string> { "element" };

            // Act
            IEnsurable<IEnumerable<string>> result = Ensure.NotNullOrEmpty(() => variableName);

            // Assert
            Assert.Equal(result.Value, variableName);
        }
#endif
    }
}