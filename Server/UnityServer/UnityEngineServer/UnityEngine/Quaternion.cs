using System;

namespace UnityEngine
{
    /// <summary>
    /// 
    /// </summary>
    public struct Quaternion
    {
		public static Quaternion identity { get { return new Quaternion(0,0,0,1); } }

        /// <summary>
        /// 
        /// </summary>
        public const float kEpsilon = 1E-06f;

        /// <summary>
        /// 
        /// </summary>
        public float x;
        /// <summary>
        /// 
        /// </summary>
        public float y;
        /// <summary>
        /// 
        /// </summary>
        public float z;
        /// <summary>
        /// 
        /// </summary>
        public float w;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        public Quaternion(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newX"></param>
        /// <param name="newY"></param>
        /// <param name="newZ"></param>
        /// <param name="newW"></param>
        public void Set(float newX, float newY, float newZ, float newW)
        {
            x = newX;
            y = newY;
            z = newZ;
            w = newW;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    case 2:
                        return z;
                    case 3:
                        return w;
                    default:
                        throw new IndexOutOfRangeException("Invalid Quaternion index!");
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
                    case 2:
                        z = value;
                        break;
                    case 3:
                        w = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Invalid Quaternion index!");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Vector3 eulerAngles => Quaternion.GetEulerAngles(this);

        private static Vector3 GetEulerAngles(Quaternion q1)
        {
            float sqw = q1.w * q1.w;
            float sqx = q1.x * q1.x;
            float sqy = q1.y * q1.y;
            float sqz = q1.z * q1.z;
            float unit = sqx + sqy + sqz + sqw; // if normalised is one, otherwise is correction factor
            float test = q1.x * q1.w - q1.y * q1.z;
            Vector3 v;

            if (test>0.4995f*unit) { // singularity at north pole
                v.y = 2f * Mathf.Atan2 (q1.y, q1.x);
                v.x = Mathf.PI / 2;
                v.z = 0;
                return NormalizeAngles (v * Mathf.Rad2Deg);
            }
            if (test<-0.4995f*unit) { // singularity at south pole
                v.y = -2f * Mathf.Atan2 (q1.y, q1.x);
                v.x = -Mathf.PI / 2;
                v.z = 0;
                return NormalizeAngles (v * Mathf.Rad2Deg);
            }
            Quaternion q = new Quaternion (q1.w, q1.z, q1.x, q1.y);
            v.y = (float)Math.Atan2 (2f * q.x * q.w + 2f * q.y * q.z, 1 - 2f * (q.z * q.z + q.w * q.w));     // Yaw
            v.x = (float)Math.Asin (2f * (q.x * q.z - q.w * q.y));                             // Pitch
            v.z = (float)Math.Atan2 (2f * q.x * q.y + 2f * q.z * q.w, 1 - 2f * (q.y * q.y + q.z * q.z));      // Roll
            return NormalizeAngles (v * Mathf.Rad2Deg);
        }
        
        private static Vector3 NormalizeAngles (Vector3 angles)
        {
            angles.x = NormalizeAngle (angles.x);
            angles.y = NormalizeAngle (angles.y);
            angles.z = NormalizeAngle (angles.z);
            return angles;
        }

        private static float NormalizeAngle (float angle)
        {
            while (angle>360)
                angle -= 360;
            while (angle<0)
                angle += 360;
            return angle;
        }

        #region operators
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Quaternion operator *(Quaternion lhs, Quaternion rhs)
        {
            return new Quaternion((float)(lhs.w * (double)rhs.x + lhs.x * (double)rhs.w + lhs.y * (double)rhs.z - lhs.z * (double)rhs.y), 
                (float)(lhs.w * (double)rhs.y + lhs.y * (double)rhs.w + lhs.z * (double)rhs.x - lhs.x * (double)rhs.z), 
                (float)(lhs.w * (double)rhs.z + lhs.z * (double)rhs.w + lhs.x * (double)rhs.y - lhs.y * (double)rhs.x), 
                (float)(lhs.w * (double)rhs.w - lhs.x * (double)rhs.x - lhs.y * (double)rhs.y - lhs.z * (double)rhs.z));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rotation"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 operator *(Quaternion rotation, Vector3 point)
        {
            var num1 = rotation.x * 2f;
            var num2 = rotation.y * 2f;
            var num3 = rotation.z * 2f;
            var num4 = rotation.x * num1;
            var num5 = rotation.y * num2;
            var num6 = rotation.z * num3;
            var num7 = rotation.x * num2;
            var num8 = rotation.x * num3;
            var num9 = rotation.y * num3;
            var num10 = rotation.w * num1;
            var num11 = rotation.w * num2;
            var num12 = rotation.w * num3;
            Vector3 vector3;
            vector3.x = (float)((1.0 - (num5 + (double)num6)) * point.x + (num7 - (double)num12) * point.y + (num8 + (double)num11) * point.z);
            vector3.y = (float)((num7 + (double)num12) * point.x + (1.0 - (num4 + (double)num6)) * point.y + (num9 - (double)num10) * point.z);
            vector3.z = (float)((num8 - (double)num11) * point.x + (num9 + (double)num10) * point.y + (1.0 - (num4 + (double)num5)) * point.z);
            return vector3;
        }

        private const double equalityEpsilon = 0.999998986721039;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator ==(Quaternion lhs, Quaternion rhs)
        {
            return Dot(lhs, rhs) > equalityEpsilon;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static bool operator !=(Quaternion lhs, Quaternion rhs)
        {
            return Dot(lhs, rhs) <= equalityEpsilon;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float Dot(Quaternion a, Quaternion b)
        {
            return (float)(a.x * (double)b.x + a.y * (double)b.y + a.z * (double)b.z + a.w * (double)b.w);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="axis"></param>
        /// <returns></returns>
        public static Quaternion AngleAxis(float angle, Vector3 axis)
        {
            var normalized = axis.normalized;

            var half = angle * 0.5f;
            var sin = (float)Math.Sin(half);
            var cos = (float)Math.Cos(half);

            return new Quaternion(
                normalized.x * sin,
                normalized.y * sin,
                normalized.z * sin,
                cos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="axis"></param>
        public void ToAngleAxis(out float angle, out Vector3 axis)
        {
            UnityStub_ToAxisAngleRad(this, out axis, out angle);
            angle = angle * Mathf.Rad2Deg;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDirection"></param>
        /// <param name="toDirection"></param>
        /// <returns></returns>
        public static Quaternion FromToRotation(Vector3 fromDirection, Vector3 toDirection)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDirection"></param>
        /// <param name="toDirection"></param>
        public void SetFromToRotation(Vector3 fromDirection, Vector3 toDirection)
        {
            this = FromToRotation(fromDirection, toDirection);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="forward"></param>
        /// <param name="upwards"></param>
        /// <returns></returns>
        public static Quaternion LookRotation(Vector3 forward, Vector3 up)
        {
            forward = forward.normalized;
            Vector3 right = Vector3.Cross(up, forward).normalized;
            up = Vector3.Cross(forward, right);
            var m00 = right.x;
            var m01 = right.y;
            var m02 = right.z;
            var m10 = up.x;
            var m11 = up.y;
            var m12 = up.z;
            var m20 = forward.x;
            var m21 = forward.y;
            var m22 = forward.z;


            float num8 = (m00 + m11) + m22;
            var quaternion = new Quaternion();
            if (num8 > 0f)
            {
                var num = (float)System.Math.Sqrt(num8 + 1f);
                quaternion.w = num * 0.5f;
                num = 0.5f / num;
                quaternion.x = (m12 - m21) * num;
                quaternion.y = (m20 - m02) * num;
                quaternion.z = (m01 - m10) * num;
                return quaternion;
            }
            if ((m00 >= m11) && (m00 >= m22))
            {
                var num7 = (float)System.Math.Sqrt(((1f + m00) - m11) - m22);
                var num4 = 0.5f / num7;
                quaternion.x = 0.5f * num7;
                quaternion.y = (m01 + m10) * num4;
                quaternion.z = (m02 + m20) * num4;
                quaternion.w = (m12 - m21) * num4;
                return quaternion;
            }
            if (m11 > m22)
            {
                var num6 = (float)System.Math.Sqrt(((1f + m11) - m00) - m22);
                var num3 = 0.5f / num6;
                quaternion.x = (m10 + m01) * num3;
                quaternion.y = 0.5f * num6;
                quaternion.z = (m21 + m12) * num3;
                quaternion.w = (m20 - m02) * num3;
                return quaternion;
            }
            var num5 = (float)System.Math.Sqrt(((1f + m22) - m00) - m11);
            var num2 = 0.5f / num5;
            quaternion.x = (m20 + m02) * num2;
            quaternion.y = (m21 + m12) * num2;
            quaternion.z = 0.5f * num5;
            quaternion.w = (m01 - m10) * num2;
            return quaternion;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="forward"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static Quaternion LookRotation(Vector3 forward)
        {
            return LookRotation(forward, Vector3.up);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="view"></param>
        public void SetLookRotation(Vector3 view)
        {
            SetLookRotation(view, Vector3.up);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="view"></param>
        /// <param name="up"></param>
        public void SetLookRotation(Vector3 view, Vector3 up)
        {
            this = LookRotation(view, up);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static Quaternion Slerp(Quaternion from, Quaternion to, float t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="maxDegreesDelta"></param>
        /// <returns></returns>
        public static Quaternion RotateTowards(Quaternion from, Quaternion to, float maxDegreesDelta)
        {
            var t = Mathf.Min(1f, maxDegreesDelta / Angle(from, to));
            return UnclampedSlerp(from, to, t);
        }

        private static Quaternion UnclampedSlerp(Quaternion from, Quaternion to, float t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rotation"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static Quaternion Inverse(Quaternion rotation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Quaternion Lerp(Quaternion from, Quaternion to, float t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float Angle(Quaternion a, Quaternion b)
        {
            return (float)(Math.Acos(Math.Min(Math.Abs(Dot(a, b)), 1f)) * 2.0 * 57.2957801818848);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Quaternion Euler(float rotX, float rotY, float rotZ)
        {
            // Углы в радианах
            float pitchRad = rotX * Mathf.Deg2Rad;
            float yawRad = rotY * Mathf.Deg2Rad;
            float rollRad = rotZ * Mathf.Deg2Rad;

            // Половина углов
            float halfPitch = pitchRad * 0.5f;
            float halfYaw = yawRad * 0.5f;
            float halfRoll = rollRad * 0.5f;

            // Вычисление синусов и косинусов половины углов
            float sinHalfPitch = Mathf.Sin(halfPitch);
            float cosHalfPitch = Mathf.Cos(halfPitch);
            float sinHalfYaw = Mathf.Sin(halfYaw);
            float cosHalfYaw = Mathf.Cos(halfYaw);
            float sinHalfRoll = Mathf.Sin(halfRoll);
            float cosHalfRoll = Mathf.Cos(halfRoll);

            // Вычисление компонентов кватерниона
            float x = cosHalfYaw * sinHalfRoll * cosHalfPitch + sinHalfYaw * cosHalfRoll * sinHalfPitch;
            float y = sinHalfYaw * cosHalfRoll * cosHalfPitch - cosHalfYaw * sinHalfRoll * sinHalfPitch;
            float z = cosHalfYaw * cosHalfRoll * sinHalfPitch - sinHalfYaw * sinHalfRoll * cosHalfPitch;
            float w = cosHalfYaw * cosHalfRoll * cosHalfPitch + sinHalfYaw * sinHalfRoll * sinHalfPitch;

            return new Quaternion(x, y, z, w);
        }

        private static void UnityStub_ToAxisAngleRad(Quaternion rotation, out Vector3 axis, out float angle)
        {
            var sqrLngth = (rotation.x * rotation.x) + (rotation.y * rotation.y) + (rotation.z * rotation.z);
            if (sqrLngth < kEpsilon)
            {
                axis = Vector3.right;
            }
            else
            {
                float inv = 1.0f / sqrLngth;
                axis = new Vector3(rotation.x * inv, rotation.y * inv, rotation.z * inv);
            }
            angle = (float) (2.0*Math.Acos(rotation.w));
        }

        private static Quaternion UnityStub_FromEulerRad(Vector3 euler)
        {
            throw new NotImplementedException();
        }

        private static Vector3 UnityStub_ToEulerRad(Quaternion rotation)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
// ReSharper disable NonReadonlyFieldInGetHashCode
            return x.GetHashCode() ^ y.GetHashCode() << 2 ^ z.GetHashCode() >> 2 ^ w.GetHashCode() >> 1;
// ReSharper restore NonReadonlyFieldInGetHashCode
        }

        public override bool Equals(object other)
        {
            if (!(other is Quaternion))
                return false;
            var quaternion = (Quaternion)other;
            if (x.Equals(quaternion.x) && y.Equals(quaternion.y) && z.Equals(quaternion.z))
                return w.Equals(quaternion.w);
            return false;
        }
    }
}
