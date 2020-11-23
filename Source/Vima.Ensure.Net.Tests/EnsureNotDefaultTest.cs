using System;
using System.Collections.Generic;
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
            string? variableName = null;

            // Act
            Exception ex1 = Assert.Throws<ArgumentException>(() => Ensure.NotDefault(variableName, nameof(variableName)));
            Exception ex2 = Assert.Throws<ArgumentException>(() => Ensure.NotDefault(variableName));

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot be set to the default value.", ex1.Message);
            Assert.Equal("Variable cannot be set to the default value.", ex2.Message);
        }

        [Test]
        public void NotDefaultCheckShouldThrowArgumentExceptionIfGuidVariableIsEmpty()
        {
            // Arrange
            Guid variableName = Guid.Empty;

            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotDefault(variableName, nameof(variableName)));

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot be set to the default value.", ex.Message);
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
        public void NotDefaultCheckShouldReturnNonNullableTypeBackWhenNullableReferenceTypeIsSpecified()
        {
            // Arrange
            // ReSharper disable once VariableCanBeNotNullable
            Queue<string>? variableName = new Queue<string>();

            // Act
            IEnsurable<Queue<string>> result = Ensure.NotDefault(variableName, nameof(variableName));

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
        public void NotDefaultCheckShouldNotThrowExceptionIfNullableStructIsSetToDefaultValue()
        {
            // Arrange
            Guid? variableName = Guid.Empty;

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
            Exception ex1 = Assert.Throws<ArgumentNullException>(() => Ensure.NotDefault(variableName, nameof(variableName)));
            Exception ex2 = Assert.Throws<ArgumentNullException>(() => Ensure.NotDefault(variableName));

            // Assert
            Assert.Equal($"{nameof(variableName)} cannot be null.", ex1.Message);
            Assert.Equal("Variable cannot be null.", ex2.Message);
        }
    }
}