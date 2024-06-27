namespace Frends.Sap.ODataRequest.Tests.tests;

using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Nodes;
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

    [Test]
    public async Task RequestIsInProperFormat()
    {
        var result = await Sap.ODataRequest(BasicInput(), TestOptions(), CancellationToken.None);
        Assert.AreEqual(200, result.StatusCode);
        Assert.DoesNotThrow(() => JsonDocument.Parse(result.Data));
    }

    [Test]
    public void ThrowsIfResponseFormatIsNotProvided()
    {
        Assert.ThrowsAsync<InvalidEnumArgumentException>(
            async () =>
                await Sap.ODataRequest(
                    InputWithoutResponseFormat(),
                    TestOptions(),
                    CancellationToken.None));
    }
}
