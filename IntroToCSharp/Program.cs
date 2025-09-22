using GDEngine.Maths;

namespace GDEngine
{
    /// <summary>
    /// This Program class demonstrates:
    /// 1. Writing simple methods in C# (add, multiply, divide).
    /// 2. How to instantiate and use custom classes (Vector3, Transform3D).
    /// 3. Selected solutions to the exercises
     /// </summary>
    public class Program
    {
        // Main() is our entry/insertion point
        public static void Main(string[] args)
        {
            Program app = new Program();
            app.RunDemos();
        }

        #region Demos
        public void RunDemos()
        {
            Console.WriteLine("\n--------------- DemoMathMethods() ---------------\n");
            DemoMathMethods();

            Console.WriteLine("\n--------------- DemoVector3() ---------------\n");
            DemoVector3();

            Console.WriteLine("\n--------------- DemoTransform3D() ---------------\n");
            DemoTransform3D();

            Console.WriteLine("\n--------------- RunExercises() ---------------\n");
            RunExercises();

        }
 
        #region Vector3

        private void DemoVector3()
        {
            DemoVector3Instantiation();
            DemoVector3Magnitude();
            DemoVector3Normalization();
            DemoVector3DotAndAngle();
            DemoVector3Cross();
            DemoVector3Operators();
            DemoVector3Copying();
        }

        private void DemoVector3Instantiation()
        {
            Console.WriteLine("\n--- Vector3 Instantiation ---");

            var v1 = new GDEngine.Maths.Vector3(0, 1.8f, 0);
            Console.WriteLine("Player translation vector = " + v1);

            var v2 = new GDEngine.Maths.Vector3(3, 4, 5);
            Console.WriteLine("Vector[a] = " + v2);
        }

        private void DemoVector3Magnitude()
        {
            Console.WriteLine("\n--- Vector3 Magnitude ---");

            var v = new GDEngine.Maths.Vector3(3, 4, 5);
            Console.WriteLine($"Vector = {v}, Magnitude = {v.Magnitude}");
        }

        private void DemoVector3Normalization()
        {
            Console.WriteLine("\n--- Vector3 Normalization ---");

            var v = new GDEngine.Maths.Vector3(3, 4, 5);
            Console.WriteLine("Before normalization: " + v);

            v.Normalize(); // mutating
            Console.WriteLine("After Normalize(): " + v + $", Magnitude = {v.Magnitude}");

            var b = new GDEngine.Maths.Vector3(10, 0, 0);
            var bNorm = b.Normalized; // non-mutating
            Console.WriteLine($"Original b = {b}, Normalized copy = {bNorm}");
        }

        private void DemoVector3DotAndAngle()
        {
            Console.WriteLine("\n--- Vector3 Dot Product & Angle ---");

            var xAxis = new GDEngine.Maths.Vector3(1, 0, 0);
            var yAxis = new GDEngine.Maths.Vector3(0, 1, 0);

            var dotXY = xAxis.Dot(yAxis);
            Console.WriteLine($"Dot(xAxis, yAxis) = {dotXY}");

            var angleXY = MathF.Acos(dotXY / (xAxis.Magnitude * yAxis.Magnitude));
            Console.WriteLine($"Angle between xAxis and yAxis = {GDMath.ToDegrees(angleXY)} degrees");
        }

        private void DemoVector3Cross()
        {
            Console.WriteLine("\n--- Vector3 Cross Product ---");

            var xAxis = new GDEngine.Maths.Vector3(1, 0, 0);
            var yAxis = new GDEngine.Maths.Vector3(0, 1, 0);

            var zAxis = xAxis.Cross(yAxis);
            Console.WriteLine($"Cross(xAxis, yAxis) = {zAxis}");
        }

        private void DemoVector3Operators()
        {
            Console.WriteLine("\n--- Vector3 Operator Overloading ---");

            var xAxis = new GDEngine.Maths.Vector3(1, 0, 0);
            var yAxis = new GDEngine.Maths.Vector3(0, 1, 0);

            var vecResult = xAxis + yAxis;
            Console.WriteLine($"xAxis + yAxis = {vecResult}");

            var a = new GDEngine.Maths.Vector3(3, 4, 5);
            var vecOtherResult = a / 2;
            Console.WriteLine($"Vector[a] / 2 = {vecOtherResult}");
        }

        private void DemoVector3Copying()
        {
            Console.WriteLine("\n--- Vector3 Copying (Shallow vs Deep) ---");

            var v1 = new GDEngine.Maths.Vector3(2, 4, 6);
            var shallow = (GDEngine.Maths.Vector3)v1.Clone();
            var deep = v1.DeepCopy();

            Console.WriteLine("Original: " + v1);
            Console.WriteLine("Shallow copy: " + shallow);
            Console.WriteLine("Deep copy: " + deep);

            v1.X = 99;
            Console.WriteLine("\nAfter modifying original.X = 99:");
            Console.WriteLine("Original: " + v1);
            Console.WriteLine("Shallow: " + shallow);
            Console.WriteLine("Deep: " + deep);
        }
        #endregion

        #region Transform3D

