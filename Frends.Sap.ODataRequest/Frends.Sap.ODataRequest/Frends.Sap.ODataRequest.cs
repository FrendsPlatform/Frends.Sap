namespace Frends.Sap.ODataRequest;

using System;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
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
    public static async Task<Result> ODataRequest(
        [PropertyTab] Input input,
        CancellationToken cancellationToken)
    {
        var client = GetAuthorizedClient(input);
        var uri = GetFullUri(input);
        var response = await client.GetAsync(uri, cancellationToken);
        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
        return new Result { StatusCode = (int)response.StatusCode, Content = responseContent, };
    }

    private static HttpClient GetAuthorizedClient(Input input)
    {
        HttpClientHandler clientHandler =
            new()
            {
                ServerCertificateCustomValidationCallback = (_, _, _, _) =>
                {
                    return true;
                },
            };
        var client = new HttpClient(clientHandler);
        var authenticationString = $"{input.Username}:{input.Password}";
        var base64EncodedAuthenticationString = Convert.ToBase64String(
            Encoding.ASCII.GetBytes(authenticationString));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            "Basic",
            base64EncodedAuthenticationString);
        return client;
    }

    private static Uri GetFullUri(Input input)
    {
        var baseUri = new Uri(
            $"{input.HostAddress}:{input.Port}/{Constants.ODataPrefix.Trim('/')}/{input.ServiceName.Trim('/')}/{input.EntitySetName.Trim('/')}");

        var uriBuilder = new UriBuilder(baseUri);
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        foreach (var param in input.QueryParameters)
        {
            query.Add(param.Key, param.Value);
        }

        uriBuilder.Query = query.ToString();
        return uriBuilder.Uri;
    }
}
