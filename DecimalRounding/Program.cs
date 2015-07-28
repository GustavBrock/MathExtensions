using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimalExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal value = 30.675m;
            byte digits = 4;

            for (int i = 0; i < 10; i++)
            {
                decimal roundedValue = value.RoundToSignificantDigits(digits);
                Console.WriteLine("input value: {0} - Rounded value: {1}", value.ToString(), roundedValue.ToString());
                value++;
            }
            Console.ReadKey();
        }
    }
}
