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
            set => _x = value < 0 ? 0 : value;  //TODO - add isNan
        }

        public float Y
        {
            get => _y;
            set => _y = value < 0 ? 0 : value;  //TODO - add isNan
        }

        public float Z
        {
            get => _z;
            set => _z = value; //TODO - add isNan
        }

        #endregion

        #region Constructors
        public Vector3(float x, float y, float z)
        {
            _x = x;
            _y = y;
            _z = z;
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
