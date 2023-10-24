namespace SK_Airlines_App;

public partial class BookingForm : ContentPage
{
	public BookingForm()
	{
		InitializeComponent();
	}

	private async void OnButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new FlightBookingPage());
	}
}