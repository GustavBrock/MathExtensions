using System;

namespace SystemExt
{

    /// <summary>
    /// Provides constants and methods for rounding, generating mathematical sequences, and to retrieve single values from these.
    /// </summary>
    public static partial class MathExt
    {

        #region RoundUp

        /// <summary>
        /// Rounds value up with zero decimals.
        /// </summary>
        /// <param name="value">Value to be rounded up.</param>
        /// <returns>Value rounded up.</returns>
        public static decimal RoundUp(decimal value)
        {
            int digits = 0;
            UpRounding mode = UpRounding.Up;
            return RoundUp(value, digits, mode);
        }

        /// <summary>
        /// Rounds value up with zero decimals.
        /// </summary>
        /// <param name="value">Value to be rounded up.</param>
        /// <returns>Value rounded up.</returns>
        public static double RoundUp(double value)
        {
            int digits = 0;
            UpRounding mode = UpRounding.Up;
            return RoundUp(value, digits, mode);
        }

        /// <summary>
        /// Rounds value up with the count of decimals as specified with parameter digits.
        /// If digits is negative, value is rounded to tens, hundreds, etc.
        /// </summary>
        /// <param name="value">Value to be rounded up.</param>
        /// <param name="digits">Count of decimals. A negative count is allowed.</param>
        /// <returns>Value rounded up.</returns>
        public static decimal RoundUp(decimal value, int digits)
        {
            UpRounding mode = UpRounding.Up;
            return RoundUp(value, digits, mode);
        }

        /// <summary>
        /// Rounds value up with the count of decimals as specified with parameter digits.
        /// If digits is negative, value is rounded to tens, hundreds, etc.
        /// </summary>
        /// <param name="value">Value to be rounded up.</param>
        /// <param name="digits">Count of decimals. A negative count is allowed.</param>
        /// <returns>Value rounded up.</returns>
        public static double RoundUp(double value, int digits)
        {
            UpRounding mode = UpRounding.Up;
            return RoundUp(value, digits, mode);
        }

        /// <summary>
        /// Rounds value up with zero decimals.
        /// <para>Optionally, also rounds negative values away from zero.</para>
        /// </summary>
        /// <param name="value">Value to be rounded up.</param>
        /// <param name="mode">Sets rounding mode for negative values.</param>
        /// <returns>Value rounded up.</returns>
        public static decimal RoundUp(decimal value, UpRounding mode)
        {
            int digits = 0;
            return RoundUp(value, digits, mode);
        }

        /// <summary>
        /// Rounds value up with zero decimals.
        /// <para>Optionally, also rounds negative values away from zero.</para>
        /// </summary>
        /// <param name="value">Value to be rounded up.</param>
        /// <param name="mode">Sets rounding mode for negative values.</param>
        /// <returns>Value rounded up.</returns>
        public static double RoundUp(double value, UpRounding mode)
        {
            int digits = 0;
            return RoundUp(value, digits, mode);
        }

