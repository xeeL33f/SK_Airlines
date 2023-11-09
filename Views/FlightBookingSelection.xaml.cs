using SK_Airlines_App.Views;

namespace SK_Airlines_App;

[QueryProperty(nameof(Price), "price")]
public partial class FlightBookingSelection : ContentPage
{

	private double _price;
	public double Price
	{
		get { return _price; }
		set
		{
			_price = value;
			OnPropertyChanged();
		}
	}

	public FlightBookingSelection()
	{
		InitializeComponent();
	}

	private async void OnClickedFrameEconomy(object sender, EventArgs e)
	{
        //await Shell.Current.GoToAsync($"{nameof(TestBookingSummary)}?price={Price}");
        //await Navigation.PushAsync(new TestBookingSummary());
        await Navigation.PushAsync(new GuestDetailsPage());


    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}