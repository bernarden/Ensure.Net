using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;

namespace Vima.Ensure.Net.Tests;

public class ExtensionsTest
{
    [Fact]
    public void IsEmptyShouldBeAbleToHandleCollection()
    {
        // Arrange
        Collection<long> collection = new Collection<long> {1};

        // Act
        bool isEmpty = Extensions.IsEmpty(collection);

        // Assert
        Assert.False(isEmpty);
    }

    [Fact]
    public void IsEmptyShouldBeAbleToHandleFilledNonCollectionEnumerables()
    {
        // Arrange
        long expectedCount = 5;
        IEnumerable enumerable = new CustomEnumerable<long>(expectedCount);

        // Act
        bool isEmpty = Extensions.IsEmpty(enumerable);

        // Assert
        Assert.False(isEmpty);
    }

    [Fact]
    public void IsEmptyShouldBeAbleToHandleEmptyNonCollectionEnumerables()
    {
        // Arrange
        IEnumerable enumerable = new CustomEnumerable<long>();

        // Act
        bool isEmpty = Extensions.IsEmpty(enumerable);

        // Assert
        Assert.True(isEmpty);
    }

    [Fact]
    public void CustomEnumerableAndCustomEnumeratorTest()
    {
        // Arrange
        long expectedCount = 15;
        CustomEnumerable<long> enumerable = new CustomEnumerable<long>(expectedCount);
        IEnumerator enumerator = ((IEnumerable) enumerable).GetEnumerator();

        // Act
        bool next = enumerator.MoveNext();
        long? firstCurrent = (long?) enumerator.Current;
        enumerator.Reset();
        long secondCurrent = ((IEnumerator<long>) enumerator).Current;

        // Assert
        Assert.True(next);
        Assert.Equal(1L, firstCurrent.GetValueOrDefault());
        Assert.Equal(0L, secondCurrent);
    }
}

internal class CustomEnumerable<T> : IEnumerable<T>
{
    private readonly long _numberOfStates;

    public CustomEnumerable(long numberOfStates = 0)
    {
        _numberOfStates = numberOfStates;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new CustomEnumerator<T>(_numberOfStates);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

internal class CustomEnumerator<T> : IEnumerator<T>
{
    private readonly long _numberOfStates;
    private long _indexOfCurrentState;

    public CustomEnumerator(long i)
    {
        _numberOfStates = i;
    }

    public bool MoveNext()
    {
        if (_indexOfCurrentState >= _numberOfStates)
            return false;

        _indexOfCurrentState++;
        return true;
    }

    public void Reset()
    {
        _indexOfCurrentState = 0;
    }

    T IEnumerator<T>.Current => (T) Current;

    public object Current => _indexOfCurrentState;

    public void Dispose()
    {
    }
}