
namespace GDEngine.Maths
{
    /// <summary>
    /// Represents a color with Red, Green, Blue, and Alpha components.
    /// Values are clamped between 0.0 and 1.0.
    /// </summary>
    public class ColorRGBA
    {
        #region Fields
        private float _r;
        private float _g;
        private float _b;
        private float _a;
        #endregion

        #region Properties
        public float R
        {
            get => _r;
            set => _r = GDMath.Clamp(value); 
        }

        public float G
        {
            get => _g;
            set => _g = GDMath.Clamp(value);
        }

        public float B
        {
            get => _b;
            set => _b = GDMath.Clamp(value);
        }

        public float A
        {
            get => _a;
            set => _a = GDMath.Clamp(value);
        }
        #endregion

        #region Constants
        public static ColorRGBA Red => new ColorRGBA(1f, 0f, 0f, 1f);
        public static ColorRGBA Green => new ColorRGBA(0f, 1f, 0f, 1f);
        public static ColorRGBA Blue => new ColorRGBA(0f, 0f, 1f, 1f);
        public static ColorRGBA Black => new ColorRGBA(0f, 0f, 0f, 1f);
        public static ColorRGBA White => new ColorRGBA(1f, 1f, 1f, 1f);
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor creates a white color (1,1,1,1).
        /// </summary>
        public ColorRGBA() : this(1f, 1f, 1f, 1f) { }

        /// <summary>
        /// Constructor with custom RGBA values.
        /// </summary>
        public ColorRGBA(float r, float g, float b, float a)
        {
            R = r; 
            G = g; 
            B = b; 
            A = a;
        }
        #endregion

        #region Operators
        public static ColorRGBA operator +(ColorRGBA c1, ColorRGBA c2)
        {
            return new ColorRGBA(GDMath.Clamp(c1._r + c2._r),
                            GDMath.Clamp(c1._g + c2._g),
                                GDMath.Clamp(c1._b + c2._b),
                                    GDMath.Clamp(c1._a + c2._a));
        }

        public static ColorRGBA operator *(ColorRGBA c, float scalar)
        {
            return new ColorRGBA(
                GDMath.Clamp(c._r * scalar),
                GDMath.Clamp(c._g * scalar),
                GDMath.Clamp(c._b * scalar),
                GDMath.Clamp(c._a * scalar)
            );
        }
        #endregion

        #region Overrides
        public override string ToString() =>
            $"({_r}, {_g}, {_b})";
        #endregion

        #region Cloning
        /// <summary>
        /// Returns a deep copy of this color.
        /// </summary>
        public ColorRGBA DeepCopy()
        {
            return new ColorRGBA(_r, _g, _b, _a);
        }
        #endregion

        #region Class-specific
        /// <summary>
        /// Returns a grayscale version of this color (alpha preserved).
        /// </summary>
        public ColorRGBA ToGrayscale()
        {
            float gray = (0.299f * _r) + (0.587f * _g) + (0.114f * _b);
            return new ColorRGBA(gray, gray, gray, _a);
        }
        /// <summary>
        /// Linearly interpolates between two colors.
        /// </summary>
        public static ColorRGBA Lerp(ColorRGBA a, ColorRGBA b, float t)
        {
            t = GDMath.Clamp(t); //limit 0-1
            return new ColorRGBA(a._r + (b._r - a._r) * t,
                a._g + (b._g - a._g) * t,
                a._b + (b._b - a._b) * t,
                a._a + (b._a - a._a) * t
            );
        }

        /// <summary>
        /// Converts RGB to HSV. Returns a Vector3(H,S,V).
        /// </summary>
        public static Vector3 ToHSV(ColorRGBA color)
        {
            float max = Math.Max(Math.Max(color.R, color.G), color.B);
            float min = Math.Min(Math.Min(color.R, color.G), color.B);
            float delta = max - min;

            float h = 0f;

            if (delta > 0f)
            {
                if (max == color.R)
                    h = (color.G - color.B) / delta;
                else if (max == color.G)
                    h = 2f + (color.B - color.R) / delta;
                else
                    h = 4f + (color.R - color.G) / delta;

                h *= 60f;
                if (h < 0f) h += 360f;
            }

            float s = (max > 0f) ? delta / max : 0f;
            float v = max;

            return new Vector3(h, s, v);
        }

        /// <summary>
        /// Converts HSV to a ColorRGBA (A=1).
        /// </summary>
        public static ColorRGBA FromHSV(Vector3 hsv)
        {
            // Extract hue (0–360), saturation (0–1), and value/brightness (0–1)
            float h = hsv.X;
            float s = hsv.Y;
            float v = hsv.Z;

            // Determine which 60 degree hue sector the angle falls into (0–5)
            int hi = (int)(h / 60f) % 6;

            // Position within the sector (0–1)
            float f = (h / 60f) - (int)(h / 60f);

            // Precompute intermediate values for RGB conversion
            float p = v * (1f - s);
            float q = v * (1f - f * s);
            float t = v * (1f - (1f - f) * s);

            // Select final RGB values based on the hue sector
            switch (hi)
            {
                case 0: return new ColorRGBA(v, t, p, 1f);
                case 1: return new ColorRGBA(q, v, p, 1f);
                case 2: return new ColorRGBA(p, v, t, 1f);
                case 3: return new ColorRGBA(p, q, v, 1f);
                case 4: return new ColorRGBA(t, p, v, 1f);
                default: return new ColorRGBA(v, p, q, 1f);
            }

            //REFACTOR - consider use of C# 8.0 switch expression
            //return hi switch
            //{
            //    0 => new ColorRGBA(v, t, p, 1f),
            //    1 => new ColorRGBA(q, v, p, 1f),
            //    2 => new ColorRGBA(p, v, t, 1f),
            //    3 => new ColorRGBA(p, q, v, 1f),
            //    4 => new ColorRGBA(t, p, v, 1f),
            //    _ => new ColorRGBA(v, p, q, 1f),
            //};

        }
        #endregion
    }
}
