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
                if (digits !=0 && digits <= MaxDigitsDecimal)
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
                if (digits != 0 && digits <= MaxDigitsDouble)
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

        #region RoundDown

        /// <summary>
        /// Rounds value down with zero decimals.
        /// </summary>
        /// <param name="value">Value to be rounded down.</param>
        /// <returns>Value rounded down.</returns>
        public static decimal RoundDown(decimal value)
        {
            int digits = 0;
            DownRounding mode = DownRounding.Down;
            return RoundDown(value, digits, mode);
        }

        /// <summary>
        /// Rounds value down with zero decimals.
        /// </summary>
        /// <param name="value">Value to be rounded down.</param>
        /// <returns>Value rounded down.</returns>
        public static double RoundDown(double value)
        {
            int digits = 0;
            DownRounding mode = DownRounding.Down;
            return RoundDown(value, digits, mode);
        }

        /// <summary>
        /// Rounds value down with the count of decimals as specified with parameter digits.
        /// If digits is negative, value is rounded to tens, hundreds, etc.
        /// </summary>
        /// <param name="value">Value to be rounded down.</param>
        /// <param name="digits">Count of decimals. A negative count is allowed.</param>
        /// <returns>Value rounded down.</returns>
        public static decimal RoundDown(decimal value, int digits)
        {
            DownRounding mode = DownRounding.Down;
            return RoundDown(value, digits, mode);
        }

        /// <summary>
        /// Rounds value down with the count of decimals as specified with parameter digits.
        /// If digits is negative, value is rounded to tens, hundreds, etc.
        /// </summary>
        /// <param name="value">Value to be rounded down.</param>
        /// <param name="digits">Count of decimals. A negative count is allowed.</param>
        /// <returns>Value rounded down.</returns>
        public static double RoundDown(double value, int digits)
        {
            DownRounding mode = DownRounding.Down;
            return RoundDown(value, digits, mode);
        }

        /// <summary>
        /// Rounds value down with zero decimals.
        /// <para>Optionally, also rounds negative values to zero.</para>
        /// </summary>
        /// <param name="value">Value to be rounded down.</param>
        /// <param name="mode">Sets rounding mode for negative values.</param>
        /// <returns>Value rounded down.</returns>
        public static decimal RoundDown(decimal value, DownRounding mode)
        {
            int digits = 0;
            return RoundDown(value, digits, mode);
        }

        /// <summary>
        /// Rounds value down with zero decimals.
        /// <para>Optionally, also rounds negative values to zero.</para>
        /// </summary>
        /// <param name="value">Value to be rounded down.</param>
        /// <param name="mode">Sets rounding mode for negative values.</param>
        /// <returns>Value rounded down.</returns>
        public static double RoundDown(double value, DownRounding mode)
        {
            int digits = 0;
            return RoundDown(value, digits, mode);
        }

        /// <summary>
        /// Rounds value down with the count of decimals as specified with parameter digits.
        /// If digits is negative, value is rounded to tens, hundreds, etc.
        /// <para>Optionally, also rounds negative values to zero.</para>
        /// </summary>
        /// <param name="value">Value to be rounded down.</param>
        /// <param name="digits">Count of decimals. A negative count is allowed.</param>
        /// <param name="mode">Sets rounding mode for negative values.</param>
        /// <returns>Value rounded down.</returns>
        public static decimal RoundDown(decimal value, int digits, DownRounding mode)
        {
            decimal scaling = 0;
            decimal returnValue = 0;

            // Only round if result can be different from zero.
            if (value != 0)
            {
                if (digits != 0 && digits <= MaxDigitsDecimal)
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
                else if (mode == DownRounding.Down || value > 0)
                {
                    // Round numeric value down.
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
                else
                {
                    // Round absolute value down.
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
            }

            return returnValue;
        }

        /// <summary>
        /// Rounds value down with the count of decimals as specified with parameter digits.
        /// If digits is negative, value is rounded to tens, hundreds, etc.
        /// <para>Optionally, also rounds negative values to zero.</para>
        /// </summary>
        /// <param name="value">Value to be rounded down.</param>
        /// <param name="digits">Count of decimals. A negative count is allowed.</param>
        /// <param name="mode">Sets rounding mode for negative values.</param>
        /// <returns>Value rounded down.</returns>
        public static double RoundDown(double value, int digits, DownRounding mode)
        {
            double scaling = 0;
            double returnValue = 0;

            // Only round if result can be different from zero.
            if (value != 0)
            {
                if (digits != 0 && digits <= MaxDigitsDouble)
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
                else if (mode == DownRounding.Down || value > 0)
                {
                    // Round numeric value down.
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
                            returnValue = (double)RoundDown((decimal)(value), digits, mode);
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
                else
                {
                    // Round absolute value down.
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
                            returnValue = (double)(Math.Ceiling((decimal)value * (decimal)scaling) / (decimal)scaling);
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
            }

            return returnValue;
        }

        #endregion

        #region RoundMid

        /// <summary>
        /// Rounds value by 4/5 to an integer.
        /// </summary>
        /// <param name="value">Value to be rounded.</param>
        /// <returns>Value rounded by 4/5.</returns>
        public static decimal RoundMid(decimal value)
        {
            int digits = 0;
            MidpointRounding mode = MidpointRounding.AwayFromZero;
            return RoundMid(value, digits, mode);
        }

        /// <summary>
        /// Rounds value by 4/5 to an integer.
        /// </summary>
        /// <param name="value">Value to be rounded.</param>
        /// <returns>Value rounded by 4/5.</returns>
        public static double RoundMid(double value)
        {
            int digits = 0;
            MidpointRounding mode = MidpointRounding.AwayFromZero;
            return RoundMid(value, digits, mode);
        }

        /// <summary>
        /// Rounds value by 4/5 with the count of decimals as specified with parameter digits.
        /// If digits is negative, value is rounded to tens, hundreds, etc.
        /// </summary>
        /// <param name="value">Value to be rounded.</param>
        /// <param name="digits">Count of decimals. A negative count is allowed.</param>
        /// <returns>Value rounded by 4/5.</returns>
        public static decimal RoundMid(decimal value, int digits)
        {
            MidpointRounding mode = MidpointRounding.AwayFromZero;
            return RoundMid(value, digits, mode);
        }

        /// <summary>
        /// Rounds value by 4/5 with the count of decimals as specified with parameter digits.
        /// If digits is negative, value is rounded to tens, hundreds, etc.
        /// </summary>
        /// <param name="value">Value to be rounded.</param>
        /// <param name="digits">Count of decimals. A negative count is allowed.</param>
        /// <returns>Value rounded by 4/5.</returns>
        public static double RoundMid(double value, int digits)
        {
            MidpointRounding mode = MidpointRounding.AwayFromZero;
            return RoundMid(value, digits, mode);
        }

        /// <summary>
        /// Rounds value by 4/5 to an integer.
        /// <para>Optionally, performs Banker's Rounding.</para>
        /// </summary>
        /// <param name="value">Value to be rounded.</param>
        /// <param name="mode">Sets rounding mode.</param>
        /// <returns>Value rounded by 4/5.</returns>
        public static decimal RoundMid(decimal value, MidpointRounding mode)
        {
            int digits = 0;
            return RoundMid(value, digits, mode);
        }

        /// <summary>
        /// Rounds value by 4/5 to an integer.
        /// <para>Optionally, performs Banker's Rounding.</para>
        /// </summary>
        /// <param name="value">Value to be rounded.</param>
        /// <param name="mode">Sets rounding mode.</param>
        /// <returns>Value rounded by 4/5.</returns>
        public static double RoundMid(double value, MidpointRounding mode)
        {
            int digits = 0;
            return RoundMid(value, digits, mode);
        }

        /// <summary>
        /// Rounds value by 4/5 with the count of decimals as specified with parameter digits.
        /// If digits is negative, value is rounded to tens, hundreds, etc.
        /// <para>Optionally, performs Banker's Rounding.</para>
        /// </summary>
        /// <param name="value">Value to be rounded.</param>
        /// <param name="digits">Count of decimals. A negative count is allowed.</param>
        /// <param name="mode">Sets rounding mode.</param>
        /// <returns>Value rounded by 4/5.</returns>
        public static decimal RoundMid(decimal value, int digits, MidpointRounding mode)
        {
            decimal scaling = 0;
            decimal returnValue = 0;

            // Only round if result can be different from zero.
            if (value != 0)
            {
                if (digits != 0 && digits <= MaxDigitsDecimal)
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
                else if (mode == MidpointRounding.ToEven)
                {
                    // Perform Banker's Rounding using the default rounding mode of Round.
                    {
                        try
                        {
                            // Round value as a decimal.
                            returnValue = Math.Round(value * scaling) / scaling;
                        }
                        catch
                        {
                            try
                            {
                                // Round value as a double.
                                returnValue = (decimal)(Math.Round((double)value * (double)scaling) / (double)scaling);
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
                    // Perform basic 4/5 rounding.
                    {
                        decimal half = (decimal)Math.Sign(value) / 2;
                        try
                        {
                            // Round value as a decimal.
                            returnValue = Math.Truncate(value * scaling + half) / scaling;
                        }
                        catch
                        {
                            try
                            {
                                // Round value as a double.
                                returnValue = (decimal)(Math.Truncate((double)value * (double)scaling + (double)half) / (double)scaling);
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
        /// Rounds value by 4/5 with the count of decimals as specified with parameter digits.
        /// If digits is negative, value is rounded to tens, hundreds, etc.
        /// <para>Optionally, performs Banker's Rounding.</para>
        /// </summary>
        /// <param name="value">Value to be rounded.</param>
        /// <param name="digits">Count of decimals. A negative count is allowed.</param>
        /// <param name="mode">Sets rounding mode.</param>
        /// <returns>Value rounded by 4/5.</returns>
        public static double RoundMid(double value, int digits, MidpointRounding mode)
        {
            double scaling = 0;
            double returnValue = 0;

            // Only round if result can be different from zero.
            if (value != 0)
            {
                if (digits != 0 && digits <= MaxDigitsDouble)
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
                else if (mode == MidpointRounding.ToEven)
                {
                    // Perform Banker's Rounding using the default rounding mode of Round.
                    {
                        try
                        {
                            // Round value as a decimal.
                            //                            returnValue = (double)Math.Round((decimal)(value), digits, mode);
                            returnValue = (double)(Math.Round((decimal)(value) * (decimal)scaling, mode) / (decimal)scaling);
                        }
                        catch
                        {
                            try
                            {
                                // Round value as a double.
                                returnValue = Math.Round(value * scaling) / scaling;
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
                    // Perform basic 4/5 rounding.
                    {
                        double half = (double)Math.Sign(value) / 2;
                        try
                        {
                            // Round value as a decimal.
                            returnValue = (double)(Math.Truncate((decimal)value * (decimal)scaling + (decimal)half) / (decimal)scaling);
                        }
                        catch
                        {
                            try
                            {
                                // Round value as a double.
                                returnValue = Math.Truncate(value * scaling + half) / scaling;
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