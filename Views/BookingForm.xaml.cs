using SK_Airlines_App.ViewModel;


namespace SK_Airlines_App;

public partial class BookingForm : ContentPage
{
	BookingFormViewModel BookingFormViewModelPage = new BookingFormViewModel();
	public BookingForm()
	{
		InitializeComponent();
		BindingContext = BookingFormViewModelPage;

    }

	private async void OnButtonClicked(object sender, EventArgs e)
	{
		BookingFormViewModelPage.GetInfo(origin.Text,dest.Text,adultNum.Text,childNum.Text,infantNum.Text, flightTypepck.SelectedItem.ToString(),
			departurepck.Date.ToString("dd/MM/yyyy"), returnpck.Date.ToString("dd/MM/yyyy"), promoCode.Text,"0");
		await Navigation.PushAsync(new FlightBookingPage());
	}
}