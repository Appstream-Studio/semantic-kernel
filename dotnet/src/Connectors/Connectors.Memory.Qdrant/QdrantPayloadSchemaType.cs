// Copyright (c) Microsoft. All rights reserved.

namespace Microsoft.SemanticKernel.Connectors.Memory.Qdrant;

/// <summary>
/// Enum describing all possible Qdrant payload field schema types.
/// </summary>
[System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "Qdrant schema type names overlap with dotnet")]
public enum QdrantPayloadSchemaType
{
    /// <summary>
    /// String value.
    /// </summary>
    /// <remarks>
    /// Affects Match filtering conditions.
    /// </remarks>
    Keyword,

    /// <summary>
    /// 64-bit integer.
    /// </summary>
    /// <remarks>
    /// Affects Match and Range filtering conditions.
    /// </remarks>
    Integer,

    /// <summary>
    /// 64-bit floating point number.
    /// </summary>
    /// <remarks>
    /// Affects Range filtering conditions.
    /// </remarks>
    Float,

    /// <summary>
    /// Geographical coordinates.
    /// </summary>
    /// <remarks>
    /// Affects Geo Bounding Box and Geo Radius filtering conditions.
    /// Coordinate should be described as an object containing two fields: lon - for longitude, and lat - for latitude.
    /// </remarks>
    Geo,

    /// <summary>
    /// String value for full text search.
    /// </summary>
    /// <remarks>
    /// Affects Full Text Search filtering conditions.
    /// </remarks>
    Text
}
