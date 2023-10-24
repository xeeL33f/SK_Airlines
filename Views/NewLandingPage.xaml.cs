namespace SK_Airlines_App;

public partial class NewLandingPage : ContentPage
{
	public NewLandingPage()
	{
		InitializeComponent();
	}

    private void OnImageTapped(object sender, TappedEventArgs e)
    {
        string originValue = originEntry.Text;
        string destinationValue = destEntry.Text;

        originEntry.Text = destinationValue;
        destEntry.Text = originValue;
    }

    private async void OnButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BookingForm());

    }
}