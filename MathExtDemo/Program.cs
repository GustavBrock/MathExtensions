using System;
using SystemExt;


namespace MathExtDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal value = 30.675m;
            int digits = 49;

            for (int i = 0; i < 10; i++)
            {
                decimal roundedValue = MathExt.RoundSignificant(value, digits);
                Console.WriteLine("input value: {0} - Rounded value: {1}", value.ToString(), roundedValue.ToString());
                value++;
            }
            Console.WriteLine();

            value = 30.675m;
            digits = 4;

            for (int i = 0; i < 10; i++)
            {
                decimal roundedValue = MathExt.RoundSignificant(value, digits, MidpointRounding.ToEven);
                Console.WriteLine("input value: {0} - Rounded value: {1}", value.ToString(), roundedValue.ToString());
                value++;
            }
            Console.WriteLine();
            
            value = 30.685m;
            digits = 4;

            for (int i = 0; i < 10; i++)
            {
                decimal roundedValue = MathExt.RoundSignificant(value, digits);
                Console.WriteLine("input value: {0} - Rounded value: {1}", value.ToString(), roundedValue.ToString());
                value++;
            }
            Console.WriteLine();
            
            value = 30.685m;
            digits = 4;

            for (int i = 0; i < 10; i++)
            {
                decimal roundedValue = MathExt.RoundSignificant(value, digits, MidpointRounding.ToEven);
                Console.WriteLine("input value: {0} - Rounded value: {1}", value.ToString(), roundedValue.ToString());
                value++;
            }
            Console.ReadKey();

            for (double i = 0; i < 180; i++)
            {
                Console.WriteLine(i.ToString() + " " + MathExt.Factorial(i).ToString());
            }
            Console.ReadKey();

            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine(i.ToString() + " " + MathExt.Factorial(i).ToString());
            }
            decimal f = MathExt.Factorial(20);
            Console.ReadKey();

            //for (int i = 0; i < 1500; i++)
            //{
            //    Console.WriteLine(i.ToString() + " " + MathExt.Fibonacci((double)i).ToString());
            //}
            //Console.ReadKey();

            //for (int i = 0; i < 150; i++)
            //{
            //    Console.WriteLine(i.ToString() + " " + MathExt.Fibonacci(i).ToString());
            //}
            //Console.ReadKey();
            decimal dest = MathExt.RoundSignificant(decimal.MaxValue, 27, false, MidpointRounding.AwayFromZero);
            Console.WriteLine(decimal.MaxValue.ToString());
            Console.WriteLine(dest.ToString());
            Console.ReadKey();

            //double test = MathExt.RoundSignificant(123456789012345678d, 10, false, MidpointRounding.AwayFromZero);
            //Console.WriteLine(test.ToString());
            //Console.ReadKey();

            decimal d = 120000000000.345m;
            Console.WriteLine(MathExt.RoundUp(d, 28, UpRounding.AwayFromZero).ToString());
            Console.WriteLine(MathExt.RoundUp(d, 28, UpRounding.Up).ToString());
            Console.WriteLine(MathExt.RoundUp(-d, 28, UpRounding.AwayFromZero).ToString());
            Console.WriteLine(MathExt.RoundUp(-d, 28, UpRounding.Up).ToString());
            Console.WriteLine(MathExt.RoundUp(d, -1, UpRounding.AwayFromZero).ToString());
            Console.WriteLine(MathExt.RoundUp(d, -1, UpRounding.Up).ToString());
            Console.WriteLine(MathExt.RoundUp(-d, -1, UpRounding.AwayFromZero).ToString());
            Console.WriteLine(MathExt.RoundUp(-d, -1, UpRounding.Up).ToString());
            Console.ReadKey();
        }
    }


}
