namespace Ensure.Net.Tests.Helpers
{
    public class TestFixtureAttribute :
#if XUnit
    System.Attribute
#else
    NUnit.Framework.TestFixtureAttribute
#endif
    {
    }
}