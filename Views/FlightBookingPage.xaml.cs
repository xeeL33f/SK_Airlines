using SK_Airlines_App.Views;

namespace SK_Airlines_App;

public partial class FlightBookingPage : ContentPage
{
	public FlightBookingPage()
	{
		InitializeComponent();
	}

	//data should match to the database from the admin based on the route...
	//for now the default value is this but in the future this should be changed...

    //frame 1
	private async void OnTappedFrame1(object sender, TappedEventArgs e)
	{
		await Navigation.PushAsync(new FlightBookingSelection());
	}

    //frame2
    private async void OnTappedFrame2(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new FlightBookingSelection());
    }


    //frame3
    private async void OnTappedFrame3(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new FlightBookingSelection());
    }


    //frame4
    private async void OnTappedFrame4(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new FlightBookingSelection());
    }
}