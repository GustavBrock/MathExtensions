using System;
using System.Globalization;

namespace SystemExt
{

    /// <summary>
    /// Provides constants and methods for rounding, generating mathematical sequences, and to retrieve single values from these.
    /// </summary>
    public static partial class MathExt
    {
        public static decimal Fraction(decimal value)
        {
            return value - Math.Truncate(value);
        }

        public static double Fraction(double value)
        {
            return value - Math.Truncate(value);
        }

        public static decimal Integer(decimal value)
        {
            return Math.Truncate(value);
        }

        public static double Integer(double value)
        {
            return Math.Truncate(value);
        }

        public static string Mantissa(decimal value)
        {
            decimal fraction = Fraction(value);
            return FractionToString(fraction);
        }

        public static string Mantissa(double value)
        {
            decimal fraction = (decimal)Fraction(value);
            return FractionToString(fraction);
        }

        private static string FractionToString(decimal fraction)
        {
            string mantissa = String.Empty;

            if (fraction != 0)
            {
                // Build format string like "0.#####" that will strip trailing zeroes.
                string header = "0.";
                char nonZero = '#';
                string format = header + new String(nonZero, MaxDigitsDecimal);
                // Create formatted fraction like "0.1234" and strip header.
                IFormatProvider provider = CultureInfo.InvariantCulture.NumberFormat;
                mantissa = fraction.ToString(format, provider).Substring(header.Length);
            }

            return mantissa;
        }
    }
}