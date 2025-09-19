
namespace GDEngine.Math
{
    /// <summary>
    /// Represents a 3D vector with X, Y, and Z components.
    /// Provides fields, properties, and methods for common vector operations
    /// such as magnitude calculation, normalization, dot and cross products.
    /// 
    public class Vector3
    {
        #region Fields
        private float _x, _y, _z;
        #endregion

        #region Static Helpers
        public static Vector3 Zero => new Vector3(0, 0, 0);
        public static Vector3 One => new Vector3(1, 1, 1);
        public static Vector3 Up => new Vector3(0, 1, 0);
        public static Vector3 Forward => new Vector3(0, 0, 1);
        public static Vector3 UnitX => new Vector3(1, 0, 0);
        public static Vector3 UnitY => new Vector3(0, 1, 0);
        public static Vector3 UnitZ => new Vector3(0, 0, 1); 
        #endregion

        //how to overload operator in C#? +, -, *, / 
        //myVec = yourVec + theirVec

        //public static Vector3 Zero
        //{
        //    get
        //    {
        //        return new Vector3(0, 0, 0);
        //    }
        //}


        #region Properties

        public float X
        {
            get => _x;
            set => _x = float.IsNaN(value) ? 0 : value;  //TODO - add isNan
        }


        public float Y
        {
            get => _y;
            set
            {
                _y = float.IsNaN(value) ? 0 : value;  //TODO - add isNan
            }
        }

        public float Z
        {
            get => _z;
            set => _z = float.IsNaN(value) ? 0 : value; //TODO - add isNan
        }

        public float Magnitude => (float)System.Math.Sqrt(_x * _x + _y * _y + _z * _z);
        public float SqrMagnitude => _x * _x + _y * _y + _z * _z;

        #endregion

        #region Constructors
        public Vector3()  //default
            : this(0, 0, 0)
        {

        }
        public Vector3(float x, float y, float z) //full
        {
            X = x;
            Y = y;
            Z = z;
        }

        #endregion

        #region Class-specific

        public float Dot(Vector3 other)
        {
            return _x * other.X
                        + _y * other.Y
                               + _z * other.Z;
        }

        public static float Dot(Vector3 a, Vector3 b)
        {
            return a.X * b.X
                     + a.Y * b.Y
                            + a.Z * b.Z;
        }

        public Vector3 Cross(Vector3 other)
        {
            return new Vector3(
                _y * other.Z - _z * other.Y,
                _z * other.X - _x * other.Z,
                _x * other.Y - _y * other.X
            );
        }

        public static Vector3 Cross(Vector3 a, Vector3 b)
        {
            return new Vector3(
                a.Y * b.Z - a.Z * b.Y,
                a.Z * b.X - a.X * b.Z,
                a.X * b.Y - a.Y * b.X
            );
        } 
  
        public void Normalize() //mutating
        {
            float mag = Magnitude;

            if (mag == 0)
                return;

            _x /= mag;
            _y /= mag;
            _z /= mag;
        }

        #endregion

        #region Overrides
        public override string ToString()
        {
            return $"({_x},{_y},{_z})";
        }
        #endregion

    }
}
