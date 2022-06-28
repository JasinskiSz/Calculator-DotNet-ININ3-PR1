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
        bool flagClear = false;
        decimal lastNumber, result;
        Operator optr;
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
            decimal newNumber;
            if (decimal.TryParse(inputWindow.Content.ToString(), out newNumber))
            {
                switch (optr)
                {
                    case Operator.Addition:
                        result = MathMaker.Add(lastNumber, newNumber);
                        break;
                    case Operator.Subtraction:
                        result = MathMaker.Subtract(lastNumber, newNumber);
                        break;
                    case Operator.Multiplication:
                        result = MathMaker.Multiply(lastNumber, newNumber);
                        break;
                    case Operator.Division:
                        result = MathMaker.Divide(lastNumber, newNumber);
                        break;
                    case Operator.Exponentiation:
                        result = MathMaker.Exponentiation(lastNumber, newNumber);
                        break;
                }

                resultWindow.Content = $"{resultWindow.Content}{newNumber}";
                inputWindow.Content = $"={result}";
                flagClear = true;
            }
        }

        private void OperationButtonClick(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(inputWindow.Content.ToString(), out lastNumber))
            {
                resultWindow.Content = $"{lastNumber}";
                inputWindow.Content = "0";
            }

            if (sender == multiplyButton)
            {
                optr = Operator.Multiplication;
                resultWindow.Content = $"{resultWindow.Content}*";
            }
            if (sender == divideButton)
            {
                optr = Operator.Division;
                resultWindow.Content = $"{resultWindow.Content}/";
            }
            if (sender == plusButton)
            {
                optr = Operator.Addition;
                resultWindow.Content = $"{resultWindow.Content}+";
            }
            if (sender == minusButton)
            {
                optr = Operator.Subtraction;
                resultWindow.Content = $"{resultWindow.Content}-";
            }
            if (sender == exponentiationButton)
            {
                optr = Operator.Exponentiation;
                resultWindow.Content = $"{resultWindow.Content}^";
            }
            if (sender == moduloButton)
            {
                optr = Operator.Modulo;
                resultWindow.Content = $"{resultWindow.Content}mod";
            }
        }

        private void ClearButtonClick(object sender, RoutedEventArgs e)
        {
            inputWindow.Content = "0";
            resultWindow.Content = "";
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            int x = inputWindow.Content.ToString().Count();

            if (x == 1)
            {
                inputWindow.Content = "0";
                return;
            }
            if (x < 1)
            {
                return;
            }
            inputWindow.Content = inputWindow.Content.ToString().Substring(0, x - 1);
        }

        private void PercentButtonClick(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(inputWindow.Content.ToString(), out decimal newNumber))
            {
                newNumber /= 100;
                inputWindow.Content = newNumber.ToString();
            }
        }

        private void NegativeButtonClick(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(inputWindow.Content.ToString(), out decimal newNumber))
            {
                newNumber *= -1;
                inputWindow.Content = newNumber.ToString();
            }
        }

        private void PointButtonClick(object sender, RoutedEventArgs e)
        {
            if (!inputWindow.Content.ToString().Contains('.'))
            {
                inputWindow.Content = $"{inputWindow.Content}.";
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

            if (flagClear)
            {
                resultWindow.Content = "";
                inputWindow.Content = $"{number}";
                flagClear = false;
            }
            else if (inputWindow.Content.ToString() == "0")
            {
                inputWindow.Content = $"{number}";
            }
            else
            {
                inputWindow.Content = $"{inputWindow.Content}{number}";
            }
        }
    }

    public class MathMaker
    {
        public static decimal Add(decimal n1, decimal n2)
        {
            return n1 + n2;
        }

        public static decimal Subtract(decimal n1, decimal n2)
        {
            return n1 - n2;
        }

        public static decimal Multiply(decimal n1, decimal n2)
        {
            return n1 * n2;
        }

        public static decimal Divide(decimal n1, decimal n2)
        {
            if (n2 == 0)
            {
                MessageBox.Show("Dividing by 0 is prohibited!", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }

            return n1 / n2;
        }

        public static decimal Exponentiation(decimal n1, decimal n2)
        {
            return (decimal)Math.Pow((double)n1, (double)n2);
        }

        public static decimal Modulo(decimal n1, decimal n2)
        {
            return n1 % n2;
        }
    }

    public enum Operator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
        Exponentiation,
        Modulo
    }
}