        /// <summary>
        /// Rounds value up with the count of decimals as specified with parameter digits.
        /// If digits is negative, value is rounded to tens, hundreds, etc.
        /// <para>Optionally, also rounds negative values away from zero.</para>
        /// </summary>
        /// <param name="value">Value to be rounded up.</param>
        /// <param name="digits">Count of decimals. A negative count is allowed.</param>
        /// <param name="mode">Sets rounding mode for negative values.</param>
        /// <returns>Value rounded up.</returns>
        public static decimal RoundUp(decimal value, int digits, UpRounding mode)
        {
            decimal scaling = 0;
            decimal returnValue = 0;

            // Only round if result can be different from zero.
            if (value != 0)
            {
                if (digits !=0 && digits <= MaxSignificantDigitsDecimal)
                {
                    // Calculate scaling factor.
                    scaling = (decimal)Math.Pow(Base10, digits);
                }
                else 
                {
                    // Integer rounding.
                    scaling = 1;
                }

                if (scaling == 0)
                    // The requested number of decimals will cause no rounding, 
                    // or a very large value for digits has minimized scaling.
                    // Return value as is.
                    returnValue = value;
                else if (mode == UpRounding.Up || value > 0)
                {
                    // Round numeric value up.
                    if (scaling==1 )
                    {
                        // Integer rounding.
                        returnValue = Math.Ceiling(value);
                    }
                    else
                    {
                        try
                        {
                            // Round value as a decimal.
                            returnValue = Math.Ceiling(value * scaling) / scaling;
                        }
                        catch 
                        {
                            try
                            {
                                // Round value as a double.
                                returnValue = (decimal)(Math.Ceiling((double)value * (double)scaling) / (double)scaling);
                            }
                            catch 
                            {
                                // Return value as is.
                                returnValue = value;
                            }
                        }
                    }
                }
                else
                {
                    // Round absolute value up.
                    if (scaling == 1)
                    {
                        // Integer rounding.
                        returnValue = Math.Floor(value);
                    }
                    else
                    {
                        try
                        {
                            // Round value as a decimal.
                            returnValue = Math.Floor(value * scaling) / scaling;
                        }
                        catch 
                        {
                            try
                            {
                                // Round value as a double.
                                returnValue = (decimal)(Math.Floor((double)value * (double)scaling) / (double)scaling);
                            }
                            catch 
                            {
                                // Return value as is.
                                returnValue = value;
                            }
                        }
                    }
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Rounds value up with the count of decimals as specified with parameter digits.
        /// If digits is negative, value is rounded to tens, hundreds, etc.
        /// <para>Optionally, also rounds negative values away from zero.</para>
        /// </summary>
        /// <param name="value">Value to be rounded up.</param>
        /// <param name="digits">Count of decimals. A negative count is allowed.</param>
        /// <param name="mode">Sets rounding mode for negative values.</param>
        /// <returns>Value rounded up.</returns>
        public static double RoundUp(double value, int digits, UpRounding mode)
        {
            double scaling = 0;
            double returnValue = 0;

            // Only round if result can be different from zero.
            if (value != 0)
            {
                if (digits != 0 && digits <= MaxSignificantDigitsDouble)
                {
                    // Calculate scaling factor.
                    scaling = Math.Pow(Base10, digits);
                }
                else
                {
                    // Integer rounding.
                    scaling = 1;
                }

                if (scaling == 0)
                    // The requested number of decimals will cause no rounding, 
                    // or a very large value for digits has minimized scaling.
                    // Return value as is.
                    returnValue = value;
                else if (mode == UpRounding.Up || value > 0)
                {
                    // Round numeric value up.
                    if (scaling == 1)
                    {
                        // Integer rounding.
                        returnValue = Math.Ceiling(value);
                    }
                    else
                    {
                        try
                        {
                            // Round value as a decimal.
                            returnValue = (double)RoundUp((decimal)(value), digits, mode);
                        }
                        catch
                        {
                            try
                            {
                                // Round value as a double.
                                returnValue = Math.Ceiling(value * scaling) / scaling;
                            }
                            catch
                            {
                                // Return value as is.
                                returnValue = value;
                            }
                        }
                    }
                }
                else
                {
                    // Round absolute value up.
                    if (scaling == 1)
                    {
                        // Integer rounding.
                        returnValue = Math.Floor(value);
                    }
                    else
                    {
                        try
                        {
                            // Round value as a decimal.
                            returnValue = (double)(Math.Floor((decimal)value * (decimal)scaling) / (decimal)scaling);
                        }
                        catch
                        {
                            try
                            {
                                // Round value as a double.
                                returnValue = Math.Floor(value * scaling) / scaling;
                            }
                            catch
                            {
                                // Return value as is.
                                returnValue = value;
                            }
                        }
                    }
                }
            }

            return returnValue;
        }

        #endregion

    }
}