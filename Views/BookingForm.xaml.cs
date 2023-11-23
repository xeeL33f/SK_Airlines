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
        BookingFormViewModelPage.GetInfo(origin.Text, dest.Text, adultNum.Text, childNum.Text, infantNum.Text, flightTypepck.SelectedItem.ToString(),
            departurepck.Date.ToString("dd/MM/yyyy"), returnpck.Date.ToString("dd/MM/yyyy"), promoCode.Text, "0");
        await Navigation.PushAsync(new FlightBookingPage());

        //--Temporary code added by Jak and can be removed or fully implemented by partner if need be. Currently used this to make "BookingForm" not get a null exception after clicking Button--
        //if (returnpck != null && departurepck != null)
        //{
        //    string returnDate = returnpck.Date.ToString("dd/MM/yyyy");
        //    string departureDate = departurepck.Date.ToString("dd/MM/yyyy");

        //    BookingFormViewModelPage.GetInfo(origin.Text, dest.Text, adultNum.Text, childNum.Text, infantNum.Text, flightTypepck.SelectedItem?.ToString(), departureDate, returnDate, promoCode.Text, "0");
        //    await Navigation.PushAsync(new FlightBookingPage());
        //}
        //else
        //{
        //    return;
        //}
    }
}