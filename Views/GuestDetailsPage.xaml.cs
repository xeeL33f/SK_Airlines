using SK_Airlines_App.ViewModels;

namespace SK_Airlines_App.Views;

public partial class GuestDetailsPage : ContentPage
{
    GuestDetailsPageViewModel guestDetailsPageViewModel = new GuestDetailsPageViewModel();

    public GuestDetailsPage()
	{
        InitializeComponent();
        CreateDynamicControls(guestDetailsPageViewModel);
        BindingContext = guestDetailsPageViewModel;
    }

    public void CreateDynamicControls(GuestDetailsPageViewModel guestDetailsPageViewModel)
    {
        var adultQuantity = guestDetailsPageViewModel.AdultQuantifier();
        var InfantQuantity = guestDetailsPageViewModel.InfantQuantifier();
        var ChildrenQuantity = guestDetailsPageViewModel.ChildrenQuantifier();

        for (int i = 0; i < adultQuantity; i++)
        {
            var stackLayout = new StackLayout();
            stackLayout.Children.Add(new Label { Text = $"Adult {i+1}" });
            stackLayout.Children.Add(new Entry { Placeholder = "First Name" });
            Content = stackLayout;
        }
    }
}