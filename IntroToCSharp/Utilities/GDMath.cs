namespace GDEngine.Maths
{
    /// <summary>
    /// A collection of math utility methods for conversions and helper functions.
    /// </summary>
    /// 
    /// <remarks>
    /// Note: Use MathF (float precision) instead of Math (double precision) to stay consistent with Vector3’s float fields.
    /// </remarks>
    /// 
    /// <see href="https://learn.microsoft.com/en-us/dotnet/api/system.mathf">MathF</see> (float precision) instead of <see href="https://learn.microsoft.com/en-us/dotnet/api/system.math">Math</see> (double precision) to stay consistent with Vector3’s float fields.
    public class GDMath
    {
        /// <summary>
        /// Converts radians to degrees.
        /// </summary>
        public static float ToDegrees(float radians)
        {
            return radians * (180f / MathF.PI);
        }

        /// <summary>
        /// Converts degrees to radians.
        /// </summary>
        public static float ToRadians(float degrees)
        {
            return degrees * (MathF.PI / 180f);
        }

        /// <summary>
        /// Clamps the value between 0.0 and 1.0.
        /// </summary>
        public static float Clamp(float value)
        {
            return (value < 0f) ? 0f : (value > 1f) ? 1f : value;
        }
    }
}
