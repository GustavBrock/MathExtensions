using System;

namespace SystemExt
{

    /// <summary>
    /// Provides constants and methods for rounding, generating mathematical sequences, and to retrieve single values from these.
    /// </summary>
    public static partial class MathExt
    {
        #region Constants
        
        /// <summary>
        /// Represents the maximum possible decimal number to create the Factorial from before overflow.
        /// </summary>
        public const int MaxFactorialObjectsDecimal = 27;

        /// <summary>
        /// Represents the maximum possible double number to create the Factorial from before overflow.
        /// </summary>
        public const int MaxFactorialObjectsDouble = 170;

        /// <summary>
        /// Represents the minimum Factorial value.
        /// </summary>
        public const int MinFactorial = 1;

        /// <summary>
        /// Represents the maximum possible decimal number to create the Fibonacci number from before overflow.
        /// </summary>
        public const int MaxFibonacciObjectsDecimal = 139;

        /// <summary>
        /// Represents the maximum possible double number to create the Fibonacci number from before overflow.
        /// </summary>
        public const int MaxFibonacciObjectsDouble = 1476;

        #endregion

        #region Factorial

        /// <summary>
        /// Calculate the Factorial (n!) of an integer number between 0 and MaxFactorialObjectsDecimal.
        /// </summary>
        /// <param name="number">The integer number to calculate the Factorial of.</param>
        /// <returns>The Factorial of number as a Decimal, or 0 (zero) for an invalid number.</returns>
        public static decimal Factorial(int number)
        {
            // Result value for MaxFactorialObjectsDecimal is:
            //  10888869450418352160768000000

            // Error result for out-of-range values.
            const decimal errResult = 0;

            decimal factorial = errResult;

            if (number >= 0 && number <= MaxFactorialObjectsDecimal)
            {
                factorial = FactorialSequence(number)[number];
            }
            return factorial;
        }

        /// <summary>
        /// Calculate the Factorial (n!) of an integer number between 0 and MaxFactorialObjectsDouble
        /// <para>with a maximum count of 14 significant figures.</para>
        /// </summary>
        /// <param name="number">The integer number to calculate the Factorial of.</param>
        /// <returns>The Factorial of number as a Double, or 0 (zero) for an invalid number.</returns>
        public static double Factorial(double number)
        {
            // Result value for MaxFactorialObjectsDouble is:
            //  7.25741561530799E+306
            // Maximum count of significant figures for any value is 14.

            // Error result for out-of-range values.
            const double errResult = 0;

            double factorial = errResult;

            // Integer number only.
            number = Math.Truncate(number);
            if (number >= 0 && (int)number <= MaxFactorialObjectsDouble)
            {
                factorial = FactorialSequence(number)[(int)number];
            }
            return factorial;
        }

        /// <summary>
        /// Calculate the factorial sequence from zero to an integer number between 0 and MaxFactorialObjectsDecimal.
        /// </summary>
        /// <param name="number">The integer number to calculate the factorial sequence from.</param>
        /// <returns>An array of the factorial sequence as decimal values, or the single value for zero for an invalid number.</returns>
        public static decimal[] FactorialSequence(int number)
        {
            // Result value for MaxFactorialObjectsDecimal is:
            //  10888869450418352160768000000

            // Minimum result per definition.
            const decimal minResult = MinFactorial;

            if (number < 0 || number > MaxFactorialObjectsDecimal)
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

        /// <summary>
        /// Calculate the factorial sequence from zero to an integer number between 0 and MaxFactorialObjectsDouble.
        /// </summary>
        /// <param name="number">The integer number to calculate the factorial sequence from.</param>
        /// <returns>An array of the factorial sequence as double values, or the single value for zero for an invalid number.</returns>
        public static double[] FactorialSequence(double number)
        {
            // Result value for MaxFactorialObjectsDouble is:
            //  7.25741561530799E+306
            // Maximum count of significant figures for any value is 14.

            // Minimum result per definition.
            const double minResult = MinFactorial;

            // Integer number only.
            number = Math.Truncate(number);
            if (number < 0 || (int)number > MaxFactorialObjectsDouble)
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

        #endregion

        #region Fibonacci

        /// <summary>
        /// Calculate the Fibonacci number from an integer number between 0 and MaxFibonacciObjectsDecimal
        /// <para>or between 0 and -MaxFibonacciObjectsDecimal.</para>
        /// </summary>
        /// <param name="number">The integer number to calculate the Fibonacci number of.</param>
        /// <returns>The Fibonacci number of number as a Decimal, or 0 (zero) for an invalid number.</returns>
        public static decimal Fibonacci(int number)
        {
            // Maximum and minimum result value for +/-maxValue is:
            //  +/-50095301248058391139327916261

            // Maximum value for reliable result.
            const int maxValue = MaxFibonacciObjectsDecimal;

            decimal fibonacci = 0;
            int value = Math.Abs(number);

            if (value != 0 && value <= maxValue)
            {
                fibonacci = FibonacciSequence(number)[value];
            }

            return fibonacci;
        }

        /// <summary>
        /// Calculate the Fibonacci number from an integer number between 0 and MaxFibonacciObjectsDouble
        /// <para>or between 0 and -MaxFibonacciObjectsDouble.</para>
        /// </summary>
        /// <param name="number">The integer number to calculate the Fibonacci number of.</param>
        /// <returns>The Fibonacci number of number as a Double, or 0 (zero) for an invalid number.</returns>
        public static double Fibonacci(double number)
        {
            // Maximum and minimum result value for +/-maxValue is:
            //  +/-1.3069892237634E+308

            // Maximum value for reliable result.
            const int maxValue = MaxFibonacciObjectsDouble;

            double fibonacci = 0;
            int value = Math.Abs((int)Math.Floor(number));

            if (value != 0 && value <= maxValue)
            {
                fibonacci = FibonacciSequence(number)[value];
            }

            return fibonacci;
        }

        /// <summary>
        /// Calculate the Fibonacci number sequence from zero to an integer number between 0 and MaxFibonacciObjectsDecimal
        /// <para>or between 0 and -MaxFibonacciObjectsDecimal.</para>
        /// </summary>
        /// <param name="number">The integer number to calculate the Fibonacci number sequence from.</param>
        /// <returns>An array of the Fibonacci number sequence as decimal values, or the single value for zero for an invalid number.</returns>
        public static decimal[] FibonacciSequence(int number)
        {
            // Maximum and minimum result value for +/-maxValue is:
            //  +/-50095301248058391139327916261

            // Maximum value for reliable result.
            const int maxValue = MaxFibonacciObjectsDecimal;

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

        /// <summary>
        /// Calculate the Fibonacci number sequence from zero to an integer number between 0 and MaxFibonacciObjectsDouble
        /// <para>or between 0 and -MaxFibonacciObjectsDouble.</para>
        /// </summary>
        /// <param name="number">The integer number to calculate the Fibonacci number sequence from.</param>
        /// <returns>An array of the Fibonacci number sequence as double values, or the single value for zero for an invalid number.</returns>
        public static double[] FibonacciSequence(double number)
        {
            // Maximum and minimum result value for +/-maxValue is:
            //  +/-1.3069892237634E+308

            // Maximum value for reliable result.
            const int maxValue = MaxFibonacciObjectsDouble;

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

        #endregion
    }

}

