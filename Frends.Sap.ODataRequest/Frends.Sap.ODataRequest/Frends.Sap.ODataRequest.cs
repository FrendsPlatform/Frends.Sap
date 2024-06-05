namespace Frends.Sap.ODataRequest;

using System.ComponentModel;
using System.Threading;
using Frends.Sap.ODataRequest.Definitions;

/// <summary>
/// Sap Task.
/// </summary>
public static class Sap
{
    /// <summary>
    /// Task to request OData.
    /// [Documentation](https://tasks.frends.com/tasks/frends-tasks/Frends.Sap.ODataRequest).
    /// </summary>
    /// <param name="input">inpup params.</param>
    /// <param name="cancellationToken">Cancellation token given by Frends.</param>
    /// <returns>Object { bool StatusCode, dynamic Content }.</returns>
    public static Result ODataRequest(
        [PropertyTab] Input input,
        CancellationToken cancellationToken)
    {
        return new Result();
    }
}
