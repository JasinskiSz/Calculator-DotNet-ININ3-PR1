using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator_DotNet_ININ3_PR1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();

            clearButton.Click += ClearButtonClick;
            deleteButton.Click += DeleteButtonClick;
            negativeButton.Click += NegativeButtonClick;
            percentButton.Click += PercentButtonClick;
            equalsButton.Click += EqualButtonClick;
        }

        private void EqualButtonClick(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(resultWindow.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Subtract(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                }

                resultWindow.Content = result.ToString();
            }
        }

        private void ClearButtonClick(object sender, RoutedEventArgs e)
        {
            resultWindow.Content = "0";
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            int x = resultWindow.Content.ToString().Count();
            if (x == 1)
            {
                resultWindow.Content = "0";
                return;
            }
            if (x < 1)
            {
                return;
            }
            resultWindow.Content = resultWindow.Content.ToString().Substring(0, x - 1);
        }

        private void PercentButtonClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultWindow.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                resultWindow.Content = lastNumber.ToString();
            }
        }

        private void NegativeButtonClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultWindow.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultWindow.Content = lastNumber.ToString();
            }
        }

        private void OperationButtonClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultWindow.Content.ToString(), out lastNumber))
            {
                resultWindow.Content = "0";
            }

            if (sender == multiplyButton)
                selectedOperator = SelectedOperator.Multiplication;
            if (sender == divideButton)
                selectedOperator = SelectedOperator.Division;
            if (sender == plusButton)
                selectedOperator = SelectedOperator.Addition;
            if (sender == minusButton)
                selectedOperator = SelectedOperator.Subtraction;
        }

        private void PointButtonClick(object sender, RoutedEventArgs e)
        {
            if (resultWindow.Content.ToString().Contains("."))
            {
                // Do nothing
            }
            else
            {
                resultWindow.Content = $"{resultWindow.Content}.";
            }
        }

        private void NumberButtonClick(object sender, RoutedEventArgs e)
        {
            int number = 0;

            if (sender == oneButton)
                number = 1;
            if (sender == twoButton)
                number = 2;
            if (sender == threeButton)
                number = 3;
            if (sender == fourButton)
                number = 4;
            if (sender == fiveButton)
                number = 5;
            if (sender == sixButton)
                number = 6;
            if (sender == sevenButton)
                number = 7;
            if (sender == eightButton)
                number = 8;
            if (sender == nineButton)
                number = 9;
            if (sender == zeroButton)
                number = 0;

            if (resultWindow.Content.ToString() == "0")
            {
                resultWindow.Content = $"{number}";
            }
            else
            {
                resultWindow.Content = $"{resultWindow.Content}{number}";
            }
        }
    }

    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        public static double Subtract(double n1, double n2)
        {
            return n1 - n2;
        }

        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }

        public static double Divide(double n1, double n2)
        {
            if (n2 == 0)
            {
                MessageBox.Show("Dividing by 0 is prohibited!", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }

            return n1 / n2;
        }
    }

    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
}
