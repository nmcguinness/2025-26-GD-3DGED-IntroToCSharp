


using System.Numerics;

namespace IntroToCSharp
{
    public class Program
    {
        //Main() is our insertion point for the application
        public static void Main(string[] args)
        {
            Program app = new Program();
            app.RunDemos();
        }

        public void RunDemos()
        {
            DemoMathMethods();

            DemoVector3();

            DemoClassSpecific();
        }

        private void DemoClassSpecific()
        {
            //magnitude
            GDEngine.Math.Vector3 a = new GDEngine.Math.Vector3(3, 4, 5);
            Console.WriteLine("Mag: " + a.Magnitude());

            var b = new GDEngine.Math.Vector3(0,0,0);
            Console.WriteLine("Mag: " + b.Magnitude());

            //normalize
            Console.WriteLine("Before normalization: " + a);
            a.Normalize();
            Console.WriteLine("After normalization: " + a);

            Console.WriteLine("Mag after normalization: " + a.Magnitude());
            //dot
        }

        private void DemoMathMethods()
        {
            //Demo the math-related methods 
            Console.WriteLine(divide(5, 9));
        }

        private void DemoVector3()
        {
            //Instantiate a Vector3
            GDEngine.Math.Vector3 playerTranslation = new GDEngine.Math.Vector3(0, 1.8f, 0);

            //Demo validation
            // playerTranslation.y = -100;
            playerTranslation.Y = -100; //validation kicks-in

            //Demo ToString
            Console.WriteLine(playerTranslation.ToString());

            //Demo implicit "stringification" as a consequence of using WriteLine()
            Console.WriteLine(playerTranslation);
        }

        public int multiply(int x, int y) => x * y;         //Expression-bodied member (EBM)
        public int add(int x, int y)
        {
            return x + y;
        }
        public float divide(int x, int y)
        {
            return (float)x / y;
            // return x / (float)y;
            //int result = x / y;
            //return (float)result;
            //return (float)(x / y);
        }
    }
}
