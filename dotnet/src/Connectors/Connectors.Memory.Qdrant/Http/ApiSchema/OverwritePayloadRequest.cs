// Copyright (c) Microsoft. All rights reserved.

using System.Net.Http;
using System.Text.Json.Serialization;

namespace Microsoft.SemanticKernel.Connectors.Memory.Qdrant.Http.ApiSchema;

internal sealed class OverwritePayloadRequest
{
    /// <summary>
    /// The name of the collection.
    /// </summary>
    [JsonIgnore]
    public string CollectionName { get; set; }

    /// <summary>
    /// The unique IDs used to index Qdrant vector entries.
    /// </summary>
    [JsonPropertyName("points")]
    public string[] Points { get; set; }

    /// <summary>
    /// New vectors' payload.
    /// </summary>
    [JsonPropertyName("payload")]
    public object Payload { get; set; }

    public static OverwritePayloadRequest Create(string collectionName, string[] points, object payload)
    {
        return new OverwritePayloadRequest(collectionName, points, payload);
    }

    public HttpRequestMessage Build()
    {
        return HttpRequest.CreatePutRequest(
            $"collections/{this.CollectionName}/points/payload?wait=true",
            payload: this);
    }

    #region private ================================================================================

    private OverwritePayloadRequest(string collectionName, string[] points, object payload)
    {
        this.CollectionName = collectionName;
        this.Points = points;
        this.Payload = payload;
    }

    #endregion
}
