using SK_Airlines_App.Views;

namespace SK_Airlines_App;

public partial class FlightBookingSelection : ContentPage
{
	public FlightBookingSelection()
	{
        InitializeComponent();
	}

	private async void OnButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new GuestDetailsPage());
	}
}