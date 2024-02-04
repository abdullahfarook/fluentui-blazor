// ------------------------------------------------------------------------
// MIT License - Copyright (c) Microsoft Corporation. All rights reserved.
// ------------------------------------------------------------------------

namespace Microsoft.FluentUI.AspNetCore.Components.Utils;

public static class TypeUtils
{

    // also implement for DateTime? as input
    public static T? Parse<T>(this DateTime? value)
    {
        var min = DateTime.MinValue;
        if (value is null || value == min)
        {
            return default;
        }

        return typeof(T) switch
        {
            { } t when t == typeof(DateTime) => (T)(object)value.Value,
            { } t when t == typeof(DateTime?) => (T)(object)value.Value,
            { } t when t == typeof(DateTimeOffset) => (T)(object)new DateTimeOffset(value.Value),
            { } t when t == typeof(DateTimeOffset?) => (T)(object)new DateTimeOffset(value.Value),
            _ => throw new NotSupportedException($"Type {typeof(T)} is not supported")
        };
    }
    // now otherway around
    public static DateTime? ParseTime<T>(this T value)
    {
        if (value is null)
        {
            return null;
        }

        return typeof(T) switch
        {
            { } t when t == typeof(DateTime) => (DateTime)(object)value,
            { } t when t == typeof(DateTime?) => (DateTime)(object)value,
            { } t when t == typeof(DateTimeOffset) => ((DateTimeOffset)(object)value).DateTime,
            { } t when t == typeof(DateTimeOffset?) => ((DateTimeOffset)(object)value).DateTime,
            _ => throw new NotSupportedException($"Type {typeof(T)} is not supported")
        };
    }
}
