using System;

namespace Ensure.Net.Tests.Helpers
{
    public class Assert
    {
        public static Exception Throws<T>(Func<object> func) where T : Exception
        {
#if XUnit
            return Xunit.Assert.Throws<T>(func);
#else
            return NUnit.Framework.Assert.Throws<T>(() => func());
#endif
        }

        public static void Equal(string value, string expectedValue)
        {
#if XUnit
            Xunit.Assert.Equal(value, expectedValue);
#else
            NUnit.Framework.Assert.AreEqual(expectedValue, value);
#endif
        }
    }
}