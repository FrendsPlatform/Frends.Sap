namespace Frends.Sap.ODataRequest.Definitions;

using System.Collections.Generic;
using System.ComponentModel;

/// <summary>
/// Input parameters.
/// </summary>
public class Input
{
    /// <summary>
    /// Username used to connect with Basic Auth.
    /// </summary>
    /// <example>user1</example>
    public string Username { get; init; }

    /// <summary>
    /// Password used to connect with Basic Auth.
    /// </summary>
    /// <example>SuperStrongPassw0rd</example>
    [PasswordPropertyText]
    public string Password { get; init; }

    /// <summary>
    /// Host Address.
    /// </summary>
    /// <example>example.com</example>
    [DefaultValue("example.com")]
    public string HostAddress { get; init; }

    /// <summary>
    /// Port to connect.
    /// </summary>
    /// <example>44301</example>
    [DefaultValue(44301)]
    public int Port { get; init; }

    /// <summary>
    /// Service name.
    /// </summary>
    /// <example>PAYMENTS</example>
    [DefaultValue("FAP_APPROVEBANKPAYMENTS_SRV")]
    public string ServiceName { get; init; }

    /// <summary>
    /// Entity set name.
    /// </summary>
    /// <example>A_Set</example>
    [DefaultValue("C_AbpPaymentBatch")]
    public string EntitySetName { get; init; }

    /// <summary>
    /// Query parameters from which query string will be constructed.
    /// </summary>
    /// <example>{ { "$skip", "1" }, { "$format", "xlsx" } }</example>
    public Dictionary<string, string> QueryParameters { get; init; } = new();
}
