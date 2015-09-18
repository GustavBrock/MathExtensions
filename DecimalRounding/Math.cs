namespace System
{

    public static class MathExt
    {
        // Maximum value of Factorial number before overflow.
        public const decimal FactorialMaxDecimal = 27m;
        public const double FactorialMaxDouble = 170d;

        // Maximum length of Fibonacci sequences before overflow.
        public const int FibonacciMaxDecimal = 139;
        public const int FibonacciMaxDouble = 1476;

        public static double Factorial(double number)
        {
            // Result value for FactorialMaxDouble is:
            //  7.25741561530799E+306
            // Maximum count of significant figures for any value is 14.

            // Minimum result per definition.
            const double minResult = 1;
            // Error result for out-of-range values.
            const double errResult = 0;

            double factorial = number;

            if (number < 0 || number > FactorialMaxDouble)
            {
                // Return value of error.
                factorial = errResult;
            }
            else
            {
                if (number > minResult)
                {
                    // Calculate result by recursion.
                    factorial *= Factorial(--number);
                }
                else
                {
                    factorial = minResult;
                }
            }
            return factorial;
        }

        public static decimal Factorial(decimal number)
        {
            // Result value for FactorialMaxDecimal is:
            //  10888869450418352160768000000

            // Minimum result per definition.
            const decimal minResult = 1m;
            // Error result for out-of-range values.
            const decimal errResult = 0m;

            decimal factorial = number;

            if (number < 0 || number > FactorialMaxDecimal)
            {
                // Return value of error.
                factorial = errResult;
            }
            else
            {
                if (number > minResult)
                {
                    // Calculate result by recursion.
                    factorial *= Factorial(--number);
                }
                else
                {
                    factorial = minResult;
                }
            }
            return factorial;
        }

        public static decimal[] FactorialSequence(int values)
        {
            // Result value for FactorialMaxDecimal is:
            //  10888869450418352160768000000

            // Minimum result per definition.
            const decimal minResult = 1m;
            // Error result for out-of-range values.
            const decimal errResult = 0m;

            int numbers = values;

            if (numbers < 0 || numbers > FactorialMaxDecimal)
            {
                numbers = 0;
            }
            // Always enable element zero.
            int elements = 1 + numbers;

            decimal[] factorialSequence = new decimal[elements];
            factorialSequence[0] = minResult;

            if (numbers > 0)
            {
                for (int i = 1; i < elements; i++)
                {
                    if (i == 1)
                    // Fill element one per definition.
                    {
                        factorialSequence[i] = minResult;
                    }
                    else
                    // Fill remaining elements by calculation.
                    {
                        factorialSequence[i] = i * factorialSequence[i - 1];
                    }
                }
            }
            return factorialSequence;
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

