namespace System
{

    public static class MathExt
    {
        // Maximum length of Fibonacci sequences before overflow.
        public const int FibonacciMaxDecimal = 139;
        public const int FibonacciMaxDouble = 1476;

        public static double Factorial(double value)
        {
            // Maximum value for reliable result.
            const double maxValue = 170;
            // Minimum result per definition.
            const double minResult = 1;
            // Error result for out-of-range values.
            const double errResult = 0;

            if (value > maxValue)
            {
                // Return value of error.
                value = errResult;
            }
            else
            {
                if (value > minResult)
                {
                    // Calculate result by recursion.
                    value *= Factorial(--value);
                }
                else
                {
                    value = minResult;
                }
            }
            return value;
        }

        public static decimal Fibonacci(int value)
        {
            // Maximum and minimum result value for +/-maxValue is:
            //  +/-50095301248058391139327916261

            // Maximum value for reliable result.
            const int maxValue = FibonacciMaxDecimal;

            decimal fibonacci = 0;
            int number = Math.Abs(value);

            if (number != 0 && number <= maxValue)
            {
                fibonacci = FibonacciSequence(value)[number];
            }
            return fibonacci;
        }

        public static double Fibonacci(double value)
        {
            // Maximum and minimum result value for +/-maxValue is:
            //  +/-1.3069892237634E+308

            // Maximum value for reliable result.
            const int maxValue = FibonacciMaxDouble;

            double fibonacci = 0;
            int number = Math.Abs((int)Math.Floor(value));

            if (number != 0 && number <= maxValue)
            {
                fibonacci = FibonacciSequence(value)[number];
            }
            return fibonacci;
        }

        public static decimal[] FibonacciSequence(int values)
        {
            // Maximum and minimum result value for +/-maxValue is:
            //  +/-50095301248058391139327916261

            // Maximum value for reliable result.
            const int maxValue = FibonacciMaxDecimal;

            int numbers = Math.Abs(values);
            if (numbers > maxValue)
            {
                numbers = 0;
            }
            // Always enable element zero.
            int elements = 1 + numbers;

            // Create empty sequence with element zero filled.
            decimal[] fibonacciSequence = new decimal[elements];
            if (numbers > 0 )
            {
                for (int i = 1; i < elements; i++)
                {
                    if (i == 1)
                    // Fill element one signed per definition.
                    {
                        fibonacciSequence[i] = Math.Sign(values);
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

        public static double[] FibonacciSequence(double values)
        {
            // Maximum and minimum result value for +/-maxValue is:
            //  +/-1.3069892237634E+308

            // Maximum value for reliable result.
            const int maxValue = FibonacciMaxDouble;

            int numbers = Math.Abs((int)Math.Floor(values));
            if (numbers > maxValue)
            {
                numbers = 0;
            }
            // Always enable element zero.
            int elements = 1 + numbers;

            // Create empty sequence with element zero filled.
            double[] fibonacciSequence = new double[elements];
            if (numbers > 0)
            {
                for (int i = 1; i < elements; i++)
                {
                    if (i == 1)
                    // Fill element one signed per definition.
                    {
                        fibonacciSequence[i] = Math.Sign(values);
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