        private void DemoTransform3D()
        {
            DemoTransform3DInstantiation();
            DemoTransform3DTranslate();
            DemoTransform3DRotate();
            DemoTransform3DScale();
            DemoTransform3DCopying();
        }

        private void DemoTransform3DInstantiation()
        {
            Console.WriteLine("\n--- Transform3D Instantiation ---");

            var t1 = new GDEngine.Scene.Transform();
            Console.WriteLine("Default constructor: " + t1);

            var t2 = new GDEngine.Scene.Transform(new GDEngine.Maths.Vector3(5, 1, 0));
            Console.WriteLine("Constructor with position (5,1,0): " + t2);
        }

        private void DemoTransform3DTranslate()
        {
            Console.WriteLine("\n--- Transform3D Translate ---");

            var t = new GDEngine.Scene.Transform();
            Console.WriteLine("Before translation: " + t);

            t.Translate(new GDEngine.Maths.Vector3(1, 2, 3));
            Console.WriteLine("After Translate(1,2,3): " + t);
        }

        private void DemoTransform3DRotate()
        {
            Console.WriteLine("\n--- Transform3D Rotate ---");

            var t = new GDEngine.Scene.Transform();
            Console.WriteLine("Before rotation: " + t);

            t.Rotate(new GDEngine.Maths.Vector3(0, 90, 0));
            Console.WriteLine("After Rotate(0,90,0): " + t);
        }

        private void DemoTransform3DScale()
        {
            Console.WriteLine("\n--- Transform3D Scale ---");

            var t = new GDEngine.Scene.Transform();
            Console.WriteLine("Before scale: " + t);

            t.ScaleBy(new GDEngine.Maths.Vector3(2, 1, 0.5f));
            Console.WriteLine("After ScaleBy(2,1,0.5): " + t);
        }

        private void DemoTransform3DCopying()
        {
            //Console.WriteLine("\n--- Transform3D Copying (Shallow vs Deep) ---");

            //var original = new GDEngine.Scene.Transform(new GDEngine.Math.Vector3(2, 3, 4));
            //Console.WriteLine("Original: " + original);

            //var shallow = (GDEngine.Scene.Transform)original.Clone();
            //var deep = original.DeepCopy();

            //Console.WriteLine("Shallow copy: " + shallow);
            //Console.WriteLine("Deep copy: " + deep);

            //// Modify original
            //original.Position = new GDEngine.Math.Vector3(99, 99, 99);
            //Console.WriteLine("\nAfter modifying original position:");
            //Console.WriteLine("Original: " + original);
            //Console.WriteLine("Shallow: " + shallow);
            //Console.WriteLine("Deep: " + deep);
        }

        #endregion

        #region Math

        private void DemoMathMethods()
        {
            // Demo the math-related methods 
            Console.WriteLine("Divide: " + divide(5, 9));
            Console.WriteLine("Multiply: " + multiply(3, 4));
            Console.WriteLine("Add: " + add(7, 2));
        }

        public int multiply(int x, int y) => x * y;   // Expression-bodied

        public int add(int x, int y)
        {
            return x + y;
        }

        public float divide(int x, int y)
        {
            return (float)x / y;
        }
        #endregion

        #endregion

        #region Exercises
        public void RunExercises()
        {
            ExerciseClassDefinition();
        }

        public void ExerciseClassDefinition()
        {
            Console.WriteLine("--- ColorRGBA ---");

            // Create a custom color
            ColorRGBA col1 = new ColorRGBA(0.25f, 0.5f, 0.75f, 1f);
            Console.WriteLine($"col1 = {col1}");

            // Use the default constructor (white)
            ColorRGBA col2 = new ColorRGBA();
            Console.WriteLine($"col2 (default) = {col2}");

            // Test static helpers
            Console.WriteLine($"Red   = {ColorRGBA.Red}");
            Console.WriteLine($"Green = {ColorRGBA.Green}");
            Console.WriteLine($"Blue  = {ColorRGBA.Blue}");
            Console.WriteLine($"Black = {ColorRGBA.Black}");
            Console.WriteLine($"White = {ColorRGBA.White}");

            // Grayscale conversion
            ColorRGBA gray = col1.ToGrayscale();
            Console.WriteLine($"Grayscale of col1 = {gray}");

            // Operator overloads
            ColorRGBA add = col1 + ColorRGBA.Red;
            Console.WriteLine($"col1 + Red = {add}");

            ColorRGBA dark = col1 * 0.5f;
            Console.WriteLine($"col1 * 0.5 = {dark}");

            // Lerp between colors
            ColorRGBA mid = ColorRGBA.Lerp(ColorRGBA.Red, ColorRGBA.Blue, 0.5f);
            Console.WriteLine($"Lerp(Red, Blue, 0.5) = {mid}");

            // HSV conversion
            Vector3 hsv = ColorRGBA.ToHSV(col1);
            Console.WriteLine($"col1 as HSV = {hsv}");

            ColorRGBA backToRGB = ColorRGBA.FromHSV(hsv);
            Console.WriteLine($"HSV -> RGB = {backToRGB}");
        }

        #endregion
    }
}
