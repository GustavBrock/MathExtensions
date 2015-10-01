namespace SystemExt
{
    #region Enums

    public enum UpRounding
    {
        Up,
        AwayFromZero
    }

    public enum DownRounding
    {
        Down,
        ToZero
    }

    #endregion

    /// <summary>
    /// Provides constants and methods for rounding, generating mathematical sequences, and to retrieve single values from these.
    /// </summary>
    public static partial class MathExt
    {
        #region Constants

        /// <summary>
        /// Represents the base number for calculating scale when rounding to significant numbers.
        /// </summary>
        public const double Base10 = 10;

        /// <summary>
        /// Represents the maximum possible number of decimals to round a decimal value to.
        /// </summary>
        public const int MaxDigitsDecimal = 28;

        /// <summary>
        /// Represents the maximum possible number of decimals figures to round a double value to.
        /// </summary>
        public const int MaxDigitsDouble = 15;

        /// <summary> 
        /// Represents the maximum possible number of significant figures to round a decimal value to. 
        /// </summary> 
        public const int MaxSignificantDigitsDecimal = MaxDigitsDecimal+1; 
 
        /// <summary> 
        /// Represents the maximum possible number of significant figures to round a double value to. 
        /// </summary> 
        public const int MaxSignificantDigitsDouble = MaxDigitsDouble+1; 
 
        #endregion
    }
}