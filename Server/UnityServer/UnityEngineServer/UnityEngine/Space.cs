using System;
using System.Diagnostics;

namespace UnityEngine
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
    [Conditional("UNITY_EDITOR")]
    public class Space : Attribute
    {
    }
}