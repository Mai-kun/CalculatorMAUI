namespace CalculatorMAUI;

public partial class TicTacToePage : ContentPage
{
	public TicTacToePage()
	{
		InitializeComponent();
    }

    private static int turn = 0;
    private void Button_Clicked_1(object sender, EventArgs e)
    {
        if (Button1.Text == "")
        {
            Button1.Text = "X";
            Button1.IsEnabled = false;
            turn++;
            ComputerTurn();
            
        }
    }
    private void Button_Clicked_2(object sender, EventArgs e)
    {
        if (Button2.Text == "")
        {
            Button2.Text = "X";
            Button2.IsEnabled = false;
            turn++;
            ComputerTurn();

        }
    }
    private void Button_Clicked_3(object sender, EventArgs e)
    {
        if (Button3.Text == "")
        {
            Button3.Text = "X";
            Button3.IsEnabled = false;
            turn++;
            ComputerTurn();

        }
    }
    private void Button_Clicked_4(object sender, EventArgs e)
    {
        if (Button4.Text == "")
        {
            Button4.Text = "X";
            Button4.IsEnabled = false;
            turn++;
            ComputerTurn();

        }
    }
    private void Button_Clicked_5(object sender, EventArgs e)
    {
        if (Button5.Text == "")
        {
            Button5.Text = "X";
            Button5.IsEnabled = false;
            turn++;
            ComputerTurn();
        }
    }
    private void Button_Clicked_6(object sender, EventArgs e)
    {
        if (Button6.Text == "")
        {
            Button6.Text = "X";
            Button6.IsEnabled = false;
            turn++;
            ComputerTurn();
        }
    }
    private void Button_Clicked_7(object sender, EventArgs e)
    {
        if (Button7.Text == "")
        {
            Button7.Text = "X";
            Button7.IsEnabled = false;
            turn++;
            ComputerTurn();
        }
    }
    private void Button_Clicked_8(object sender, EventArgs e)
    {
        if (Button8.Text == "")
        {
            Button8.Text = "X";
            Button8.IsEnabled = false;
            turn++;
            ComputerTurn();
        }
    }
    private void Button_Clicked_9(object sender, EventArgs e)
    {
        if (Button9.Text == "")
        {
            Button9.Text = "X";
            Button9.IsEnabled = false;
            turn++;
            ComputerTurn();
        }
    }

    private void ComputerTurn()
    {
        var random = new Random();
        Button[] buttons = { Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9 };

        if (BoardChange(buttons))
        {
            return;
        }

        while (true)
        {
            int tempIndex = random.Next(0, 9);
            if (buttons[tempIndex].Text == "")
            {
                buttons[tempIndex].Text = "O";
                buttons[tempIndex].IsEnabled = false;
                turn++;
                break;
            }
        }

        if (BoardChange(buttons))
        {
            return;
        }
    }

    private bool BoardChange(Button[] button)
    {
        if (IsWinRow(out string result) || IsWinColumn(out result) || IsWinDiagonal(out result))
        {
            for (int i = 0; i < button.Length; i++)
            {
                button[i].IsEnabled = false;
            }
            LabelWinner.Text = result;
            return true;
        }
        else if(turn > 8)
        {
            LabelWinner.Text = "Ничья";
            return true;
        }

        return false;
    }

    private bool IsWinRow(out string result)
    {
        string[] buttons1 = { Button1.Text, Button2.Text, Button3.Text };
        string[] buttons2 = { Button4.Text, Button5.Text, Button6.Text };
        string[] buttons3 = { Button7.Text, Button8.Text, Button9.Text };

        if (buttons1.All(x => x == "X" && x != "") || buttons2.All(x => x == "X" && x != "") || buttons3.All(x => x == "X" && x != ""))
        {
            result = "Вы победили";
            return true;
        }
        if (buttons1.All(x => x == "O" && x != "") || buttons2.All(x => x == "O" && x != "") || buttons3.All(x => x == "O" && x != ""))
        {
            result = "Вы проиграли";
            return true;
        }
        result = "";
        return false;
    }
    private bool IsWinColumn(out string result)
    {
        string[] buttons1 = { Button1.Text, Button4.Text, Button7.Text };
        string[] buttons2 = { Button2.Text, Button5.Text, Button8.Text };
        string[] buttons3 = { Button3.Text, Button6.Text, Button9.Text };

        if (buttons1.All(x => x == "X" && x != "") || buttons2.All(x => x == "X" && x != "") || buttons3.All(x => x == "X" && x != ""))
        {
            result = "Вы победили";
            return true;
        }
        if (buttons1.All(x => x == "O" && x != "") || buttons2.All(x => x == "O" && x != "") || buttons3.All(x => x == "O" && x != ""))
        {
            result = "Вы проиграли";
            return true;
        }
        result = "";
        return false;
    }
    private bool IsWinDiagonal(out string result)
    {
        string[] buttons1 = { Button1.Text, Button5.Text, Button9.Text };
        string[] buttons2 = { Button3.Text, Button5.Text, Button7.Text };

        if (buttons1.All(x => x == "X" && x != "") || buttons2.All(x => x == "X" && x != ""))
        {
            result = "Вы победили";
            return true;
        }
        if (buttons1.All(x => x == "O" && x != "") || buttons2.All(x => x == "O" && x != ""))
        {
            result = "Вы проиграли";
            return true;
        }
        result = "";
        return false;
    }


    private void ButtonNewGame_Clicked(object sender, EventArgs e)
    {
        Button[] buttons = { Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9 };

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].Text = "";
            buttons[i].IsEnabled = true;
        }
        LabelWinner.Text = "";
        turn = 0;
    }
}