// Copyright (c) Microsoft. All rights reserved.

using System;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace Microsoft.SemanticKernel.Connectors.Memory.Qdrant.Http.ApiSchema;

internal sealed class CreateIndexRequest
{
    /// <summary>
    /// The name of the collection to create index in.
    /// </summary>
    [JsonIgnore]
    public string CollectionName { get; set; }

    /// <summary>
    /// Name of the field to be indexed.
    /// </summary>
    [JsonPropertyName("field_name")]
    public string FieldName { get; set; }

    /// <summary>
    /// For serialization purposes.
    /// </summary>
    [JsonPropertyName("field_schema")]
    public string FieldSchemaAsString => PayloadSchemaTypeTypeToString(this.FieldSchema);

    /// <summary>
    /// Schema of the indexed field.
    /// </summary>
    [JsonIgnore]
    public QdrantPayloadSchemaType FieldSchema { get; set; }

    public static CreateIndexRequest Create(string collectionName, string fieldName, QdrantPayloadSchemaType fieldSchema)
    {
        return new CreateIndexRequest(collectionName, fieldName, fieldSchema);
    }

    public HttpRequestMessage Build()
    {
        return HttpRequest.CreatePutRequest(
            $"collections/{this.CollectionName}/index?wait=true",
            payload: this);
    }

    #region private ================================================================================

    private CreateIndexRequest(string collectionName, string fieldName, QdrantPayloadSchemaType fieldSchema)
    {
        this.CollectionName = collectionName;
        this.FieldName = fieldName;
        this.FieldSchema = fieldSchema;
    }

    private static string PayloadSchemaTypeTypeToString(QdrantPayloadSchemaType x)
    {
        return x switch
        {
            QdrantPayloadSchemaType.Float => "float",
            QdrantPayloadSchemaType.Geo => "geo",
            QdrantPayloadSchemaType.Integer => "integer",
            QdrantPayloadSchemaType.Keyword => "keyword",
            QdrantPayloadSchemaType.Text => "text",
            _ => throw new NotSupportedException($"Payload schema type {Enum.GetName(typeof(QdrantPayloadSchemaType), x)} not supported")
        };
    }

    #endregion
}
