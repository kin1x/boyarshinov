using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Boyarshinov
{
    public partial class MainWindow : Window
    {
        private string currentNumber = "0";
        private string currentOperation = "";
        private double result = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            string number = ((Button)sender).Content.ToString();
            AppendNumberToInput(number);
        }

        private void AppendNumberToInput(string number)
        {
            if (currentNumber == "0" || currentNumber == "Error")
            {
                currentNumber = number;
            }
            else
            {
                currentNumber += number;
            }

            DisplayTextBox.Text = currentNumber;
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            string operation = ((Button)sender).Content.ToString();

            try
            {
                double currentNumberValue = double.Parse(currentNumber, CultureInfo.InvariantCulture);
                PerformLastOperation(currentNumberValue);
                currentNumber = "0";
                currentOperation = operation;
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        private void PerformLastOperation(double currentNumberValue)
        {
            switch (currentOperation)
            {
                case "+":
                    result += currentNumberValue;
                    break;
                case "-":
                    result -= currentNumberValue;
                    break;
                case "*":
                    result *= currentNumberValue;
                    break;
                case "/":
                    if (currentNumberValue == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    result /= currentNumberValue;
                    break;
                case "^":
                    result = Math.Pow(result, currentNumberValue);
                    break;
                default:
                    result = currentNumberValue;
                    break;
            }

            DisplayTextBox.Text = result.ToString(CultureInfo.InvariantCulture);
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double currentNumberValue = double.Parse(currentNumber, CultureInfo.InvariantCulture);
                double percentage = result * currentNumberValue / 100;
                DisplayResult(percentage);
                currentNumber = percentage.ToString(CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            currentNumber = "0";
            currentOperation = "";
            result = 0;
            DisplayTextBox.Text = currentNumber;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double currentNumberValue = double.Parse(currentNumber, CultureInfo.InvariantCulture);
                PerformLastOperation(currentNumberValue);
                currentOperation = "";
                result = 0;
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        private void NegateButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumber.StartsWith("-"))
            {
                currentNumber = currentNumber.Substring(1);
            }
            else if (!string.IsNullOrEmpty(currentNumber) && currentNumber != "0")
            {
                currentNumber = "-" + currentNumber;
            }

            DisplayTextBox.Text = currentNumber;
        }

        private void DisplayResult(double result)
        {
            DisplayTextBox.Text = result.ToString(CultureInfo.InvariantCulture);
        }

        private void HandleError(Exception ex)
        {
            currentNumber = "Error";
            DisplayTextBox.Text = "Error";
            currentOperation = "";
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }
}
