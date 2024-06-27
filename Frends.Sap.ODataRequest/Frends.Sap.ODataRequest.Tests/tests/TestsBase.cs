namespace Frends.Sap.ODataRequest.Tests.tests;

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Security;
using System.Runtime.InteropServices;
using dotenv.net;
using Frends.Sap.ODataRequest.Definitions;
using NUnit.Framework;
using NUnit.Framework.Internal;

[TestFixture]
public abstract class TestsBase
{
    protected static readonly string Username = Environment.GetEnvironmentVariable("USERNAME");
    protected static readonly string Password = Environment.GetEnvironmentVariable("PASSWORD");
    protected static readonly string Host = Environment.GetEnvironmentVariable("HOST");
    protected static readonly int Port = int.Parse(Environment.GetEnvironmentVariable("PORT"));

    [OneTimeSetUp]
    public static void AssemblyInit()
    {
        var root = Directory.GetCurrentDirectory();
        string projDir = Directory.GetParent(root).Parent.Parent.FullName;
        DotEnv.Load(
            options: new DotEnvOptions(
                envFilePaths: new[] { $"{projDir}{Path.DirectorySeparatorChar}.env.local" }));
    }

    protected static Input BasicInput() =>
        new()
        {
            Username = Username,
            Password = Password,
            HostAddress = Host,
            Port = Port,
            ServiceName = "FAP_APPROVEBANKPAYMENTS_SRV",
            EntitySetName = "C_AbpPaymentBatch",
        };

    protected static Input InputWithQuery() =>
        new()
        {
            Username = Username,
            Password = Password,
            HostAddress = Host,
            Port = Port,
            ServiceName = "FAP_APPROVEBANKPAYMENTS_SRV",
            EntitySetName = "C_AbpPaymentBatch",
            QueryParameters = new Dictionary<string, string> { { "$top", "3" }, },
        };

    protected static Options TestOptions()
    {
        if (RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows))
        {
            return new Options { AcceptAnyCertificate = true, Policies = null };
        }
        else
        {
            return new Options
            {
                AcceptAnyCertificate = true,
                Policies = new List<TlsCipherSuite>
                {
                    TlsCipherSuite.TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384,
                    TlsCipherSuite.TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256,
                    TlsCipherSuite.TLS_RSA_WITH_AES_256_GCM_SHA384,
                    TlsCipherSuite.TLS_RSA_WITH_AES_128_GCM_SHA256,
                    TlsCipherSuite.TLS_RSA_WITH_AES_128_CBC_SHA,
                    TlsCipherSuite.TLS_RSA_WITH_AES_256_CBC_SHA,
                },
            };
        }
    }
}
