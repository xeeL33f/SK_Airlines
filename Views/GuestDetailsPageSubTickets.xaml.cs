using SK_Airlines_App.ViewModels;
using System.Collections.ObjectModel;
using SK_Airlines_App.Models;
using System.Diagnostics;

namespace SK_Airlines_App.Views;

[QueryProperty(nameof(ID), "id")]
public partial class GuestDetailsPageSubTickets : ContentPage
{
    private string _id;
    public string ID
    {
        get { return _id; }
        set
        {
            _id = value;
            OnPropertyChanged();
            guestDetailsPageSubTickets.ConvertToProductCollection(ID);
        }
    }

    GuestDetailsPageSubTicketsViewModel guestDetailsPageSubTickets = new GuestDetailsPageSubTicketsViewModel();
	ObservableCollection<BookingFlight> bookingCollection = new ObservableCollection<BookingFlight>();



	public GuestDetailsPageSubTickets()
	{
		InitializeComponent();
        BindingContext = guestDetailsPageSubTickets;
	}

	/*private async void OnClickedContinueBtn(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new AddonsPage());
    }*/
}