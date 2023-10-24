namespace SK_Airlines_App;

public partial class FlightBookingPage : ContentPage
{
	public FlightBookingPage()
	{
		InitializeComponent();
	}

	private async void OnTappedFrame(object sender, TappedEventArgs e)
	{
		await Navigation.PushAsync(new FlightBookingSelection());
	}
}