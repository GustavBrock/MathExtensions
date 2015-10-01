using System;
using SystemExt;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathExtTest
{
    [TestClass]
    public class UnitTest
    {
        private double _test = 0;
        private double _expected = 0;
        private MidpointRounding _mode = MidpointRounding.AwayFromZero;

        /// <summary>
        /// A collection of tests for native Math.Round performing 4/5 rounding.
        /// <para>Those that will fail are commented out.</para>
        /// </summary>
        [TestMethod]
        public void TestRoundingNative()
        {
            // 0.
            _test = 0;
            _expected = 0;
            Assert.AreEqual(_expected, Math.Round(_test, _mode), "0");

            // Half-rounding.
            _test = 1.49999999999999d;
            _expected = 1d;
            Assert.AreEqual(_expected, Math.Round(_test, _mode), "Half-rounding 1");

            _test = 1.5d;
            _expected = 2d;
            Assert.AreEqual(_expected, Math.Round(_test, _mode), "Half-rounding 2");

            _test = 2.5d;
            _expected = 3d;
            Assert.AreEqual(_expected, Math.Round(_test, _mode), "Half-rounding 3");

            _test = 1.2345d;
            _expected = 1.235d;
            Assert.AreEqual(_expected, Math.Round(_test, 3, _mode), "Half-rounding 4");

            _test = -1.2345d;
            _expected = -1.235d;
            Assert.AreEqual(_expected, Math.Round(_test, 3, _mode), "Half-rounding 5");

            _test = 1.2355d;
            _expected = 1.236d;
            Assert.AreEqual(_expected, Math.Round(_test, 3, _mode), "Half-rounding 6");

            // Jeroen De Maeijer.
            _test = -0.0714285714d;
            _expected = -0.1d;
            Assert.AreEqual(_expected, Math.Round(_test, 1, _mode), "Jeroen De Maeijer");

            // Hallman.
            _test = 0.09d;
            _expected = 0.1d;
            Assert.AreEqual(_expected, Math.Round(_test, 1, _mode), "Hallman 1");

            _test = 0.0099d;
            _expected = 0d;
            Assert.AreEqual(_expected, Math.Round(_test, 1, _mode), "Hallman 2");

            _test = 0.0099d;
            _expected = 0.01d;
            Assert.AreEqual(_expected, Math.Round(_test, 2, _mode), "Hallman 3");

            _test = 0.0099d;
            _expected = 0.01d;
            Assert.AreEqual(_expected, Math.Round(_test, 3, _mode), "Hallman 4");

            _test = 0.0099d;
            _expected = 0.0099d;
            Assert.AreEqual(_expected, Math.Round(_test, 4, _mode), "Hallman 4");

            // Resolution.
            _test = 1.01234012340125d;
            _expected = 1.01234012340125d;
            Assert.AreEqual(_expected, Math.Round(_test, 14, _mode), "Resolution 1");

            _test = 1.01234012340125d;
            _expected = 1.0123401234013d;
            Assert.AreEqual(_expected, Math.Round(_test, 13, _mode), "Resolution 2");

            // Large numbers.
            _test = Math.Pow(10, 13) + 0.74d;
            _expected = 10000000000000.7d;
            Assert.AreEqual(_expected, Math.Round(_test, 1, _mode), "Large numbers 1");

            _test = Math.Pow(-10, 13) + 0.75d;
            _expected = -9999999999999.3d;
            Assert.AreEqual(_expected, Math.Round(_test, 1, _mode), "Large numbers 2");

            // No negative count of decimals for native Math.Round.
            _test = 1.11111111111111E+16;
            _expected = 1.1E+16;
            //Assert.AreEqual(_expected, Math.Round(_test, -15, _mode), "Large numbers 3");

            // Very large numbers.
            _test = Math.Pow(10, 307);
            _expected = 1e+307d;
            Assert.AreEqual(_expected, Math.Round(_test, _mode), "Very large numbers 1");

            _test = -Math.Pow(10, 308);
            _expected = -1e+308d;
            Assert.AreEqual(_expected, Math.Round(_test, _mode), "Very large numbers 2");

            // Double can only be rounded to 15 decimals.
            _test = 10.5d;
            _expected = 10.5d;
            Assert.AreEqual(_expected, (double)Math.Round((decimal)_test, 20, _mode), "Very large numbers 3");

            // No negative count of decimals for native Math.Round.
            _test = 10.5d;
            _expected = 0;
            //Assert.AreEqual(_expected, Math.Round(_test, -20, _mode), "Very large numbers 3");

            // Negative rounding.
            _test = -226.6d;
            _expected = -227d;
            Assert.AreEqual(_expected, Math.Round(_test, _mode), "Negative rounding 1");

            _test = -226.5d;
            _expected = -227d;
            Assert.AreEqual(_expected, Math.Round(_test, _mode), "Negative rounding 2");

            _test = -226.4d;
            _expected = -226d;
            Assert.AreEqual(_expected, Math.Round(_test, _mode), "Negative rounding 3");

            // No negative count of decimals for native Math.Round.
            // Rounding integers.
            _test = 226.7d;
            _expected = 230d;
            //Assert.AreEqual(_expected, Math.Round(_test, -1, _mode), "Rounding integers 1");

            _test = 226.7d;
            _expected = 200d;
            //Assert.AreEqual(_expected, Math.Round(_test, -2, _mode), "Rounding integers 2");

            _test = 226.7d;
            _expected = 0;
            //Assert.AreEqual(_expected, Math.Round(_test, -3, _mode), "Rounding integers 3");

            _test = 226.7d;
            _expected = 0;
            //Assert.AreEqual(_expected, Math.Round(_test, -4, _mode), "Rounding integers 4");

            // Nasty reals.
            // Will fail with result: 2.44
            _test = 2.445d;
            _expected = 2.45d;
            //Assert.AreEqual(_expected, Math.Round(_test, 2, _mode), "Nasty reals 1");

            // Will fail with result: -2.44
            _test = -2.445d;
            _expected = -2.45d;
            //Assert.AreEqual(_expected, Math.Round(_test, 2, _mode), "Nasty reals 2");

            _test = 3.445d;
            _expected = 3.45d;
            Assert.AreEqual(_expected, Math.Round(_test, 2, _mode), "Nasty reals 3");

            _test = -3.445d;
            _expected = -3.45d;
            Assert.AreEqual(_expected, Math.Round(_test, 2, _mode), "Nasty reals 4");

            _test = 100.05d;
            _expected = 100.1d;
            Assert.AreEqual(_expected, Math.Round(_test, 1, _mode), "Nasty reals 5");

            _test = -100.05d;
            _expected = -100.1d;
            Assert.AreEqual(_expected, Math.Round(_test, 1, _mode), "Nasty reals 6");

            _test = 30.675d;
            _expected = 30.68d;
            Assert.AreEqual(_expected, Math.Round(_test, 2, _mode), "Nasty reals 7");

            _test = 31.675d;
            _expected = 31.68d;
            Assert.AreEqual(_expected, Math.Round(_test, 2, _mode), "Nasty reals 8");

            // Will fail with result: 32.67
            _test = 32.675d;
            _expected = 32.68d;
            //Assert.AreEqual(_expected, Math.Round(_test, 2, _mode), "Nasty reals 9");

            // Will fail with result: 33.67
            _test = 33.675d;
            _expected = 33.68d;
            //Assert.AreEqual(_expected, Math.Round(_test, 2, _mode), "Nasty reals 10");

            // Will fail with result: 128.01
            _test = 128.015d;
            _expected = 128.02d;
            //Assert.AreEqual(_expected, Math.Round(_test, 2, _mode), "Nasty reals 11");

            // Will fail with result: 128.04
            _test = 128.045d;
            _expected = 128.05d;
            //Assert.AreEqual(_expected, Math.Round(_test, 2, _mode), "Nasty reals 12");

            // Twice the same value.
            _test = 1.01010101010101d;
            _expected = 1.01d;
            Assert.AreEqual(_expected, Math.Round(_test, 2, _mode), "Twice the same 1");

            _test = 1.01010101010101d;
            _expected = 1.01d;
            Assert.AreEqual(_expected, Math.Round(_test, 2, _mode), "Twice the same 2");
        }

        /// <summary>
        /// A collection of tests for MathExt.RoundMid performing 4/5 rounding.
        /// <para>Those that will fail are commented out.</para>
        /// </summary>
        [TestMethod]
        public void TestRoundingMid()
        {
            // 0.
            _test = 0;
            _expected = 0;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, _mode), "0");

            // Half-Rounding.
            _test = 1.49999999999999d;
            _expected = 1d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, _mode), "Half-Rounding 1");

            _test = 1.5d;
            _expected = 2d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, _mode), "Half-Rounding 2");

            _test = 2.5d;
            _expected = 3d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, _mode), "Half-Rounding 3");

            _test = 1.2345d;
            _expected = 1.235d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 3, _mode), "Half-Rounding 4");

            _test = -1.2345d;
            _expected = -1.235d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 3, _mode), "Half-Rounding 5");

            _test = 1.2355d;
            _expected = 1.236d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 3, _mode), "Half-Rounding 6");

            // Jeroen De Maeijer.
            _test = -0.0714285714d;
            _expected = -0.1d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 1, _mode), "Jeroen De Maeijer");

            // Hallman.
            _test = 0.09d;
            _expected = 0.1d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 1, _mode), "Hallman 1");

            _test = 0.0099d;
            _expected = 0d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 1, _mode), "Hallman 2");

            _test = 0.0099d;
            _expected = 0.01d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 2, _mode), "Hallman 3");

            _test = 0.0099d;
            _expected = 0.01d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 3, _mode), "Hallman 4");

            _test = 0.0099d;
            _expected = 0.0099d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 4, _mode), "Hallman 4");

            // Resolution.
            _test = 1.01234012340125d;
            _expected = 1.01234012340125d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 14, _mode), "Resolution 1");

            _test = 1.01234012340125d;
            _expected = 1.0123401234013d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 13, _mode), "Resolution 2");

            // Large numbers.
            _test = Math.Pow(10, 13) + 0.74d;
            _expected = 10000000000000.7d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 1, _mode), "Large numbers 1");

            _test = Math.Pow(-10, 13) + 0.75d;
            _expected = -9999999999999.3d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 1, _mode), "Large numbers 2");

            _test = 1.11111111111111E+16;
            _expected = 1.1E+16;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, -15, _mode), "Large numbers 3");

            // Very large numbers.
            _test = Math.Pow(10, 307);
            _expected = 1e+307d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, _mode), "Very large numbers 1");

            _test = -Math.Pow(10, 308);
            _expected = -1e+308d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, _mode), "Very large numbers 2");

            // Double can only be Rounded to 15 decimals.
            _test = 10.5d;
            _expected = 10.5d;
            Assert.AreEqual(_expected, (double)MathExt.RoundMid((decimal)_test, 20, _mode), "Very large numbers 3");

            _test = 10.5d;
            _expected = 0;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, -20, _mode), "Very large numbers 3");

            // Negative Rounding.
            _test = -226.6d;
            _expected = -227d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, _mode), "Negative Rounding 1");

            _test = -226.5d;
            _expected = -227d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, _mode), "Negative Rounding 2");

            _test = -226.4d;
            _expected = -226d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, _mode), "Negative Rounding 3");

            // Rounding integers.
            _test = 226.7d;
            _expected = 230d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, -1, _mode), "Rounding integers 1");

            _test = 226.7d;
            _expected = 200d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, -2, _mode), "Rounding integers 2");

            _test = 226.7d;
            _expected = 0;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, -3, _mode), "Rounding integers 3");

            _test = 226.7d;
            _expected = 0;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, -4, _mode), "Rounding integers 4");

            // Nasty reals.
            _test = 2.445d;
            _expected = 2.45d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 2, _mode), "Nasty reals 1");

            _test = -2.445d;
            _expected = -2.45d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 2, _mode), "Nasty reals 2");

            _test = 3.445d;
            _expected = 3.45d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 2, _mode), "Nasty reals 3");

            _test = -3.445d;
            _expected = -3.45d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 2, _mode), "Nasty reals 4");

            _test = 100.05d;
            _expected = 100.1d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 1, _mode), "Nasty reals 5");

            _test = -100.05d;
            _expected = -100.1d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 1, _mode), "Nasty reals 6");

            _test = 30.675d;
            _expected = 30.68d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 2, _mode), "Nasty reals 7");

            _test = 31.675d;
            _expected = 31.68d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 2, _mode), "Nasty reals 8");

            _test = 32.675d;
            _expected = 32.68d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 2, _mode), "Nasty reals 9");

            _test = 33.675d;
            _expected = 33.68d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 2, _mode), "Nasty reals 10");

            _test = 128.015d;
            _expected = 128.02d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 2, _mode), "Nasty reals 11");

            _test = 128.045d;
            _expected = 128.05d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 2, _mode), "Nasty reals 12");

            // Twice the same value.
            _test = 1.01010101010101d;
            _expected = 1.01d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 2, _mode), "Twice the same 1");

            _test = 1.01010101010101d;
            _expected = 1.01d;
            Assert.AreEqual(_expected, MathExt.RoundMid(_test, 2, _mode), "Twice the same 2");
        }

    }
}
