namespace System
{

    /// <summary>
    /// 
    /// </summary>
    public static class MathExt
    {
        // Maximum value of Factorial number before overflow.
        public const decimal FactorialMaxDecimal = 27m;
        public const double FactorialMaxDouble = 170d;

        // Maximum length of Fibonacci sequences before overflow.
        public const int FibonacciMaxDecimal = 139;
        public const int FibonacciMaxDouble = 1476;

        public static decimal Factorial(int number)
        {
            // Result value for FactorialMaxDecimal is:
            //  10888869450418352160768000000

            // Error result for out-of-range values.
            const decimal errResult = 0;

            decimal factorial = errResult;

            if (number >= 0 && number <= FactorialMaxDecimal)
            {
                factorial = FactorialSequence(number)[number];
            }
            return factorial;
        }

        public static double Factorial(double number)
        {
            // Result value for FactorialMaxDouble is:
            //  7.25741561530799E+306
            // Maximum count of significant figures for any value is 14.

            // Error result for out-of-range values.
            const double errResult = 0;

            double factorial = errResult;

            if (number >= 0 && number <= FactorialMaxDouble)
            {
                factorial = FactorialSequence(number)[(int)number];
            }
            return factorial;
        }

        public static decimal[] FactorialSequence(int number)
        {
            // Result value for FactorialMaxDecimal is:
            //  10888869450418352160768000000

            // Minimum result per definition.
            const decimal minResult = 1m;

            if (number < 0 || number > FactorialMaxDecimal)
            {
                // Cannot calculate the factorial.
                number = 0;
            }
            // Always enable element zero.
            int elements = 1 + number;
            decimal[] factorialSequence = new decimal[elements];

            for (int i = 0; i < elements; i++)
            {
                if (i <= 1)
                // Fill element zero and one per definition.
                {
                    factorialSequence[i] = minResult;
                }
                else
                // Fill remaining elements by calculation.
                {
                    factorialSequence[i] = i * factorialSequence[i - 1];
                }
            }

            return factorialSequence;
        }

        public static double[] FactorialSequence(double number)
        {
            // Result value for FactorialMaxDecimal is:
            //  10888869450418352160768000000

            // Minimum result per definition.
            const double minResult = 1;

            if (number < 0 || number > FactorialMaxDouble)
            {
                // Cannot calculate the factorial.
                number = 0;
            }
            // Always enable element zero.
            int elements = (int)(1 + number);
            double[] factorialSequence = new double[elements];

            for (int i = 0; i < elements; i++)
            {
                if (i <= 1)
                // Fill element zero and one per definition.
                {
                    factorialSequence[i] = minResult;
                }
                else
                // Fill remaining elements by calculation.
                {
                    factorialSequence[i] = i * factorialSequence[i - 1];
                }
            }

            return factorialSequence;
        }

        public static decimal Fibonacci(int number)
        {
            // Maximum and minimum result value for +/-maxValue is:
            //  +/-50095301248058391139327916261

            // Maximum value for reliable result.
            const int maxValue = FibonacciMaxDecimal;

            decimal fibonacci = 0;
            int value = Math.Abs(number);

            if (value != 0 && value <= maxValue)
            {
                fibonacci = FibonacciSequence(number)[value];
            }

            return fibonacci;
        }

        public static double Fibonacci(double number)
        {
            // Maximum and minimum result value for +/-maxValue is:
            //  +/-1.3069892237634E+308

            // Maximum value for reliable result.
            const int maxValue = FibonacciMaxDouble;

            double fibonacci = 0;
            int value = Math.Abs((int)Math.Floor(number));

            if (value != 0 && value <= maxValue)
            {
                fibonacci = FibonacciSequence(number)[value];
            }

            return fibonacci;
        }

        public static decimal[] FibonacciSequence(int number)
        {
            // Maximum and minimum result value for +/-maxValue is:
            //  +/-50095301248058391139327916261

            // Maximum value for reliable result.
            const int maxValue = FibonacciMaxDecimal;

            int values = Math.Abs(number);
            if (values > maxValue)
            {
                values = 0;
            }
            // Always enable element zero.
            int elements = 1 + values;

            // Create empty sequence with element zero filled.
            decimal[] fibonacciSequence = new decimal[elements];
            if (values > 0 )
            {
                for (int i = 1; i < elements; i++)
                {
                    if (i == 1)
                    // Fill element one signed per definition.
                    {
                        fibonacciSequence[i] = Math.Sign(number);
                    }
                    else
                    // Fill remaining elements by calculation.
                    {
                        fibonacciSequence[i] = fibonacciSequence[i - 1] + fibonacciSequence[i - 2];
                    }
                }
            }

            return fibonacciSequence;
        }

        public static double[] FibonacciSequence(double number)
        {
            // Maximum and minimum result value for +/-maxValue is:
            //  +/-1.3069892237634E+308

            // Maximum value for reliable result.
            const int maxValue = FibonacciMaxDouble;

            int values = Math.Abs((int)Math.Floor(number));
            if (values > maxValue)
            {
                values = 0;
            }
            // Always enable element zero.
            int elements = 1 + values;

            // Create empty sequence with element zero filled.
            double[] fibonacciSequence = new double[elements];
            if (values > 0)
            {
                for (int i = 1; i < elements; i++)
                {
                    if (i == 1)
                    // Fill element one signed per definition.
                    {
                        fibonacciSequence[i] = Math.Sign(number);
                    }
                    else
                    // Fill remaining elements by calculation.
                    {
                        fibonacciSequence[i] = fibonacciSequence[i - 1] + fibonacciSequence[i - 2];
                    }
                }
            }

            return fibonacciSequence;
        }

    }


}

