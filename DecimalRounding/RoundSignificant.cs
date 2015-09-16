using System;

namespace DecimalExtensions
{

    public static class RoundingMethods
    {
        public static decimal RoundToSignificantDigits(this Decimal inputValue, int significantDigits)
        {
            bool integer = false;
            MidpointRounding mode = MidpointRounding.AwayFromZero;
            return RoundingSignificant(inputValue, significantDigits, integer, mode);
        }

        public static decimal RoundToSignificantDigits(this Decimal inputValue, int significantDigits, bool integer)
        {
            MidpointRounding mode = MidpointRounding.AwayFromZero;
            return RoundingSignificant(inputValue, significantDigits, integer, mode);
        }

        public static decimal RoundToSignificantDigits(this Decimal inputValue, int significantDigits, MidpointRounding mode)
        {
            bool integer = false;
            return RoundingSignificant(inputValue, significantDigits, integer, mode);
        }

        public static decimal RoundToSignificantDigits(this Decimal inputValue, int significantDigits, bool integer, MidpointRounding mode)
        {
            return RoundingSignificant(inputValue, significantDigits, integer, mode);
        }

        private static decimal RoundingSignificant(decimal inputValue, int significantDigits, bool integer, MidpointRounding mode)
        {
            const double base10 = 10;
            double exponent = 0;
            decimal scaling = 0;
            decimal half = 0;
            decimal scaledValue = 0;
            decimal returnValue = 0;

            // Only round if result can be different from zero.
            if (inputValue != 0 && significantDigits>0)
            {
                // Calculate scaling factor.
                exponent = System.Math.Floor(System.Math.Log10((double)System.Math.Abs(inputValue))) + 1 - significantDigits;
                if (integer == true && exponent < 0)
                {
                    // No decimals.
                    exponent = 0;
                }
                scaling = (decimal)System.Math.Pow(base10, exponent);

                if (scaling == 0)
                    // A very large value for significantDigits has minimized scaling.
                    // Return value as is.
                    returnValue = inputValue;
                else
                {
                    // Very large values for significantDigits can cause an out-of-range error when dividing.
                    try
                    {
                        scaledValue = inputValue / scaling;
                    }
                    catch 
                    {
                        // Don't throw an ArgumentOutOfRangeException.
                        // Return value as is.
                        returnValue = inputValue;
                    }

                    // Perform rounding.
                    if (mode == MidpointRounding.AwayFromZero)
                    {
                        half = System.Math.Sign(inputValue) / 2m;
                        returnValue = System.Math.Truncate(scaledValue + half) * scaling;
                    }
                    else
                    {
                        returnValue = System.Math.Round(scaledValue, MidpointRounding.ToEven) * scaling;
                    }
                }
            }
            return returnValue;
        }
        
    }

}