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
    /// new List&lt;System.Net.Security.TlsCipherSuite&gt;
    /// {
    ///     System.Net.Security.TlsCipherSuite.TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384,
    ///     System.Net.Security.TlsCipherSuite.TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256
    /// }
    /// </example>
    public List<TlsCipherSuite> Policies { get; init; } = new();
}
