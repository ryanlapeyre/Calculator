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

namespace Calculator
{

    
    public partial class MainWindow : Window
    {
        const string startString = "          ";
        const string squareErrorMessage = "Congrats! You tried to square root a negative number. Unfortunately, math doesn't allow that. " +
            "All relevant internal data will be reset in this calculator and you'll have to start from SQUARE one. Thanks for your patience.";
        const string divideErrorMessage = "Congrats! You tried to divide a number by zero. Unfortunately, the universe doesn't allow that. " +
            "All relevant internal data will be reset in this calculator and you'll have to start from ground ZERO. Thanks for your patience.";
        const string inputErrorMessage = "Congrats! You tried to input an invalid action. It probably contains a repeated mashing of one of the operation buttons. Unfortunately, I, the sentient robot calculator, won't allow that. " +
            "All relevant internal data will be reset in this calculator and you'll have to start from nothing, which means it'll be a big OPERATION to recover your work. Thanks for your patience.";
        string checkString;

        double firstArgument = 0;
        double secondArgument = 0;
        double equalResult = 0;
        double equalArgument = 0;

        bool isAddition = false;
        bool isSubtraction = false;
        bool isDivision = false;
        bool isMultiplication = false;
        bool isSquareRoot = false;
        bool isEqualSwitch = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SevenClick(object sender, RoutedEventArgs e)
        {
            InputField.IsReadOnly = false;
            InputField.Text += "7";
            InputField.IsReadOnly = true;
            return;
        }

        private void EightClick(object sender, RoutedEventArgs e)
        {
            InputField.IsReadOnly = false;
            InputField.Text += "8";
            InputField.IsReadOnly = true;
            return;
        }

        private void NineClick(object sender, RoutedEventArgs e)
        {
            InputField.IsReadOnly = false;
            InputField.Text += "9";
            InputField.IsReadOnly = true;
            return;
        }
        private void FourClick(object sender, RoutedEventArgs e)
        {
            InputField.IsReadOnly = false;
            InputField.Text += "4";
            InputField.IsReadOnly = true;
            return;
        }
        private void FiveClick(object sender, RoutedEventArgs e)
        {
            InputField.IsReadOnly = false;
            InputField.Text += "5";
            InputField.IsReadOnly = true;
            return;
        }

        private void SixClick(object sender, RoutedEventArgs e)
        {
            InputField.IsReadOnly = false;
            InputField.Text += "6";
            InputField.IsReadOnly = true;
            return;
        }

        private void OneClick(object sender, RoutedEventArgs e)
        {
            InputField.IsReadOnly = false;
            InputField.Text += "1";
            InputField.IsReadOnly = true;
            return;
        }

        private void TwoClick(object sender, RoutedEventArgs e)
        {
            InputField.IsReadOnly = false;
            InputField.Text += "2";
            InputField.IsReadOnly = true;
            return;
        }

        private void ThreeClick(object sender, RoutedEventArgs e)
        {
            InputField.IsReadOnly = false;
            InputField.Text += "3";
            InputField.IsReadOnly = true;
            return;
        }

        private void ZeroClick(object sender, RoutedEventArgs e)
        {
            InputField.IsReadOnly = false;
            InputField.Text += "0";
            InputField.IsReadOnly = true;
            return;
        }

        private void DotClick(object sender, RoutedEventArgs e)
        {
            checkString = InputField.Text.Trim();
            if (checkString.Contains("."))
            {
                return;
            }
            InputField.IsReadOnly = false;
            InputField.Text += ".";
            InputField.IsReadOnly = true;
            return;
        }

        private void ClearEntry(object sender, RoutedEventArgs e)
        {
            InputField.IsReadOnly = false;
            InputField.Text = startString;
            InputField.IsReadOnly = true;
            return;
        }

