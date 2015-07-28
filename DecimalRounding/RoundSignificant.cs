using System;

namespace DecimalExtensions
{
    public static class RoundingMethods
    {
        public static decimal RoundToSignificantDigits(this decimal inputValue, byte significantDigits)
        {
            bool integer = false;
            return RoundingSignificant(inputValue, significantDigits, integer);
        }

        public static decimal RoundToSignificantDigits(this decimal inputValue, byte significantDigits, bool integer)
        {
            return RoundingSignificant(inputValue, significantDigits, integer);
        }

        private static decimal RoundingSignificant(decimal inputValue, byte significantDigits, bool integer)
        {
            const double base10 = 10;
            double exponent = 0;
            decimal scaling = 0;
            decimal half = 0;
            decimal scaledValue = 0;
            decimal returnValue = 0;

            if (significantDigits > 0 && inputValue != 0)
            {
                exponent = Math.Floor(Math.Log10((double)Math.Abs(inputValue))) + 1 - significantDigits;
                if (integer == true && exponent < 0)
                {
                    // No decimals.
                    exponent = 0;
                }
                scaling = (decimal)Math.Pow(base10, exponent);
                scaledValue = inputValue / scaling;
                half = Math.Sign(inputValue) / 2m;
                returnValue = Math.Truncate(scaledValue + half) * scaling;
            }
            return returnValue;
        }
        
    }
}