using System;
using DecimalExtensions;


namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal value = 30.675m;
            int digits = 49;

            for (int i = 0; i < 10; i++)
            {
                decimal roundedValue = value.RoundToSignificantDigits(digits);
                Console.WriteLine("input value: {0} - Rounded value: {1}", value.ToString(), roundedValue.ToString());
                value++;
            }
            Console.WriteLine();

            value = 30.675m;
            digits = 4;

            for (int i = 0; i < 10; i++)
            {
                decimal roundedValue = value.RoundToSignificantDigits(digits,MidpointRounding.ToEven);
                Console.WriteLine("input value: {0} - Rounded value: {1}", value.ToString(), roundedValue.ToString());
                value++;
            }
            Console.WriteLine();
            
            value = 30.685m;
            digits = 4;

            for (int i = 0; i < 10; i++)
            {
                decimal roundedValue = value.RoundToSignificantDigits(digits);
                Console.WriteLine("input value: {0} - Rounded value: {1}", value.ToString(), roundedValue.ToString());
                value++;
            }
            Console.WriteLine();
            
            value = 30.685m;
            digits = 4;

            for (int i = 0; i < 10; i++)
            {
                decimal roundedValue = value.RoundToSignificantDigits(digits, MidpointRounding.ToEven);
                Console.WriteLine("input value: {0} - Rounded value: {1}", value.ToString(), roundedValue.ToString());
                value++;
            }
            Console.ReadKey();
            
            
            
        }
    }


}