        private void Addition(object sender, RoutedEventArgs e)
        {
            if(!double.TryParse(InputField.Text, out firstArgument))
            {
                MessageBox.Show(this, inputErrorMessage);
                firstArgument = 0;
                secondArgument = 0;
                equalResult = 0;
                equalArgument = 0;
                isAddition = false;
                isSubtraction = false;
                isDivision = false;
                isMultiplication = false;
                isSquareRoot = false;
                isEqualSwitch = false;
                InputField.IsReadOnly = false;
                InputField.Text = startString;
                InputField.IsReadOnly = true;
                return;
            }
            InputField.IsReadOnly = false;
            InputField.Text = startString;
            InputField.IsReadOnly = true;
            isAddition = true;
            isSubtraction = false;
            isDivision = false;
            isMultiplication = false;
            isSquareRoot = false;
            isEqualSwitch = false;
            return;
        }

        private void Equation(object sender, RoutedEventArgs e)
        {
            if (!isEqualSwitch)
            {
                if(!double.TryParse(InputField.Text, out secondArgument))
                {
                    MessageBox.Show(this, inputErrorMessage);
                    firstArgument = 0;
                    secondArgument = 0;
                    equalResult = 0;
                    equalArgument = 0;
                    isAddition = false;
                    isSubtraction = false;
                    isDivision = false;
                    isMultiplication = false;
                    isSquareRoot = false;
                    isEqualSwitch = false;
                    InputField.IsReadOnly = false;
                    InputField.Text = startString;
                    InputField.IsReadOnly = true;
                    return;
                }

                if(isAddition)
                {
                    equalResult = firstArgument + secondArgument;
                }
                else if(isSubtraction)
                {
                    equalResult = firstArgument - secondArgument;
                }
                else if (isMultiplication)
                {
                    equalResult = firstArgument * secondArgument;
                }
                else if (isDivision)
                {
                    if(secondArgument == 0)
                    {
                        MessageBox.Show(this, divideErrorMessage);
                        firstArgument = 0;
                        secondArgument = 0;
                        equalResult = 0;
                        equalArgument = 0;
                        isAddition = false;
                        isSubtraction = false;
                        isDivision = false;
                        isMultiplication = false;
                        isSquareRoot = false;
                        isEqualSwitch = false;
                        InputField.IsReadOnly = false;
                        InputField.Text = startString;
                        InputField.IsReadOnly = true;
                        return;
                    }
                    equalResult = firstArgument / secondArgument;
                }

                InputField.IsReadOnly = false;
                equalArgument = secondArgument;
                InputField.Text = startString + System.Convert.ToString(equalResult);
                InputField.IsReadOnly = true; 
                isEqualSwitch = true;
                return;                    
            }
            else
            {

                double.TryParse(InputField.Text, out secondArgument);
                if (isAddition)
                {
                    equalResult = secondArgument + equalArgument;
                }
                else if (isSubtraction)
                {
                    equalResult = secondArgument - equalArgument;
                }
                else if (isMultiplication)
                {
                    equalResult = secondArgument * equalArgument;
                }
                else if (isDivision)
                {
                    equalResult = secondArgument / equalArgument;
                }
                else if (isSquareRoot)
                {
                    equalResult = Math.Sqrt(secondArgument);
                }
                InputField.IsReadOnly = false;
                InputField.Text = startString + equalResult;
                InputField.IsReadOnly = true;
                return;
            }
        }

        private void Division(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(InputField.Text, out firstArgument))
            {
                MessageBox.Show(this, inputErrorMessage);
                firstArgument = 0;
                secondArgument = 0;
                equalResult = 0;
                equalArgument = 0;
                isAddition = false;
                isSubtraction = false;
                isDivision = false;
                isMultiplication = false;
                isSquareRoot = false;
                isEqualSwitch = false;
                InputField.IsReadOnly = false;
                InputField.Text = startString;
                InputField.IsReadOnly = true;
                return;
            }
            InputField.IsReadOnly = false;
            InputField.Text = startString;
            InputField.IsReadOnly = true;
            isAddition = false;
            isSubtraction = false;
            isDivision = true;
            isMultiplication = false;
            isSquareRoot = false;
            isEqualSwitch = false;
            return;
        }

