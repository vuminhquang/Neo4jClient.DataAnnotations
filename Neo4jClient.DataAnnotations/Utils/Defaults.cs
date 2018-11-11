﻿using Neo4jClient.Cypher;
using Neo4jClient.DataAnnotations.Cypher;
using Neo4jClient.DataAnnotations.Cypher.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using Neo4jClient.DataAnnotations.Utils;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Neo4jClient.DataAnnotations.Utils
{
    public class Defaults
    {
        #region Types
        public static readonly Type CypherObjectType = typeof(CypherObject);
        public static readonly Type ForeignKeyType = typeof(ForeignKeyAttribute);
        public static readonly Type InversePropertyType = typeof(InversePropertyAttribute);
        public static readonly Type ColumnType = typeof(ColumnAttribute);
        public static readonly Type KeyType = typeof(KeyAttribute);
        public static readonly Type ComplexType = typeof(ComplexTypeAttribute);
        public static readonly Type VarsType = typeof(Vars);
        public static readonly Type ExtensionsType = typeof(Extensions);
        public static readonly Type ObjectExtensionsType = typeof(ObjectExtensions);
        public static readonly Type NeoScalarType = typeof(NeoScalarAttribute);
        public static readonly Type NeoNonScalarType = typeof(NeoNonScalarAttribute);
        public static readonly Type ObjectType = typeof(object);
        public static readonly Type DictionaryType = typeof(IDictionary<,>);
        public static readonly Type UtilitiesType = typeof(Utils.Utilities);
        public static readonly Type StringType = typeof(string);
        public static readonly Type EnumerableType = typeof(Enumerable);
        public static readonly Type MathType = typeof(Math);
        internal static readonly Type PropertyDummyType = typeof(Serialization.PropertyDummy);
        public static readonly Type FuncsType = typeof(Funcs);
        public static readonly Type ExtensionFuncsType = typeof(Cypher.Functions.ExtensionFuncs);
        public static readonly Type JRawType = typeof(JRaw);
        public static readonly Type ICypherResultItemType = typeof(ICypherResultItem);
        public static readonly Type EntitySetType = typeof(EntitySet<>);
        public static readonly Type ConcreteEntitySetType = typeof(ConcreteEntitySet<>);
        #endregion

        public const BindingFlags MemberSearchBindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;

        public const string MetadataPropertyName = "__ncdannotationsmeta__"; //this value should never change

        public const string MetadataNullPropertiesPropertyName = "null_props"; //this value should never change

        [JsonProperty(PropertyName = MetadataPropertyName)]
        public static string DummyMetadataProperty { get; set; }

        internal static readonly PropertyInfo PropertyDummyPropertyInfo = PropertyDummyType.GetProperty("Property");

        public static readonly MethodInfo AsMethodInfo = Utils.Utilities.GetMethodInfo(() => ObjectExtensions._As<object>(null));

        public static readonly MethodInfo AsListMethodInfo = Utils.Utilities.GetMethodInfo(() => ObjectExtensions._AsList<object>(null));

        public static readonly MethodInfo IsNullMethodInfo = Utils.Utilities.GetMethodInfo(() => ObjectExtensions.IsNull<object>(null));

        public static readonly MethodInfo IsNotNullMethodInfo = Utils.Utilities.GetMethodInfo(() => ObjectExtensions.IsNotNull<object>(null));

        public static readonly MethodInfo CypherObjectIndexerInfo =
            CypherObjectType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(p => p.GetIndexParameters().Any())
            .Select(p => p.GetGetMethod()).First();

        public const string QueryBuildStrategyKey = "querypropbuildstrategy";

        public static readonly FieldInfo QueryWriterInfo = typeof(CypherFluentQuery).GetField("QueryWriter", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        public static readonly FieldInfo QueryWriterParamsInfo = typeof(QueryWriter).GetField("queryParameters", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);


        public static string ComplexTypeNameSeparator = "_";
    }
}