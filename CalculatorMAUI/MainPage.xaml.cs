using System.Linq;

namespace CalculatorMAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonCleanAll(object sender, EventArgs e)
        {
            if (btnClean.Text == "CE")
            {
                TextField.Text = "   ";
                TextFieldAnswer.Text = "";
            }

            btnClean.Text = "CE";
            TextField.Text = "   ";
        }
        private void ButtonCleanSymbol(object sender, EventArgs e)
        {
            if (TextField.Text != "   ")
            {
                TextField.Text = TextField.Text[^1] switch
                {
                    '(' when Utilities.Calculator.MathematicalFunctions.ContainsKey(TextField.Text[^4..^1])
                            => TextField.Text.Remove(TextField.Text.Length - 4),

                    '(' when Utilities.Calculator.MathematicalFunctions.ContainsKey(TextField.Text[^3..^1])
                            => TextField.Text.Remove(TextField.Text.Length - 3),

                    _ when Utilities.Calculator.Constants.ContainsKey(TextField.Text[^2..])
                            => TextField.Text.Remove(TextField.Text.Length - 2),

                    _ => TextField.Text.Remove(TextField.Text.Length - 1),
                };
            }
        }

        private void ButtonPrint1(object sender, EventArgs e) => TextField.Text += "1";
        private void ButtonPrint2(object sender, EventArgs e) => TextField.Text += "2";
        private void ButtonPrint3(object sender, EventArgs e) => TextField.Text += "3";
        private void ButtonPrint4(object sender, EventArgs e) => TextField.Text += "4";
        private void ButtonPrint5(object sender, EventArgs e) => TextField.Text += "5";
        private void ButtonPrint6(object sender, EventArgs e) => TextField.Text += "6";
        private void ButtonPrint7(object sender, EventArgs e) => TextField.Text += "7";
        private void ButtonPrint8(object sender, EventArgs e) => TextField.Text += "8";
        private void ButtonPrint9(object sender, EventArgs e) => TextField.Text += "9";
        private void ButtonPrint0(object sender, EventArgs e) => TextField.Text += "0";
        private void ButtonPrint00(object sender, EventArgs e) => TextField.Text += "00";
        private void ButtonPrintComma(object sender, EventArgs e) => TextField.Text += ",";


        public static string ReverseString(string str)
        {
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
        private void ButtonCalcPersent(object sender, EventArgs e)
        {
            if (TextField.Text != "   ")
            {
                string number = "";

                try
                {
                    for (int i = TextField.Text.Length - 1; ; i--)
                    {
                        if (char.IsDigit(TextField.Text[i]))
                        {
                            number += TextField.Text[i];
                        }
                        else if (TextField.Text[i] == ' ')
                        {
                            number = ReverseString(number); 
                            TextField.Text = (double.Parse(number) / 100).ToString();
                            return;
                        }
                        else if (TextField.Text[i] is '/' or '*' or '^')
                        {
                            number = ReverseString(number);
                            TextField.Text = TextField.Text.Remove(TextField.Text.Length - number.Length) + (double.Parse(number) / 100).ToString();
                            return;
                        }
                        else
                        {
                            break;
                        }
                    }
                    number = ReverseString(number);

                    TextField.Text = TextField.Text.Remove(TextField.Text.Length - number.Length);

                    double tempNumber = Utilities.Calculator.Calculate(TextField.Text[..^1]);

                    double percentNumber = (tempNumber * double.Parse(number)) / 100;
                    
                    TextField.Text += percentNumber;
                }
                catch { }
            }
        }


        private static bool IsMathematicalSignOrComma(char lastSign)
        {
            if (lastSign is '/' or '*' or '-' or '+' or ',' or '^')
            {
                return true;
            }
            else return false;
        }


        private void ButtonPrintDivision(object sender, EventArgs e)
        {
            if (TextField.Text != "   ")
            {
                if (IsMathematicalSignOrComma(TextField.Text[^1]))
                    TextField.Text = TextField.Text.Remove(TextField.Text.Length - 1);

                TextField.Text += '/';
            }
        }
        private void ButtonPrintMultiplication(object sender, EventArgs e)
        {
            if (TextField.Text != "   ")
            {
                if (IsMathematicalSignOrComma(TextField.Text[^1]))
                    TextField.Text = TextField.Text.Remove(TextField.Text.Length - 1);

                TextField.Text += '*';
            }
        }
        private void ButtonPrintMinus(object sender, EventArgs e)
        {
            if (IsMathematicalSignOrComma(TextField.Text[^1]))
                TextField.Text = TextField.Text.Remove(TextField.Text.Length - 1);
            
            TextField.Text += '-';
        }
        private void ButtonPrintPlus(object sender, EventArgs e)
        {
            if (TextField.Text != "   ")
            {
                if (IsMathematicalSignOrComma(TextField.Text[^1]))
                    TextField.Text = TextField.Text.Remove(TextField.Text.Length - 1);

                TextField.Text += '+';
            }
        }
        private void ButtonPrintPowSign(object sender, EventArgs e)
        {
            if (TextField.Text != "   ")
            {
                if (IsMathematicalSignOrComma(TextField.Text[^1]))
                    TextField.Text = TextField.Text.Remove(TextField.Text.Length - 1);

                TextField.Text += '^';
            }
        } 
        private void ButtonPrintReversedPower(object sender, EventArgs e)
        {
            if (TextField.Text != "   ")
            {
                if (IsMathematicalSignOrComma(TextField.Text[^1]))
                    TextField.Text = TextField.Text.Remove(TextField.Text.Length - 1);

                TextField.Text += "^(-1)";
            }
        }


        private void ButtonAnswer(object sender, EventArgs e)
        {
            try
            {
                TextField.Text = Utilities.Calculator.Calculate(TextField.Text).ToString();
                TextFieldAnswer.Text = "";
            }
            catch (Exception)
            {
                TextFieldAnswer.Text = "Ошибка";
                TextField.Text = "   ";
            }
        }


        private void AddMultiplySign()
        {
            if (TextField.Text != "   " &&
                !IsMathematicalSignOrComma(TextField.Text[^1]) &&
                TextField.Text[^1] != '(')
            {
                TextField.Text += '*';
            }
        }


        private void ButtonPrintSin(object sender, EventArgs e)
        {
            AddMultiplySign();
            TextField.Text += "sin(";
        }
        private void ButtonPrintCos(object sender, EventArgs e)
        {
            AddMultiplySign();
            TextField.Text += "cos(";
        }
        private void ButtonPrintTan(object sender, EventArgs e)
        {
            AddMultiplySign();
            TextField.Text += "tan(";
        }
        private void ButtonPrintCtg(object sender, EventArgs e)
        {
            AddMultiplySign();
            TextField.Text += "ctg(";
        }
        private void ButtonPrintLog(object sender, EventArgs e)
        {
            AddMultiplySign();
            TextField.Text += "log(";
        }
        private void ButtonPrintLn(object sender, EventArgs e)
        {
            AddMultiplySign();
            TextField.Text += "ln(";
        }
        private void ButtonPrintSec(object sender, EventArgs e)
        {
            AddMultiplySign();
            TextField.Text += "sec(";
        }
        private void ButtonPrintCsc(object sender, EventArgs e)
        {
            AddMultiplySign();
            TextField.Text += "csc(";
        }
        private void ButtonPrintAbsolut(object sender, EventArgs e)
        {
            AddMultiplySign();
            TextField.Text += "abs(";
        }
        private void ButtonPrintExp(object sender, EventArgs e)
        {
            AddMultiplySign();
            TextField.Text += "exp(";
        } 
        private void ButtonPrintFactorial(object sender, EventArgs e)
        {
            if (TextField.Text != "   " && (Char.IsDigit(TextField.Text[^1]) || TextField.Text[^1] == ')'))
                TextField.Text += "!";
        }


        private void ButtonPrintLeftBracket(object sender, EventArgs e)
        {
            AddMultiplySign();
            TextField.Text += "(";
        }
        private void ButtonPrintRightBracket(object sender, EventArgs e) => TextField.Text += ")";

        
        private void ButtonPrintExpNumber(object sender, EventArgs e) => TextField.Text += "e";
        private void ButtonPrintPiNumber(object sender, EventArgs e) => TextField.Text += "pi";

        private void TextField_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TextField.Text != "   ")
                btnClean.Text = "C";

            if (TextField.Text != "   ")
            {
                try
                {
                    if (!IsMathematicalSignOrComma(TextField.Text[^1]))
                    {
                        TextFieldAnswer.Text = "= " + Utilities.Calculator.Calculate(TextField.Text).ToString();
                    }
                }
                catch (DivideByZeroException)
                {
                    TextFieldAnswer.Text = "Деление на ноль";
                }
                catch { TextFieldAnswer.Text = ""; }
            }
        }

        #region Menu
        private const uint AnimationDuration = 400u;

        async private void ShowMenu(object sender, EventArgs e)
        {
            _ = MainContentGrid.TranslateTo(this.Width * 0.7, this.Height * 0.0, AnimationDuration, Easing.CubicIn);
            _ = MainContentGrid.FadeTo(0.7, AnimationDuration);
            await MainContentGrid.ScaleTo(1, AnimationDuration);
        }

        async private void ButtonCloseMenu(object sender, EventArgs e)
        {
            await ClosePage();
        }

        async private void GridArea_Tapped(object sender, EventArgs e)
        {
            await ClosePage();
        }

        private async Task ClosePage()
        {
            _ = MainContentGrid.FadeTo(1, AnimationDuration);
            _ = MainContentGrid.ScaleTo(1, AnimationDuration);
            await MainContentGrid.TranslateTo(0, 0, AnimationDuration, Easing.CubicIn);
        } 
        #endregion


        async private void ButtonGoToConvertPageData(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConvertPageData());
        }
        
        async private void ButtonGoToConvertPageTemp(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConvertPageTemperature());
        }
        
        async private void ButtonGoToTicTacToePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TicTacToePage());
        }


    }
}