using SK_Airlines_App.ViewModels;
using System.Collections.ObjectModel;
using SK_Airlines_App.Models;
using System.Diagnostics;

namespace SK_Airlines_App.Views;

[QueryProperty(nameof(ID), "id")]
public partial class GuestDetailsPageSubTickets : ContentPage
{
    GuestDetailsPageSubTicketsViewModel guestDetailsPageSubTickets = new GuestDetailsPageSubTicketsViewModel();

    private string id;
    public string ID
    {
        get { return id; }
        set
        {
            id = value;
            OnPropertyChanged();
            ReadFile();
        }
    }

    

	public GuestDetailsPageSubTickets()
	{
		InitializeComponent();
        BindingContext = guestDetailsPageSubTickets;
	}

    public void ReadFile()
    {
        guestDetailsPageSubTickets.ConvertToProductCollection(ID);

    }

    /*private async void OnClickedContinueBtn(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new AddonsPage());
    }*/
}