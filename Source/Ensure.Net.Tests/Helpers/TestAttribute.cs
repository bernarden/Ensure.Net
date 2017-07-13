namespace Ensure.Net.Tests.Helpers
{
    public class TestAttribute :
#if NETSTANDARD
    Xunit.FactAttribute
#else
    NUnit.Framework.TestAttribute
#endif
    {
    }
}