        private void Multiplication(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(InputField.Text, out firstArgument))
            {
                MessageBox.Show(this, inputErrorMessage);
                firstArgument = 0;
                secondArgument = 0;
                equalResult = 0;
                equalArgument = 0;
                isAddition = false;
                isSubtraction = false;
                isDivision = false;
                isMultiplication = false;
                isSquareRoot = false;
                isEqualSwitch = false;
                InputField.IsReadOnly = false;
                InputField.Text = startString;
                InputField.IsReadOnly = true;
                return;
            }
            InputField.IsReadOnly = false;
            InputField.Text = startString;
            InputField.IsReadOnly = true;
            isAddition = false;
            isSubtraction = false;
            isDivision = false;
            isMultiplication = true;
            isSquareRoot = false;
            isEqualSwitch = false;
            return;
        }

        private void Subtraction(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(InputField.Text, out firstArgument))
            {
                MessageBox.Show(this, inputErrorMessage);
                firstArgument = 0;
                secondArgument = 0;
                equalResult = 0;
                equalArgument = 0;
                isAddition = false;
                isSubtraction = false;
                isDivision = false;
                isMultiplication = false;
                isSquareRoot = false;
                isEqualSwitch = false;
                InputField.IsReadOnly = false;
                InputField.Text = startString;
                InputField.IsReadOnly = true;
                return;
            }
            InputField.IsReadOnly = false;
            InputField.Text = startString;
            InputField.IsReadOnly = true;
            isAddition = false;
            isSubtraction = true;
            isDivision = false;
            isMultiplication = false;
            isSquareRoot = false;
            isEqualSwitch = false;
            return;
        }

        private void SquareRoot(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(InputField.Text, out firstArgument))
            {
                MessageBox.Show(this, inputErrorMessage);
                firstArgument = 0;
                secondArgument = 0;
                equalResult = 0;
                equalArgument = 0;
                isAddition = false;
                isSubtraction = false;
                isDivision = false;
                isMultiplication = false;
                isSquareRoot = false;
                isEqualSwitch = false;
                InputField.IsReadOnly = false;
                InputField.Text = startString;
                InputField.IsReadOnly = true;
                return;
            }
            if (firstArgument < 0)
            {
                MessageBox.Show(this, squareErrorMessage);           
                firstArgument = 0;
                secondArgument = 0;
                equalResult = 0;
                equalArgument = 0;
                isAddition = false;
                isSubtraction = false;
                isDivision = false;
                isMultiplication = false;
                isSquareRoot = false;
                isEqualSwitch = false;
                InputField.IsReadOnly = false;
                InputField.Text = startString;
                InputField.IsReadOnly = true;
                return;
            }

            InputField.IsReadOnly = false;
            InputField.Text = startString + Math.Sqrt(firstArgument);
            InputField.IsReadOnly = true;

            
            isAddition = false;
            isSubtraction = false;
            isDivision = false;
            isMultiplication = false;
            isSquareRoot = true;
            isEqualSwitch = true;
            
            return;
            
        }

        private void NegativeClick(object sender, RoutedEventArgs e)
        {
            InputField.IsReadOnly = false;
            checkString = InputField.Text.Trim();
            if (checkString.Contains("-"))
            {
                checkString = checkString.Replace("-", "");
                InputField.Text = startString + checkString;
                InputField.IsReadOnly = true;
                return;
            }
            checkString = checkString.Insert(0, "-");
            InputField.Text = startString + checkString;
            InputField.IsReadOnly = true;
            return;
        }

        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
           
        }
        private void MaximizedScreenHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if(this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                return;
            }
            this.WindowState = WindowState.Normal;
            return;
        }

    }
}
