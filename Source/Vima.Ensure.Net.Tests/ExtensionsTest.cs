using System.Collections;
using System.Collections.Generic;
using Vima.Ensure.Net.Tests.Helpers;

namespace Vima.Ensure.Net.Tests
{
    [TestFixture]
    public class ExtensionsTest
    {
        [Test]
        public void GetCountShouldBeAbleToHandleNonCollectionEnumerables()
        {
            // Arrange
            long expectedCount = 5;
            CustomEnumerable<long> enumerable = new CustomEnumerable<long>(expectedCount);

            // Act
            long count = Extensions.GetCount(enumerable);

            // Assert
            Assert.Equal(count, expectedCount);
        }

        [Test]
        public void CustomEnumerableAndCustomEnumeratorTest()
        {
            // Arrange
            long expectedCount = 15;
            CustomEnumerable<long> enumerable = new CustomEnumerable<long>(expectedCount);
            IEnumerator enumerator = ((IEnumerable)enumerable).GetEnumerator();

            // Act
            bool next = enumerator.MoveNext();
            long firstCurrent = (long)enumerator.Current;
            enumerator.Reset();
            long secondCurrent = ((IEnumerator<long>)enumerator).Current;

            // Assert
            Assert.Equal(next, true);
            Assert.Equal(firstCurrent, 1L);
            Assert.Equal(secondCurrent, 0L);
        }
    }

    internal class CustomEnumerable<T> : IEnumerable<T>
    {
        private readonly long _numberOfStates;

        public CustomEnumerable(long numberOfStates)
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

        T IEnumerator<T>.Current => (T)Current;

        public object Current => _indexOfCurrentState;

        public void Dispose()
        {
        }
    }
}