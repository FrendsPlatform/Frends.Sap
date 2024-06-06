namespace Frends.Sap.ODataRequest.Definitions;

using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Security;

/// <summary>
/// Options parameters.
/// </summary>
public class Options
{
    /// <summary>
    /// Option supress RemoteCertificateValidationCallback, which disables ssl checking
    /// </summary>
    /// <example>false</example>
    [DefaultValue(false)]
    public bool DisableSsl { get; init; }

    /// <summary>
    /// Specifies the cipher suites allowed for TLS. Use only with Linux system with OpenSSL 1.1.1 or higher or a macOS
    /// </summary>
    /// <example>false</example>
    public List<TlsCipherSuite> Policices { get; init; } = new();
}
