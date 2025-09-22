namespace GDEngine.Scene
{
    /// <summary>
    /// Represents position, rotation, and scale of an object in 3D space.
    /// This is the foundation of scene hierarchy, similar to Unity's Transform.
    /// </summary>
    /// 
    /// <see href="https://en.wikipedia.org/wiki/Euler_angles">Euler angles</see> (degrees).
    public class Transform
    {
        #region Fields
        private Maths.Vector3 _position;
        //euler angles in degrees
        private Maths.Vector3 _rotation; 
        private Maths.Vector3 _scale;

        //TODO - mark dirty (note: no relation to any person living or deceased)
        #endregion

        #region Properties
        public Maths.Vector3 Position
        {
            get => _position;
            set => _position = value;
        }

        public Maths.Vector3 Rotation
        {
            get => _rotation;
            set => _rotation = value;
        }

        public Maths.Vector3 Scale
        {
            get => _scale;
            set => _scale = value;
        }
        #endregion

        #region Constructors
        public Transform() //TODO - constructor chaining
        {
            _position = Maths.Vector3.Zero;
            _rotation = Maths.Vector3.Zero;
            _scale = Maths.Vector3.One;
        }

        public Transform(Maths.Vector3 position)
        {
            _position = position;
            _rotation = Maths.Vector3.Zero;
            _scale = Maths.Vector3.One;
        }
        #endregion

        #region Class-specific
        public void Translate(Maths.Vector3 translation)
        {
            _position += translation;
        }

        public void Rotate(Maths.Vector3 eulerAngles)
        {
            //TODO - replace Euler angles with Quaternions (to avoid gimbal lock)
            _rotation += eulerAngles;
        }

        public void ScaleBy(Maths.Vector3 scaleFactors)
        {
            _scale = new Maths.Vector3(
                _scale.X * scaleFactors.X,
                _scale.Y * scaleFactors.Y,
                _scale.Z * scaleFactors.Z
            );
        }

        public override string ToString()
        {
            return $"Transform(Position={_position}, Rotation={_rotation}, Scale={_scale})";
        }
        #endregion

        // TODO - Transform3D additions
        // - Clone, DeepCopy
        // - Parent/child hierarchy 
        // - Local vs world space conversions
        // - Forward/Right/Up vectors derived from Rotation
        // - Matrix conversion methods 
        // - Support for quaternions
    }
}
