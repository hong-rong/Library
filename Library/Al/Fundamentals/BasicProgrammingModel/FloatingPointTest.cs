using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Fundamentals.BasicProgrammingModel
{
    [TestClass]
    public class floatingPointTest
    {
        public static bool nearlyEqual(float a, float b, float epsilon)
        {
            float absA = Math.Abs(a);
            float absB = Math.Abs(b);
            float diff = Math.Abs(a - b);

            if (a == b)
            { // shortcut, handles infinities
                return true;
            }
            else if (a == 0 || b == 0 || diff < float.MinValue)
            {
                // a or b is zero or both are extremely close to it
                // relative error is less meaningful here
                return diff < (epsilon * float.MinValue);
            }
            else
            { // use relative error
                return diff / (absA + absB) < epsilon;
            };
        }

        public static bool nearlyEqual(float a, float b)
        {
            return nearlyEqual(a, b, 0.00001f);
        }

        /** Regular large numbers - generally not problematic */
        [TestMethod]
        public void big()
        {
            Assert.IsTrue(nearlyEqual(1000000f, 1000001f));
            Assert.IsTrue(nearlyEqual(1000001f, 1000000f));
            Assert.IsFalse(nearlyEqual(10000f, 10001f));
            Assert.IsFalse(nearlyEqual(10001f, 10000f));
        }

        /** Negative large numbers */
        [TestMethod]
        public void bigNeg()
        {
            Assert.IsTrue(nearlyEqual(-1000000f, -1000001f));
            Assert.IsTrue(nearlyEqual(-1000001f, -1000000f));
            Assert.IsFalse(nearlyEqual(-10000f, -10001f));
            Assert.IsFalse(nearlyEqual(-10001f, -10000f));
        }

        /** Numbers around 1 */
        [TestMethod]
        public void mid()
        {
            Assert.IsTrue(nearlyEqual(1.0000001f, 1.0000002f));
            Assert.IsTrue(nearlyEqual(1.0000002f, 1.0000001f));
            Assert.IsFalse(nearlyEqual(1.0002f, 1.0001f));
            Assert.IsFalse(nearlyEqual(1.0001f, 1.0002f));
        }

        /** Numbers around -1 */
        [TestMethod]
        public void midNeg()
        {
            Assert.IsTrue(nearlyEqual(-1.000001f, -1.000002f));
            Assert.IsTrue(nearlyEqual(-1.000002f, -1.000001f));
            Assert.IsFalse(nearlyEqual(-1.0001f, -1.0002f));
            Assert.IsFalse(nearlyEqual(-1.0002f, -1.0001f));
        }

        /** Numbers between 1 and 0 */
        [TestMethod]
        public void small()
        {
            Assert.IsTrue(nearlyEqual(0.000000001000001f, 0.000000001000002f));
            Assert.IsTrue(nearlyEqual(0.000000001000002f, 0.000000001000001f));
            Assert.IsFalse(nearlyEqual(0.000000000001002f, 0.000000000001001f));
            Assert.IsFalse(nearlyEqual(0.000000000001001f, 0.000000000001002f));
        }

        /** Numbers between -1 and 0 */
        [TestMethod]
        public void smallNeg()
        {
            Assert.IsTrue(nearlyEqual(-0.000000001000001f, -0.000000001000002f));
            Assert.IsTrue(nearlyEqual(-0.000000001000002f, -0.000000001000001f));
            Assert.IsFalse(nearlyEqual(-0.000000000001002f, -0.000000000001001f));
            Assert.IsFalse(nearlyEqual(-0.000000000001001f, -0.000000000001002f));
        }

        /** Comparisons involving zero */
        [TestMethod]
        public void zero()
        {
            Assert.IsTrue(nearlyEqual(0.0f, 0.0f));
            Assert.IsTrue(nearlyEqual(0.0f, -0.0f));
            Assert.IsTrue(nearlyEqual(-0.0f, -0.0f));
            Assert.IsFalse(nearlyEqual(0.00000001f, 0.0f));
            Assert.IsFalse(nearlyEqual(0.0f, 0.00000001f));
            Assert.IsFalse(nearlyEqual(-0.00000001f, 0.0f));
            Assert.IsFalse(nearlyEqual(0.0f, -0.00000001f));

            //Assert.IsTrue(nearlyEqual(0.0f, 1e-40f, 0.01f));
            //Assert.IsTrue(nearlyEqual(1e-40f, 0.0f, 0.01f));
            Assert.IsFalse(nearlyEqual(1e-40f, 0.0f, 0.000001f));
            Assert.IsFalse(nearlyEqual(0.0f, 1e-40f, 0.000001f));

            //Assert.IsTrue(nearlyEqual(0.0f, -1e-40f, 0.1f));
            //Assert.IsTrue(nearlyEqual(-1e-40f, 0.0f, 0.1f));
            Assert.IsFalse(nearlyEqual(-1e-40f, 0.0f, 0.00000001f));
            Assert.IsFalse(nearlyEqual(0.0f, -1e-40f, 0.00000001f));
        }

        /**
         * Comparisons involving infinities
         */
        [TestMethod]
        public void infinities()
        {
            Assert.IsTrue(nearlyEqual(float.PositiveInfinity, float.PositiveInfinity));
            Assert.IsTrue(nearlyEqual(float.NegativeInfinity, float.NegativeInfinity));
            Assert.IsFalse(nearlyEqual(float.NegativeInfinity, float.PositiveInfinity));
            Assert.IsFalse(nearlyEqual(float.PositiveInfinity, float.MaxValue));
            Assert.IsFalse(nearlyEqual(float.NegativeInfinity, -float.MaxValue));
        }

        /**
         * Comparisons involving NaN values
         */
        [TestMethod]
        public void nan()
        {
            Assert.IsFalse(nearlyEqual(float.NaN, float.NaN));
            Assert.IsFalse(nearlyEqual(float.NaN, 0.0f));
            Assert.IsFalse(nearlyEqual(-0.0f, float.NaN));
            Assert.IsFalse(nearlyEqual(float.NaN, -0.0f));
            Assert.IsFalse(nearlyEqual(0.0f, float.NaN));
            Assert.IsFalse(nearlyEqual(float.NaN, float.PositiveInfinity));
            Assert.IsFalse(nearlyEqual(float.PositiveInfinity, float.NaN));
            Assert.IsFalse(nearlyEqual(float.NaN, float.NegativeInfinity));
            Assert.IsFalse(nearlyEqual(float.NegativeInfinity, float.NaN));
            Assert.IsFalse(nearlyEqual(float.NaN, float.MaxValue));
            Assert.IsFalse(nearlyEqual(float.MaxValue, float.NaN));
            Assert.IsFalse(nearlyEqual(float.NaN, -float.MaxValue));
            Assert.IsFalse(nearlyEqual(-float.MaxValue, float.NaN));
            Assert.IsFalse(nearlyEqual(float.NaN, float.MinValue));
            Assert.IsFalse(nearlyEqual(float.MinValue, float.NaN));
            Assert.IsFalse(nearlyEqual(float.NaN, -float.MinValue));
            Assert.IsFalse(nearlyEqual(-float.MinValue, float.NaN));
        }

        /** Comparisons of numbers on opposite sides of 0 */
        [TestMethod]
        public void opposite()
        {
            Assert.IsFalse(nearlyEqual(1.000000001f, -1.0f));
            Assert.IsFalse(nearlyEqual(-1.0f, 1.000000001f));
            Assert.IsFalse(nearlyEqual(-1.000000001f, 1.0f));
            Assert.IsFalse(nearlyEqual(1.0f, -1.000000001f));
            //Assert.IsTrue(nearlyEqual(10 * float.MinValue, 10 * -float.MinValue));
            Assert.IsFalse(nearlyEqual(10000 * float.MinValue, 10000 * -float.MinValue));
        }

        /**
         * The really tricky part - comparisons of numbers very close to zero.
         */
        [TestMethod]
        public void ulp()
        {
            //Assert.IsTrue(nearlyEqual(float.MinValue, -float.MinValue));
            //Assert.IsTrue(nearlyEqual(-float.MinValue, float.MinValue));
            //Assert.IsTrue(nearlyEqual(float.MinValue, 0));
            //Assert.IsTrue(nearlyEqual(0, float.MinValue));
            //Assert.IsTrue(nearlyEqual(-float.MinValue, 0));
            //Assert.IsTrue(nearlyEqual(0, -float.MinValue));

            Assert.IsFalse(nearlyEqual(0.000000001f, -float.MinValue));
            Assert.IsFalse(nearlyEqual(0.000000001f, float.MinValue));
            Assert.IsFalse(nearlyEqual(float.MinValue, 0.000000001f));
            Assert.IsFalse(nearlyEqual(-float.MinValue, 0.000000001f));
        }
    }
}
