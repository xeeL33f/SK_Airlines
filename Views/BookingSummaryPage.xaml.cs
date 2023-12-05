using SK_Airlines_App.ViewModels;

namespace SK_Airlines_App.Views;

[QueryProperty(nameof(ID), "id")]
public partial class BookingSummaryPage : ContentPage
{
    BookingSummaryViewModel guestBookingSummaryPage = new BookingSummaryViewModel();
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
    public BookingSummaryPage()
	{
		InitializeComponent();
        BindingContext = guestBookingSummaryPage;
	}
}