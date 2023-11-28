using SK_Airlines_App.Models;
using SK_Airlines_App.ViewModels;

namespace SK_Airlines_App.Views;

public partial class GuestDetailsPage : ContentPage
{
	GuestDetailsPageViewModel guestDetailsPageViewModel = new GuestDetailsPageViewModel();
	public GuestDetailsPage()
	{
		InitializeComponent();
		BindingContext = guestDetailsPageViewModel;
	}




}
