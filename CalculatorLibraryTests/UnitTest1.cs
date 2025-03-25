using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorLibrary;
using System;

namespace CalculatorLibraryTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void TestAddition()
        {
            // Act
            double result = Calculator.Add(2, 3);

            // Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TestSubtraction()
        {
            // Act
            double result = Calculator.Subtract(5, 3);

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestMultiplication()
        {
            // Act
            double result = Calculator.Multiply(2, 3);

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void TestDivision()
        {
            // Act
            double result = Calculator.Divide(6, 3);

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestDivisionByZero()
        {
            // Act & Assert
            Assert.ThrowsException<DivideByZeroException>(() => Calculator.Divide(6, 0));
        }

        [TestMethod]
        public void TestPower()
        {
            // Act
            double result = Calculator.Power(2, 3);

            // Assert
            Assert.AreEqual(8, result);
        }
    }
}
