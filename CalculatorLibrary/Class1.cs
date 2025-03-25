using System;

namespace CalculatorLibrary
{
    public class Calculator
    {
        public static double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        public static double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        public static double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        public static double Divide(double num1, double num2)
        {
            if (num2 == 0)
                throw new DivideByZeroException("Cannot divide by zero");
            return num1 / num2;
        }

        public static double Power(double num, double exp)
        {
            return Math.Pow(num, exp);
        }
    }
}
