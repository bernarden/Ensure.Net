namespace Ensure.Net.Tests.Helpers
{
    public class TestFixtureAttribute :
#if NETSTANDARD 
    System.Attribute
#else
    NUnit.Framework.TestFixtureAttribute
#endif
    {
    }
}