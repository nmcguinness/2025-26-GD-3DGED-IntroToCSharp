namespace GDEngine.Maths
{
    /// <summary>
    /// Represents a 3D vector with X, Y, and Z components.
    /// Provides fields, properties, and methods for common vector operations
    /// such as magnitude calculation, normalization, dot and cross products.
    /// 
    using System;

    public class Vector3 
    {
        #region Fields
        private float _x;
        private float _y;
        private float _z;
        #endregion

        #region Properties
        public float X
        {
            get => _x;
            set => _x = value;
        }

        public float Y
        {
            get => _y;
            set => _y = value;
        }

        public float Z
        {
            get => _z;
            set => _z = value;
        }
        #endregion

        #region Constants
        public static readonly Vector3 Zero = new Vector3(0, 0, 0);
        public static readonly Vector3 One = new Vector3(1, 1, 1);
        public static readonly Vector3 Up = new Vector3(0, 1, 0);
        public static readonly Vector3 Down = new Vector3(0, -1, 0);
        public static readonly Vector3 Left = new Vector3(-1, 0, 0);
        public static readonly Vector3 Right = new Vector3(1, 0, 0);
        public static readonly Vector3 Forward = new Vector3(0, 0, 1);
        public static readonly Vector3 Back = new Vector3(0, 0, -1);
        #endregion

        #region Constructors
        public Vector3(float x, float y, float z)
        {
            _x = x;
            _y = y;
            _z = z;
        }
        #endregion

        #region Operators
        public static Vector3 operator +(Vector3 a, Vector3 b) =>
            new Vector3(a._x + b._x, a._y + b._y, a._z + b._z);

        public static Vector3 operator -(Vector3 a, Vector3 b) =>
            new Vector3(a._x - b._x, a._y - b._y, a._z - b._z);

        public static Vector3 operator -(Vector3 v) =>
            new Vector3(-v._x, -v._y, -v._z);

        public static Vector3 operator *(Vector3 v, float scalar) =>
            new Vector3(v._x * scalar, v._y * scalar, v._z * scalar);

        public static Vector3 operator *(float scalar, Vector3 v) =>
            new Vector3(v._x * scalar, v._y * scalar, v._z * scalar);

        public static Vector3 operator /(Vector3 v, float scalar) =>
            new Vector3(v._x / scalar, v._y / scalar, v._z / scalar);
        #endregion

        #region Overrides
        // Using number format strings - https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings
        public override string ToString() =>
            $"({_x:F2}, {_y:F2}, {_z:F2})";
        #endregion

        #region Cloning
        /// <summary>
        /// Shallow copy (fields copied by value).
        /// </summary>
        public object Clone()
        {
            return this;
        }

        /// <summary>
        /// Deep copy (new Vector3 instance with copied values).
        /// </summary>
        public Vector3 DeepCopy()
        {
            return new Vector3(_x, _y, _z);
        }
        #endregion

        #region Class-specific
        public float Magnitude => (float)Math.Sqrt(_x * _x + _y * _y + _z * _z);

        /// <summary>
        /// Returns a new normalized copy of this vector (non-mutating).
        /// </summary>
        public Vector3 Normalized
        {
            get
            {
                float mag = Magnitude;
                return mag > 0 ? new Vector3(_x / mag, _y / mag, _z / mag) : Zero;
            }
        }

        /// <summary>
        /// Normalizes this vector in place (mutating).
        /// </summary>
        public void Normalize()
        {
            float mag = Magnitude;
            if (mag > 0)
            {
                _x /= mag;
                _y /= mag;
                _z /= mag;
            }
            else
            {
                _x = _y = _z = 0f;
            }
        }

        public static float Dot(Vector3 a, Vector3 b) =>
            a._x * b._x + a._y * b._y + a._z * b._z;

        public float Dot(Vector3 other)
        {
            return _x * other._x + _y * other._y + _z * other._z;
        }

        public static Vector3 Cross(Vector3 a, Vector3 b) =>
            new Vector3(
                a._y * b._z - a._z * b._y,
                a._z * b._x - a._x * b._z,
                a._x * b._y - a._y * b._x
            );

        public Vector3 Cross(Vector3 other) =>
            new Vector3(
                _y * other._z - _z * other._y,
                _z * other._x - _x * other._z,
                _x * other._y - _y * other._x
            );

        public static float Distance(Vector3 a, Vector3 b) =>
            (a - b).Magnitude;
        #endregion



    }

}
