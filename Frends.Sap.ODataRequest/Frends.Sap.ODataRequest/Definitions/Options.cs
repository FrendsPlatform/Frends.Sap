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
    /// Option supress RemoteCertificateValidationCallback, which accepts any certificate.
    /// </summary>
    /// <example>false</example>
    [DefaultValue(false)]
    public bool AcceptAnyCertificate { get; init; }

    /// <summary>
    /// Use when your system's default cipher set does not include SAP ciphers by default, for example on Linux with OpenSSL 1.1.1 default installation.
    /// </summary>
    /// <example>
    /// [
    ///   "TlsCipherSuite.TLS_RSA_WITH_AES_256_CBC_SHA",
    ///   "TlsCipherSuite.TLS_RSA_WITH_AES_128_CBC_SHA"
    /// ]
    /// </example>
    public List<TlsCipherSuite> Policices { get; init; } = new();
}
