﻿namespace Frends.Sap.ODataRequest.Definitions;

/// <summary>
/// Result properties.
/// </summary>
public class Result
{
    /// <summary>
    /// Returned status code.
    /// </summary>
    /// <example>200</example>
    public int StatusCode { get; init; }

    /// <summary>
    /// Body of the response represented as JToken
    /// </summary>
    /// <example>{ "id": 123 }</example>
    public dynamic Content { get; init; }
}
