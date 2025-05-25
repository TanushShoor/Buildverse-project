#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using com.IvanMurzak.Unity.MCP.Common.Data.Unity;
using Microsoft.Extensions.Logging;

namespace com.IvanMurzak.Unity.MCP.Common.Reflection.Convertor
{
    public interface IReflectionConvertor
    {
        bool AllowCascadeSerialize { get; }
        bool AllowCascadePopulate { get; }

        int SerializationPriority(Type type, ILogger? logger = null);

        object? Deserialize(Reflector reflector, SerializedMember data, ILogger? logger = null);

        SerializedMember Serialize(Reflector reflector, object? obj, Type? type = null, string? name = null, bool recursive = true,
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
            ILogger? logger = null);
        StringBuilder? Populate(Reflector reflector, ref object obj, SerializedMember data, int depth = 0, StringBuilder? stringBuilder = null,
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
            ILogger? logger = null);

        bool SetAsField(Reflector reflector, ref object obj, Type type, FieldInfo fieldInfo, SerializedMember? value, StringBuilder? stringBuilder = null,
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
            ILogger? logger = null);
        bool SetAsProperty(Reflector reflector, ref object obj, Type type, PropertyInfo propertyInfo, SerializedMember? value, StringBuilder? stringBuilder = null,
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
            ILogger? logger = null);
        bool SetField(Reflector reflector, ref object obj, Type type, FieldInfo fieldInfo, SerializedMember? value,
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
            ILogger? logger = null);
        bool SetProperty(Reflector reflector, ref object obj, Type type, PropertyInfo propertyInfo, SerializedMember? value,
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
            ILogger? logger = null);

        IEnumerable<FieldInfo>? GetSerializableFields(Reflector reflector, Type objType,
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
            ILogger? logger = null);
        IEnumerable<PropertyInfo>? GetSerializableProperties(Reflector reflector, Type objType,
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
            ILogger? logger = null);
    }
}