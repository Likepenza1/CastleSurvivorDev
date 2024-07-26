// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using MessagePack.Formatters;
using UnityEngine;

namespace MessagePack.Unity
{
    public class UnityResolver : IFormatterResolver
    {
        public static readonly UnityResolver Instance = new UnityResolver();

        private UnityResolver()
        {
        }

        public IMessagePackFormatter<T> GetFormatter<T>()
        {
            return FormatterCache<T>.Formatter;
        }

        private static class FormatterCache<T>
        {
            public static readonly IMessagePackFormatter<T> Formatter;

            static FormatterCache()
            {
                Formatter = (IMessagePackFormatter<T>)UnityResolveryResolverGetFormatterHelper.GetFormatter(typeof(T));
            }
        }
    }

    internal static class UnityResolveryResolverGetFormatterHelper
    {
        private static readonly Dictionary<Type, object> FormatterMap = new Dictionary<Type, object>()
        {
            // standard
            { typeof(Vector2), new Vector2Formatter() },
            { typeof(Vector3), new Vector3Formatter() },
            { typeof(Vector4), new Vector4Formatter() },
            { typeof(Quaternion), new QuaternionFormatter() },
            { typeof(Color), new ColorFormatter() },
            { typeof(Bounds), new BoundsFormatter() },
            { typeof(Rect), new RectFormatter() },
            { typeof(Vector2?), new StaticNullableFormatter<Vector2>(new Vector2Formatter()) },
            { typeof(Vector3?), new StaticNullableFormatter<Vector3>(new Vector3Formatter()) },
            { typeof(Vector4?), new StaticNullableFormatter<Vector4>(new Vector4Formatter()) },
            { typeof(Quaternion?), new StaticNullableFormatter<Quaternion>(new QuaternionFormatter()) },
            { typeof(Color?), new StaticNullableFormatter<Color>(new ColorFormatter()) },
            { typeof(Bounds?), new StaticNullableFormatter<Bounds>(new BoundsFormatter()) },
            { typeof(Rect?), new StaticNullableFormatter<Rect>(new RectFormatter()) },

            // standard + array
            { typeof(Vector2[]), new ArrayFormatter<Vector2>() },
            { typeof(Vector3[]), new ArrayFormatter<Vector3>() },
            { typeof(Vector4[]), new ArrayFormatter<Vector4>() },
            { typeof(Quaternion[]), new ArrayFormatter<Quaternion>() },
            { typeof(Color[]), new ArrayFormatter<Color>() },
            { typeof(Bounds[]), new ArrayFormatter<Bounds>() },
            { typeof(Rect[]), new ArrayFormatter<Rect>() },
            { typeof(Vector2?[]), new ArrayFormatter<Vector2?>() },
            { typeof(Vector3?[]), new ArrayFormatter<Vector3?>() },
            { typeof(Vector4?[]), new ArrayFormatter<Vector4?>() },
            { typeof(Quaternion?[]), new ArrayFormatter<Quaternion?>() },
            { typeof(Color?[]), new ArrayFormatter<Color?>() },
            { typeof(Bounds?[]), new ArrayFormatter<Bounds?>() },
            { typeof(Rect?[]), new ArrayFormatter<Rect?>() },

            // standard + list
            { typeof(List<Vector2>), new ListFormatter<Vector2>() },
            { typeof(List<Vector3>), new ListFormatter<Vector3>() },
            { typeof(List<Vector4>), new ListFormatter<Vector4>() },
            { typeof(List<Quaternion>), new ListFormatter<Quaternion>() },
            { typeof(List<Color>), new ListFormatter<Color>() },
            { typeof(List<Bounds>), new ListFormatter<Bounds>() },
            { typeof(List<Rect>), new ListFormatter<Rect>() },
            { typeof(List<Vector2?>), new ListFormatter<Vector2?>() },
            { typeof(List<Vector3?>), new ListFormatter<Vector3?>() },
            { typeof(List<Vector4?>), new ListFormatter<Vector4?>() },
            { typeof(List<Quaternion?>), new ListFormatter<Quaternion?>() },
            { typeof(List<Color?>), new ListFormatter<Color?>() },
            { typeof(List<Bounds?>), new ListFormatter<Bounds?>() },
            { typeof(List<Rect?>), new ListFormatter<Rect?>() },

            // new
            { typeof(Matrix4x4),          new Matrix4x4Formatter() },
            { typeof(Matrix4x4?),         new StaticNullableFormatter<Matrix4x4>(new Matrix4x4Formatter()) },

            // new + array
            { typeof(Matrix4x4[]),          new ArrayFormatter<Matrix4x4>() },
            { typeof(Matrix4x4?[]),         new ArrayFormatter<Matrix4x4?>() },

            // new + list
            { typeof(List<Matrix4x4>),          new ListFormatter<Matrix4x4>() },
            { typeof(List<Matrix4x4?>),         new ListFormatter<Matrix4x4?>() },
            {typeof(Vector2Int),         new Vector2IntFormatter()},
            {typeof(Vector3Int),         new Vector3IntFormatter()},
            {typeof(Vector2Int?),        new StaticNullableFormatter<Vector2Int>(new Vector2IntFormatter())},
            {typeof(Vector3Int?),        new StaticNullableFormatter<Vector3Int>(new Vector3IntFormatter())},
            {typeof(Vector2Int[]),       new ArrayFormatter<Vector2Int>()},
            {typeof(Vector3Int[]),       new ArrayFormatter<Vector3Int>()},
            {typeof(List<Vector2Int>),       new ListFormatter<Vector2Int>()},
            {typeof(List<Vector3Int>),       new ListFormatter<Vector3Int>()},
        };

        internal static object GetFormatter(Type t)
        {
            object formatter;
            if (FormatterMap.TryGetValue(t, out formatter))
            {
                return formatter;
            }

            return null;
        }
    }
}
