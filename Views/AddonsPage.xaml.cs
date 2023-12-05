using SK_Airlines_App.ViewModels;
using Microsoft.Maui.Controls;

namespace SK_Airlines_App.Views;


[QueryProperty(nameof(ID), "id")]
public partial class AddonsPage : ContentPage
{
    AddonsPageViewModel guestBookingSummaryPage = new AddonsPageViewModel();
    private string id;
    public string ID
    {
        get { return id; }
        set
        {
            id = value;
            guestBookingSummaryPage.Initialize(ID);
            OnPropertyChanged();
        }
    }

    public AddonsPage()
	{
        InitializeComponent();
		BindingContext = guestBookingSummaryPage;
	}

    private async void OnClickedContinueButton(object sender, EventArgs e)
    {
        // DisplayAlert takes three parameters: Title, Message, and Cancel
        await DisplayAlert("Alert", "Flight Booked", "OK");
        await Navigation.PushAsync(new MainPage());


    }
}