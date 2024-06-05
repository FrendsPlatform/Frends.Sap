namespace Frends.Sap.ODataRequest.Tests.tests;

using System;
using System.IO;
using dotenv.net;
using NUnit.Framework;

[TestFixture]
public abstract class TestsBase
{
    protected static readonly string Username = Environment.GetEnvironmentVariable("USERNAME");
    protected static readonly string Password = Environment.GetEnvironmentVariable("PASSWORD");
    protected static readonly string Host = Environment.GetEnvironmentVariable("HOST");
    protected static readonly string Port = Environment.GetEnvironmentVariable("PORT");

    [OneTimeSetUp]
    public static void AssemblyInit()
    {
        var root = Directory.GetCurrentDirectory();
        string projDir = Directory.GetParent(root).Parent.Parent.FullName;
        DotEnv.Load(
            options: new DotEnvOptions(
                envFilePaths: new[] { $"{projDir}{Path.DirectorySeparatorChar}.env.local" }));
    }
}
