using System;
using SystemExt;

namespace MathExtDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo demo = new Demo();
            demo.RoundingDemo();
          //  demo.FactorialDemo();
          //  demo.FibonacciDemo();

            Console.WriteLine(MathExt.Mantissa(0.01234000m));
            Console.ReadKey();
        }
    }

    class Demo
    { 
        public void RoundingDemo()
        {
            decimal value = 30.675m;
            int digits = 4;

            Console.WriteLine("Scaling significant figures:");
            for (int i = 0; i < 10; i++)
            {
                decimal testValue = value * (decimal)Math.Pow(10, i - 3);
                decimal roundedValue = MathExt.RoundSignificant(testValue, digits);
                Console.WriteLine("input value: {0} \t - Rounded value: {1}", ((double)testValue).ToString(), roundedValue.ToString());
            }
            Console.WriteLine();

            value = 30.675m;
            digits = 4;

            Console.WriteLine("Rounding to even:");
            for (int i = 0; i < 10; i++)
            {
                decimal roundedValue = MathExt.RoundSignificant(value, digits, MidpointRounding.ToEven);
                Console.WriteLine("input value: {0} - Rounded value: {1}", value.ToString(), roundedValue.ToString());
                value++;
            }
            Console.WriteLine();

            value = 30.685m;
            digits = 4;

            Console.WriteLine("Rounding away from zero:");
            for (int i = 0; i < 10; i++)
            {
                decimal roundedValue = MathExt.RoundSignificant(value, digits);
                Console.WriteLine("input value: {0} - Rounded value: {1}", value.ToString(), roundedValue.ToString());
                value++;
            }
            Console.WriteLine();

            value = 30.685m;
            digits = 4;

            Console.WriteLine("Rounding to even:");
            for (int i = 0; i < 10; i++)
            {
                decimal roundedValue = MathExt.RoundSignificant(value, digits, MidpointRounding.ToEven);
                Console.WriteLine("input value: {0} - Rounded value: {1}", value.ToString(), roundedValue.ToString());
                value++;
            }
            Console.WriteLine();
            Console.ReadKey();

            value = 30.685m * (decimal)Math.Pow(10, 9);
            digits = 4;

            Console.WriteLine("Rounding away from zero:");
            for (int i = 0; i < 10; i++)
            {
                decimal roundedValue = MathExt.RoundSignificant(value + i * (decimal)Math.Pow(10, 9), digits);
                Console.WriteLine("input value: {0} - Rounded value: {1}", ((double)value + i * Math.Pow(10, 9)).ToString(), roundedValue.ToString());
                //value++;
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        public void FactorialDemo()
        {
            Console.WriteLine("Factorial as double:");
            for (double i = 0; i < 180; i++)
            {
                Console.WriteLine(i.ToString() + " " + MathExt.Factorial(i).ToString());
            }
            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine("Factorial as decimal:");
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine(i.ToString() + " " + MathExt.Factorial(i).ToString());
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        public void FibonacciDemo()
        {
            Console.WriteLine("Fibonacci as double:");
            for (int i = 0; i < 1500; i++)
            {
                Console.WriteLine(i.ToString() + " " + MathExt.Fibonacci((double)i).ToString());
            }
            Console.WriteLine();
            Console.ReadKey();

            Console.WriteLine("Fibonacci as decimal:");
            for (int i = 0; i < 150; i++)
            {
                Console.WriteLine(i.ToString() + " " + MathExt.Fibonacci(i).ToString());
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }

}
