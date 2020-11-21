using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Vima.Ensure.Net.Tests.Helpers;

namespace Vima.Ensure.Net.Tests
{
    [TestFixture]
    [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
    [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
    public class EnsureNotNullOrEmptyTest
    {
        [Test]
        public void NotNullOrEmptyCheckShouldThrowArgumentNullExceptionIfVariableIsNull()
        {
            // Arrange
            string variableName = null;

            // Act
            Exception ex1 = Assert.Throws<ArgumentNullException>(() => Ensure.NotNullOrEmpty(variableName, nameof(variableName)));
            Exception ex2 = Assert.Throws<ArgumentNullException>(() => Ensure.NotNullOrEmpty(variableName));

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot be null.", ex1.Message);
            Assert.Equal("Variable cannot be null.", ex2.Message);
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
            IEnsurable<List<string>> result = Ensure.NotNullOrEmpty(variableName, nameof(variableName));

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
            IEnsurable<Queue<string>> result = Ensure.NotNullOrEmpty(variableName, nameof(variableName));

            // Assert
            Assert.Equal(result.Value, variableName);
        }

        [Test]
        public void NotNullOrEmptyListCheckShouldThrowArgumentExceptionIfVariableIsEmpty()
        {
            // Arrange
            string[] variableName = new string[0];

            // Act
            Exception ex1 = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrEmpty(variableName, nameof(variableName)));
            Exception ex2 = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrEmpty(variableName));

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot be empty.", ex1.Message);
            Assert.Equal("Variable cannot be empty.", ex2.Message);
        }

        [Test]
        public void NotNullOrEmptyDictionaryCheckShouldThrowArgumentExceptionIfVariableIsEmpty()
        {
            // Arrange
            IDictionary variableName = new Dictionary<string, string>();

            // Act
            Exception ex1 = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrEmpty(variableName, nameof(variableName)));
            Exception ex2 = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrEmpty(variableName));

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot be empty.", ex1.Message);
            Assert.Equal("Variable cannot be empty.", ex2.Message);
        }        
        
        [Test]
        public void NotNullOrEmptyGenericDictionaryCheckShouldThrowArgumentExceptionIfVariableIsEmpty()
        {
            // Arrange
            IDictionary<string,string> variableName = new Dictionary<string, string>();

            // Act
            Exception ex1 = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrEmpty(variableName, nameof(variableName)));
            Exception ex2 = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrEmpty(variableName));           

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot be empty.", ex1.Message);
            Assert.Equal("Variable cannot be empty.", ex2.Message);
        }

        [Test]
        public void NotNullOrEmptyDictionaryCheckShouldNotThrowExceptionIfIsNotEmpty()
        {
            // Arrange
            IDictionary variableName = new Dictionary<string, string> {{"Key", "Value"}};

            // Act
            IEnsurable<IDictionary> result1 = Ensure.NotNullOrEmpty(variableName, nameof(variableName));
            IEnsurable<IDictionary> result2 = Ensure.NotNullOrEmpty(variableName);

            // Assert
            Assert.Equal(result1.Value, variableName);
            Assert.Equal(result2.Value, variableName);
        }

        [Test]
        public void NotNullOrEmptyGenericDictionaryCheckShouldNotThrowExceptionIfIsNotEmpty()
        {
            // Arrange
            IDictionary<string, string> variableName = new Dictionary<string, string> { { "Key", "Value" } };

            // Act
            IEnsurable<IDictionary<string, string>> result1 = Ensure.NotNullOrEmpty(variableName, nameof(variableName));
            IEnsurable<IDictionary<string, string>> result2 = Ensure.NotNullOrEmpty(variableName);

            // Assert
            Assert.Equal(result1.Value, variableName);
            Assert.Equal(result2.Value, variableName);
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
        public void NotNullOrEmptyListCheckShouldNotThrowExceptionIfListOfNullableStructIsNotNullOrEmpty()
        {
            // Arrange
            List<Guid?> variableName = new List<Guid?> { Guid.NewGuid(), null };

            // Act
            IEnsurable<List<Guid?>> result = Ensure.NotNullOrEmpty(variableName, nameof(variableName));

            // Assert
            Assert.Equal(result.Value, variableName);
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