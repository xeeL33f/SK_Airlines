using SK_Airlines_App.ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SK_Airlines_App.Views;

[QueryProperty(nameof(ID), "id")]
public partial class TestBookingSummary : ContentPage
{
    TestBookingSummaryViewModelPage testBookingSummaryViewModelPage = new TestBookingSummaryViewModelPage();
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

    public string id;
    public string ID
    {
        get => id;
        set
        {
            id = value;
            OnPropertyChanged();
        }
    }

    public TestBookingSummary()
	{
		InitializeComponent();
        BindingContext = testBookingSummaryViewModelPage;
    }



    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}