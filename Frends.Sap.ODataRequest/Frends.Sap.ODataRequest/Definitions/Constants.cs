namespace Frends.Sap.ODataRequest.Definitions;

#pragma warning disable CS1591 // self explanatory
#pragma warning disable SA1602 // self explanatory

public static class Constants
{
    public const string ODataPrefix = "/sap/opu/odata/sap";

    public enum ResponseFormat
    {
        Json = 1,
        Xml = 2,
    }
}
#pragma warning restore CS1591 // self explanatory
#pragma warning restore SA1602 // self explanatory
