namespace Frends.Sap.ODataRequest.Tests.tests;

using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

public class Tests : TestsBase
{
    [Test]
    public async Task RequestReturnSuccess()
    {
        var result = await Sap.ODataRequest(BasicInput(), TestOptions(), CancellationToken.None);
        Assert.AreEqual(200, result.StatusCode);
    }

    [Test]
    public async Task RequestWithQueryReturnSuccess()
    {
        var result = await Sap.ODataRequest(
            InputWithQuery(),
            TestOptions(),
            CancellationToken.None);
        Assert.AreEqual(200, result.StatusCode);
    }
}
