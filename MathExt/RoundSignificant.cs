using System;

namespace SystemExt
{

    /// <summary>
    /// Provides constants and methods for rounding, generating mathematical sequences, and single values from these.
    /// </summary>
    public static partial class MathExt
    {
        #region Constants

        /// <summary>
        /// Represents the maximum possible number of significant figures to round a decimal value to.
        /// </summary>
        public const int MaxSignificantDigitsDecimal = 29;

        /// <summary>
        /// Represents the maximum possible number of significant figures to round a double value to.
        /// </summary>
        public const int MaxSignificantDigitsDouble = 16;

        /// <summary>
        /// Represents the base number for calculating scale when rounding to significant numbers.
        /// </summary>
        private const double _base10 = 10;
        
        #endregion

        #region RoundSignificant

        public static decimal RoundSignificant(decimal value, int significantDigits)
        {
            bool integer = false;
            MidpointRounding mode = MidpointRounding.AwayFromZero;
            return RoundSignificant(value, significantDigits, integer, mode);
        }

        public static double RoundSignificant(double value, int significantDigits)
        {
            bool integer = false;
            MidpointRounding mode = MidpointRounding.AwayFromZero;
            return RoundSignificant(value, significantDigits, integer, mode);
        }

        public static decimal RoundSignificant(decimal value, int significantDigits, bool integer)
        {
            MidpointRounding mode = MidpointRounding.AwayFromZero;
            return RoundSignificant(value, significantDigits, integer, mode);
        }

        public static double RoundSignificant(double value, int significantDigits, bool integer)
        {
            MidpointRounding mode = MidpointRounding.AwayFromZero;
            return RoundSignificant(value, significantDigits, integer, mode);
        }

        public static decimal RoundSignificant(decimal value, int significantDigits, MidpointRounding mode)
        {
            bool integer = false;
            return RoundSignificant(value, significantDigits, integer, mode);
        }

        public static double RoundSignificant(double value, int significantDigits, MidpointRounding mode)
        {
            bool integer = false;
            return RoundSignificant(value, significantDigits, integer, mode);
        }

        public static decimal RoundSignificant(decimal value, int significantDigits, bool integer, MidpointRounding mode)
        {
            double exponent = 0;
            decimal scaling = 0;
            decimal half = 0;
            decimal scaledValue = 0;
            decimal returnValue = 0;

            // Only round if result can be different from zero.
            if (value != 0 && significantDigits > 0)
            {
                if (significantDigits <= MaxSignificantDigitsDecimal)
                {
                    // Calculate scaling factor.
                    exponent = Math.Floor(Math.Log10((double)Math.Abs(value))) + 1 - significantDigits;
                    if (integer == true && exponent < 0)
                    {
                        // No decimals.
                        exponent = 0;
                    }
                    scaling = (decimal)Math.Pow(_base10, exponent);
                }

                if (scaling == 0)
                    // The requested number of significant figures exceeds the capability of decimal, 
                    // or a very large value for significantDigits has minimized scaling.
                    // Return value as is.
                    returnValue = value;
                else
                {
                    // Very large values for significantDigits and numeric very large values 
                    // can cause an out-of-range error when dividing or rounding away from zero.                    
                    try
                    {
                        scaledValue = value / scaling;

                        // Perform rounding.
                        if (mode == MidpointRounding.AwayFromZero)
                        {
                            half = Math.Sign(value) / 2m;
                            returnValue = Math.Truncate(scaledValue + half) * scaling;
                        }
                        else
                        {
                            returnValue = Math.Round(scaledValue, MidpointRounding.ToEven) * scaling;
                        }
                    }
                    catch
                    {
                        // Don't throw an ArgumentOutOfRangeException.
                        // Return value as is.
                        returnValue = value;
                    }
                }
            }

            return returnValue;
        }

        public static double RoundSignificant(double value, int significantDigits, bool integer, MidpointRounding mode)
        {
            double exponent = 0;
            double scaling = 0;
            double half = 0;
            double scaledValue = 0;
            double returnValue = 0;

            // Only round if result can be different from zero.
            if (value != 0 && significantDigits > 0)
            {
                if (significantDigits <= MaxSignificantDigitsDouble)
                {
                    // Calculate scaling factor.
                    exponent = Math.Floor(Math.Log10(Math.Abs(value))) + 1 - significantDigits;
                    if (integer == true && exponent < 0)
                    {
                        // No decimals.
                        exponent = 0;
                    }
                    scaling = Math.Pow(_base10, exponent);
                }

                if (scaling == 0)
                    // The requested number of significant figures exceeds the capability of double, 
                    // or a very large value for significantDigits has minimized scaling.
                    // Return value as is.
                    returnValue = value;
                else
                {
                    // Very large values for significantDigits and numeric very large values 
                    // can cause an out-of-range error when dividing or rounding away from zero.                    
                    try
                    {
                        scaledValue = value / scaling;

                        // Perform rounding.
                        if (mode == MidpointRounding.AwayFromZero)
                        {
                            half = Math.Sign(value) / 2;
                            returnValue = Math.Truncate(scaledValue + half) * scaling;
                        }
                        else
                        {
                            returnValue = Math.Round(scaledValue, MidpointRounding.ToEven) * scaling;
                        }
                    }
                    catch
                    {
                        // Don't throw an ArgumentOutOfRangeException.
                        // Return value as is.
                        returnValue = value;
                    }
                }
            }

            return returnValue;
        }

        #endregion
    }

}