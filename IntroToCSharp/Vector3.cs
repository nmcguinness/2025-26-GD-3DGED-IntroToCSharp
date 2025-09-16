using System.Reflection.Metadata.Ecma335;

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

        #endregion

        #region Constructors
        public Vector3()  //default
            : this(0,0,0)
        {

        }
        public Vector3(float x, float y, float z) //full
        {
            X = x;
            Y = y;
            Z = z;
        }

        #endregion

        //Class-specific
        public float Magnitude()
        {
            
            return (float)System.Math.Sqrt(_x * _x
                                        + _y * _y
                                            + _z * _z);
        }

     //   public Vector3 Normalized => this / Magnitude();

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

        //Cross, (static) Cross


        public void Normalize() //mutating
        {
            float mag = Magnitude();

            if (mag == 0)
                return;

            _x /= mag;
            _y /= mag;
            _z /= mag;
        }



        #region Overrides
        public override string ToString()
        {
            return $"({_x},{_y},{_z})";
        } 
        #endregion

    }
}
