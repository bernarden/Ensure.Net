namespace Vima.Ensure.Net.Tests.Helpers
{
    public class TestAttribute :
#if XUnit
    Xunit.FactAttribute
#else
    NUnit.Framework.TestAttribute
#endif
    {
    }
}