using System;
using Xunit;

namespace Vima.Ensure.Net.Tests;

public class EnsureNotNullOrWhiteSpaceTest
{
    [Fact]
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

    [Fact]
    public void NotNullOrWhiteSpaceCheckShouldThrowArgumentExceptionIfVariableIsEmptyString()
    {
        // Arrange
        string variableName = "";

        // Act
        Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrWhiteSpace(variableName, nameof(variableName)));

        // Assert
        Assert.Equal($"{nameof(variableName)} cannot be an empty string.", ex.Message);
    }

    [Fact]
    public void NotNullOrWhiteSpaceCheckShouldNotThrowExceptionIfVariableIsNotNullOrContainsWhiteSpaceCharacters()
    {
        // Arrange
        string variableName = "Test";

        // Act
        IEnsurable<string> result = Ensure.NotNullOrWhiteSpace(variableName, nameof(variableName));

        // Assert
        Assert.Equal(variableName, result.Value);
    }

    [Fact]
    public void NotNullOrWhiteSpaceCheckShouldNotThrowExceptionIfVariableStartsAndEndsWithWhiteSpaceCharacters()
    {
        // Arrange
        string variableName = " . ";

        // Act
        IEnsurable<string> result = Ensure.NotNullOrWhiteSpace(variableName, nameof(variableName));

        // Assert
        Assert.Equal(variableName, result.Value);
    }

    [Fact]
    public void NotNullOrWhiteSpaceCheckShouldThrowArgumentExceptionIfVariableContainsOnlyWhiteSpaceCharacters()
    {
        // Arrange
        string variableName = "  ";

        // Act
        Exception ex = Assert.Throws<ArgumentException>(() => Ensure.NotNullOrWhiteSpace(variableName, nameof(variableName)));

        // Assert
        Assert.Equal($"{nameof(variableName)} cannot contain only white space characters.", ex.Message);
    }

    [Fact]
    public void NotNullOrWhiteSpaceListCheckShouldThrowArgumentNullExceptionWithCorrectMessageIfVariableNameIsNull()
    {
        // Act
        Exception ex = Assert.Throws<ArgumentNullException>(() => Ensure.NotNullOrWhiteSpace(null));

        // Assert
        Assert.Equal("Variable cannot be null.", ex.Message);
    }
}