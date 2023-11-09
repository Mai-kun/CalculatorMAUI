namespace CalculatorMAUI;

public partial class ConvertPageData : ContentPage
{
	public ConvertPageData()
	{
		InitializeComponent();
        DataPicker1.SelectedIndex = 0;
        DataPicker2.SelectedIndex = 1;
	}

    #region ConvertData
    private int selectedState1;
    private int selectedState2;
    private double firstNumber;

    private void DataPicker1_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectedState1 = DataPicker1.SelectedIndex;
 
        EntryData2.Text = Utilities.ÑonvertingData.Convert(firstNumber, selectedState1, selectedState2);
    }
    private void DataPicker2_SelectedIndexChanged(object sender, EventArgs e)
    {
        selectedState2 = DataPicker2.SelectedIndex;

        EntryData2.Text = Utilities.ÑonvertingData.Convert(firstNumber, selectedState1, selectedState2);
    }

    private void EntryData1_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            firstNumber = double.Parse(EntryData1.Text);

            EntryData2.Text = Utilities.ÑonvertingData.Convert(firstNumber, selectedState1, selectedState2);
        }
        catch { }
    }


    #endregion


    private void ButtonPrint1(object sender, EventArgs e) => EntryData1.Text += "1";
    private void ButtonPrint2(object sender, EventArgs e) => EntryData1.Text += "2";
    private void ButtonPrint3(object sender, EventArgs e) => EntryData1.Text += "3";
    private void ButtonPrint4(object sender, EventArgs e) => EntryData1.Text += "4";
    private void ButtonPrint5(object sender, EventArgs e) => EntryData1.Text += "5";
    private void ButtonPrint6(object sender, EventArgs e) => EntryData1.Text += "6";
    private void ButtonPrint7(object sender, EventArgs e) => EntryData1.Text += "7";
    private void ButtonPrint8(object sender, EventArgs e) => EntryData1.Text += "8";
    private void ButtonPrint9(object sender, EventArgs e) => EntryData1.Text += "9";
    private void ButtonPrint0(object sender, EventArgs e) => EntryData1.Text += "0";
    private void ButtonPrintComma(object sender, EventArgs e) => EntryData1.Text += ",";

    private void ButtonDeleteAll(object sender, EventArgs e)
    {
        EntryData1.Text = "";
        EntryData2.Text = "";
    }
    private void ButtonDeleteSymbol(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(EntryData1.Text))
        {
            EntryData1.Text = EntryData1.Text.Remove(EntryData1.Text.Length - 1);
        }
    }

    private async void ButtonGoBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

}