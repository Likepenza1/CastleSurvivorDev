using System;

namespace UnityEngine
{
    /// <summary>
    /// 
    /// </summary>
    public struct Vector2Int : IEquatable<Vector2Int>
    {
        private int m_X;
        private int m_Y;
        private static readonly Vector2Int s_Zero = new(0, 0);
        private static readonly Vector2Int s_One = new(1, 1);
        private static readonly Vector2Int s_Up = new(0, 1);
        private static readonly Vector2Int s_Down = new(0, -1);
        private static readonly Vector2Int s_Left = new(-1, 0);
        private static readonly Vector2Int s_Right = new(1, 0);

        /// <summary>
        ///   <para>X component of the vector.</para>
        /// </summary>
        public int x
        {
            get => m_X;
            set => m_X = value;
        }

        /// <summary>
        ///   <para>Y component of the vector.</para>
        /// </summary>
        public int y
        {
            get => m_Y;
            set => m_Y = value;
        }

        public Vector2Int(int x, int y)
        {
            m_X = x;
            m_Y = y;
        }

        /// <summary>
        ///   <para>Set x and y components of an existing Vector2Int.</para>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Set(int x, int y)
        {
            m_X = x;
            m_Y = y;
        }

        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    default:
                        throw new IndexOutOfRangeException(string.Format("Invalid Vector2Int index addressed: {0}!", (object)index));
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException(string.Format("Invalid Vector2Int index addressed: {0}!", (object)index));
                }
            }
        }

        /// <summary>
        ///   <para>Returns the length of this vector (Read Only).</para>
        /// </summary>
        public float magnitude => Mathf.Sqrt((float)(x * x + y * y));

        /// <summary>
        ///   <para>Returns the squared length of this vector (Read Only).</para>
        /// </summary>
        public int sqrMagnitude => x * x + y * y;

        /// <summary>
        ///   <para>Returns the distance between a and b.</para>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static float Distance(Vector2Int a, Vector2Int b)
        {
            float num1 = (float)(a.x - b.x);
            float num2 = (float)(a.y - b.y);
            return (float)Math.Sqrt((double)num1 * (double)num1 + (double)num2 * (double)num2);
        }

        /// <summary>
        ///   <para>Returns a vector that is made from the smallest components of two vectors.</para>
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        public static Vector2Int Min(Vector2Int lhs, Vector2Int rhs) => new(Mathf.Min(lhs.x, rhs.x), Mathf.Min(lhs.y, rhs.y));

        /// <summary>
        ///   <para>Returns a vector that is made from the largest components of two vectors.</para>
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        public static Vector2Int Max(Vector2Int lhs, Vector2Int rhs) => new(Mathf.Max(lhs.x, rhs.x), Mathf.Max(lhs.y, rhs.y));

        /// <summary>
        ///   <para>Multiplies two vectors component-wise.</para>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static Vector2Int Scale(Vector2Int a, Vector2Int b) => new(a.x * b.x, a.y * b.y);

        /// <summary>
        ///   <para>Multiplies every component of this vector by the same component of scale.</para>
        /// </summary>
        /// <param name="scale"></param>
        public void Scale(Vector2Int scale)
        {
            x *= scale.x;
            y *= scale.y;
        }

        /// <summary>
        ///   <para>Clamps the Vector2Int to the bounds given by min and max.</para>
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void Clamp(Vector2Int min, Vector2Int max)
        {
            x = Math.Max(min.x, x);
            x = Math.Min(max.x, x);
            y = Math.Max(min.y, y);
            y = Math.Min(max.y, y);
        }

        public static implicit operator Vector2(Vector2Int v) => new((float)v.x, (float)v.y);

        public static explicit operator Vector3Int(Vector2Int v) => new(v.x, v.y, 0);

        /// <summary>
        ///   <para>Converts a Vector2 to a Vector2Int by doing a Floor to each value.</para>
        /// </summary>
        /// <param name="v"></param>
        public static Vector2Int FloorToInt(Vector2 v) => new(Mathf.FloorToInt(v.x), Mathf.FloorToInt(v.y));

        /// <summary>
        ///   <para>Converts a  Vector2 to a Vector2Int by doing a Ceiling to each value.</para>
        /// </summary>
        /// <param name="v"></param>
        public static Vector2Int CeilToInt(Vector2 v) => new(Mathf.CeilToInt(v.x), Mathf.CeilToInt(v.y));

        /// <summary>
        ///   <para>Converts a  Vector2 to a Vector2Int by doing a Round to each value.</para>
        /// </summary>
        /// <param name="v"></param>
        public static Vector2Int RoundToInt(Vector2 v) => new(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y));

        public static Vector2Int operator -(Vector2Int v) => new(-v.x, -v.y);

        public static Vector2Int operator +(Vector2Int a, Vector2Int b) => new(a.x + b.x, a.y + b.y);

        public static Vector2Int operator -(Vector2Int a, Vector2Int b) => new(a.x - b.x, a.y - b.y);

        public static Vector2Int operator *(Vector2Int a, Vector2Int b) => new(a.x * b.x, a.y * b.y);

        public static Vector2Int operator *(int a, Vector2Int b) => new(a * b.x, a * b.y);

        public static Vector2Int operator *(Vector2Int a, int b) => new(a.x * b, a.y * b);

        public static Vector2Int operator /(Vector2Int a, int b) => new(a.x / b, a.y / b);

        public static bool operator ==(Vector2Int lhs, Vector2Int rhs) => lhs.x == rhs.x && lhs.y == rhs.y;

        public static bool operator !=(Vector2Int lhs, Vector2Int rhs) => !(lhs == rhs);

        /// <summary>
        ///   <para>Returns true if the objects are equal.</para>
        /// </summary>
        /// <param name="other"></param>
        public override bool Equals(object other) => other is Vector2Int other1 && Equals(other1);

        public bool Equals(Vector2Int other) => x == other.x && y == other.y;

        /// <summary>
        ///   <para>Gets the hash code for the Vector2Int.</para>
        /// </summary>
        /// <returns>
        ///   <para>The hash code of the Vector2Int.</para>
        /// </returns>
        public override int GetHashCode()
        {
            int num1 = x;
            int hashCode = num1.GetHashCode();
            num1 = y;
            int num2 = num1.GetHashCode() << 2;
            return hashCode ^ num2;
        }

        /// <summary>
        ///   <para>Returns a formatted string for this vector.</para>
        /// </summary>
        /// <param name="format">A numeric format string.</param>
        /// <param name="formatProvider">An object that specifies culture-specific formatting.</param>
        public override string ToString() => $"({x}, {y})";


        /// <summary>
        ///   <para>Shorthand for writing Vector2Int(0, 0).</para>
        /// </summary>
        public static Vector2Int zero => s_Zero;

        /// <summary>
        ///   <para>Shorthand for writing Vector2Int(1, 1).</para>
        /// </summary>
        public static Vector2Int one => s_One;

        /// <summary>
        ///   <para>Shorthand for writing Vector2Int(0, 1).</para>
        /// </summary>
        public static Vector2Int up => s_Up;

        /// <summary>
        ///   <para>Shorthand for writing Vector2Int(0, -1).</para>
        /// </summary>
        public static Vector2Int down => s_Down;

        /// <summary>
        ///   <para>Shorthand for writing Vector2Int(-1, 0).</para>
        /// </summary>
        public static Vector2Int left => s_Left;

        /// <summary>
        ///   <para>Shorthand for writing Vector2Int(1, 0).</para>
        /// </summary>
        public static Vector2Int right => s_Right;
    }
}