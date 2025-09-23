using GDEngine.Maths;
using GDEngine.Scene;
using System.Data.SqlTypes;

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

            app.RunExercises();
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

            Console.WriteLine("\n--------------- DemoAction() ---------------\n");
            DemoAction();
  
            Console.WriteLine("\n--------------- DemoFunc() ---------------\n");
            DemoFunc();

            Console.WriteLine("\n--------------- DemoPredicate() ---------------\n");
            DemoPredicate();

            Console.WriteLine("\n--------------- DemoListMethods() ---------------\n");
            DemoListMethods();
        }

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

            var t1 = new Scene.Transform3D();
            Console.WriteLine("Default constructor: " + t1);

            var t2 = new Scene.Transform3D(new Vector3(5, 1, 0));
            Console.WriteLine("Constructor with position (5,1,0): " + t2);
        }

        private void DemoTransform3DTranslate()
        {
            Console.WriteLine("\n--- Transform3D Translate ---");

            var t = new Scene.Transform3D();
            Console.WriteLine("Before translation: " + t);

            t.Translate(new Vector3(1, 2, 3));
            Console.WriteLine("After Translate(1,2,3): " + t);
        }

        private void DemoTransform3DRotate()
        {
            Console.WriteLine("\n--- Transform3D Rotate ---");

            var t = new GDEngine.Scene.Transform3D();
            Console.WriteLine("Before rotation: " + t);

            t.Rotate(new GDEngine.Maths.Vector3(0, 90, 0));
            Console.WriteLine("After Rotate(0,90,0): " + t);
        }

        private void DemoTransform3DScale()
        {
            Console.WriteLine("\n--- Transform3D Scale ---");

            var t = new GDEngine.Scene.Transform3D();
            Console.WriteLine("Before scale: " + t);

            t.ScaleBy(new GDEngine.Maths.Vector3(2, 1, 0.5f));
            Console.WriteLine("After ScaleBy(2,1,0.5): " + t);
        }

        private void DemoTransform3DCopying()
        {
            Console.WriteLine("\n--- Transform3D Copying (Shallow vs Deep) ---");
            Transform3D t1 = new Transform3D(Vector3.Zero,
                Vector3.Zero, Vector3.One * 4);

            //lets make a mistake and make SHALLOW COPY
            Transform3D? shallowT1 = t1.Clone() as Transform3D;
            Transform3D deepT1 = t1.DeepCopy();

            //move the first tank
            t1.Translate(new Vector3(5, 10, 20));

            //oops the 2nd moved too!
            Console.WriteLine("t1: " + t1);
            Console.WriteLine("shallowT1: " + shallowT1);
            Console.WriteLine("deepT1: " + deepT1);
        }

        #endregion

        #region Action, Func, Predicate, Lambda
        private void DemoAction()
        {
            // 1. Action<T> with one parameter
            Action<string> toLowerAndPrint = s => Console.WriteLine(s.ToLower());
            toLowerAndPrint("RoBERtA"); // output: "roberta"

            // 2. Action<T> with multi-line body
            Action<int> testNegativeAndNotify = number =>
            {
                string msg = number > 0 ? "Positive" : "Negative or Zero";
                Console.WriteLine(msg);
            };
            testNegativeAndNotify(-5); // output: "Negative or Zero"

            // 3. Action<T> with multiple parameters
            Action<int, int> playSound = (freq, ms) => Console.Beep(freq, ms);
            playSound(1000, 500); // short beep

            // 4. Real-world use: processing a list
            List<int> nums = new List<int> { 1, 2, 3, 4, 5 };
            Action<int> printDouble = n => Console.WriteLine(n * 2);
            nums.ForEach(printDouble); // output: 2, 4, 6, 8, 10
        }


        public void DoSomethingFunky(Action<int, int> theAction, 
            int p1, int p2)
        {
            theAction(p1, p2);
        }

        //public void ExecuteList(List<Action<Player>> actionList,
        //    Player target)
        //{

        //}


        public void Beep(int freq, int timeMs)
        {
            Console.Beep(freq, timeMs);
        }



        private void DemoFunc()
        { 
            // 1. Func with one input, one output
            // Func<int, int> means: take an int, return an int
            Func<int, int> square = x => x * x;
            Console.WriteLine($"Square of 5 = {square(5)}");  // output: 25

            // 2. Func with different input/output types
            // Func<string, int> means: take a string, return its length as int
            Func<string, int> getLength = s => s.Length;
            Console.WriteLine($"Length of 'banana' = {getLength("banana")}");  // output: 6

            // 3. Func with multiple parameters
            // Func<int, int, int> means: take two ints, return an int
            Func<int, int, int> add = (a, b) => a + b;
            Console.WriteLine($"3 + 4 = {add(3, 4)}");  // output: 7

            // 4. Func with a collection (real-world use, string processing)
            List<string> names = new List<string> { "alice", "bob", "charlie" };

            // Convert all names by capitalising the first letter
            List<string> capitalisedNames = names.ConvertAll(
                s => char.ToUpper(s[0]) + s.Substring(1)
            );

            Console.WriteLine("Capitalised names:");
            capitalisedNames.ForEach(n => Console.WriteLine(n));


        }

        private void DemoPredicate()
        {
            // 1. Basic example with numbers
            // Predicate<int> means: takes an int, returns true/false
            Predicate<int> isEven = x => (x % 2 == 0);

            Console.WriteLine($"Is 4 even? {isEven(4)}");   // true
            Console.WriteLine($"Is 7 even? {isEven(7)}");   // false

            // 2. Predicate<string> for simple validation
            Predicate<string> isLongerThan = s => s.Length > 5;

            Console.WriteLine($"Is 'Canada' longer than 5? {isLongerThan("Canada")}");
            Console.WriteLine($"Is 'UK' longer than 5? {isLongerThan("UK")}");

            // 3. Real-world use: filtering a list
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

            // Remove all numbers that do NOT match the predicate (keep only evens)
            numbers.RemoveAll(n => isEven(n));

            Console.WriteLine("Odd numbers left in the list:");
            numbers.ForEach(n => Console.WriteLine(n));
        }


        public bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        public bool IsEvenVersionTwo(int number) => number % 2 == 0;

        #endregion

        #region List methods
        private void DemoListMethods()
        {
            // 1. Create a list of integers
            List<int> numberList = new List<int> { 10, 24, 45, 100, 75 };

            // 2. ForEach(Action<T>) – apply an Action to each element
            Console.WriteLine("Numbers in the list:");
            numberList.ForEach(n => Console.WriteLine(n));

            // 3. TrueForAll(Predicate<T>) – check if all items match a condition
            bool allGreaterThanValue = numberList.TrueForAll(n => n > 10);
            Console.WriteLine($"Are all numbers > 10? {allGreaterThanValue}");

            // 4. ConvertAll(Func<T, TResult>) – create a new list with transformed elements
            List<int> doubled = numberList.ConvertAll(n => n * 2);
            Console.WriteLine("Doubled numbers:");
            doubled.ForEach(n => Console.WriteLine(n));

            // 5. RemoveAll(Predicate<T>) – remove elements that match a condition
            numberList.RemoveAll(n => n < 20);
            Console.WriteLine("After removing numbers < 20:");
            numberList.ForEach(n => Console.WriteLine(n));

            // 6. Find(Predicate<T>) – returns the FIRST item matching the condition
            int firstOverThresholdValue = numberList.Find(n => n > 50);
            Console.WriteLine($"First number > 50: {firstOverThresholdValue}");

            // 7. FindAll(Predicate<T>) – returns ALL items matching the condition
            List<int> allEven = numberList.FindAll(n => n % 2 == 0);
            Console.WriteLine("All even numbers:");
            allEven.ForEach(n => Console.WriteLine(n));

            // 8. Exists(Predicate<T>) – returns true if ANY item matches
            bool hasMaxValue = numberList.Exists(n => n == 100);
            Console.WriteLine($"Does the list contain max value for health? {hasMaxValue}");

            // 9. Using List<Vector3>
            List<Vector3> vectors = new List<Vector3>
                {
                    10 * Vector3.One,
                    new Vector3(40, 50, 60),
                    Vector3.Up
                };

            // 10. RemoveAll(Predicate<T>) – remove vectors with magnitude < 2
            vectors.RemoveAll(v => v.Magnitude < 2);
            Console.WriteLine("Remaining vectors (magnitude >= 2):");
            vectors.ForEach(v => Console.WriteLine(v));
        }



        #endregion

        #endregion

        #region Exercises

        public void RunExercises()
        {
            Console.WriteLine("\n--------------- ExerciseClassDefinition() ---------------\n");
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
