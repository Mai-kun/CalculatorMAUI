namespace CalculatorMAUI;

public partial class ConvertPageTemperature : ContentPage
{
	public ConvertPageTemperature()
	{
		InitializeComponent();
        TempPicker1.SelectedIndex = 0;
        TempPicker2.SelectedIndex = 1;
    }

    #region ConvertTemperature
    private int selectionStateTemp1;
    private int selectionStateTemp2;
    private double firstNumberTemp;

    private void TempPicker1_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectionStateTemp1 = TempPicker1.SelectedIndex;

        EntryTemp2.Text = Utilities.ConvertingTemperature.Convert(firstNumberTemp, selectionStateTemp1, selectionStateTemp2);
    }

    private void TempPicker2_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectionStateTemp2 = TempPicker2.SelectedIndex;

        EntryTemp2.Text = Utilities.ConvertingTemperature.Convert(firstNumberTemp, selectionStateTemp1, selectionStateTemp2);
    }

    private void EntryTemp1_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            firstNumberTemp = double.Parse(EntryTemp1.Text);

            EntryTemp2.Text = Utilities.ConvertingTemperature.Convert(firstNumberTemp, selectionStateTemp1, selectionStateTemp2);
        }
        catch { }
    }
    #endregion

    private void ButtonPrint1(object sender, EventArgs e) => EntryTemp1.Text += "1";
    private void ButtonPrint2(object sender, EventArgs e) => EntryTemp1.Text += "2";
    private void ButtonPrint3(object sender, EventArgs e) => EntryTemp1.Text += "3";
    private void ButtonPrint4(object sender, EventArgs e) => EntryTemp1.Text += "4";
    private void ButtonPrint5(object sender, EventArgs e) => EntryTemp1.Text += "5";
    private void ButtonPrint6(object sender, EventArgs e) => EntryTemp1.Text += "6";
    private void ButtonPrint7(object sender, EventArgs e) => EntryTemp1.Text += "7";
    private void ButtonPrint8(object sender, EventArgs e) => EntryTemp1.Text += "8";
    private void ButtonPrint9(object sender, EventArgs e) => EntryTemp1.Text += "9";
    private void ButtonPrint0(object sender, EventArgs e) => EntryTemp1.Text += "0";
    private void ButtonPrintComma(object sender, EventArgs e) => EntryTemp1.Text += ",";

    private void ButtonDeleteAll(object sender, EventArgs e)
    {
        EntryTemp1.Text = "";
        firstNumberTemp = 0;
        EntryTemp2.Text = Utilities.ConvertingTemperature.Convert(firstNumberTemp, selectionStateTemp1, selectionStateTemp2);
    }
    private void ButtonDeleteSymbol(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(EntryTemp1.Text))
        {
            EntryTemp1.Text = EntryTemp1.Text.Remove(EntryTemp1.Text.Length - 1);
        }
    }

    private async void ButtonGoBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}