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

        #endregion
    }
}