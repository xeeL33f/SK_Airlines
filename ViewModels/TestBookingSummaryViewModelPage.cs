using SK_Airlines_App.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;


namespace SK_Airlines_App.ViewModels;

[QueryProperty(nameof(Price), "price")]

public class TestBookingSummaryViewModelPage : ContentPage
{
    string maindir = FileSystem.Current.AppDataDirectory;

    public ObservableCollection<BookingFlight> bookingCollection = new ObservableCollection<BookingFlight>();

    public ObservableCollection<BookingFlight> BookingCollection
    {
        get { return bookingCollection; }
        set
        {
            bookingCollection = value;
            
            OnPropertyChanged();
        }
    }


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

    
    public TestBookingSummaryViewModelPage()
	{
        ConvertToProductCollection();
        InitializeValues();
    }

    public void InitializeValues()
    {
        BookingFlight BookingFlightObj = new BookingFlight(BookingCollection[0].Origin, BookingCollection[0].Destination, BookingCollection[0].NoAdults, BookingCollection[0].NoChildren, BookingCollection[0].NoInfants,
                               BookingCollection[0].FlightType, BookingCollection[0].DepartureDate, BookingCollection[0].ReturnDate, BookingCollection[0].PromoCode, "0");
        var Origin = BookingCollection[0].Origin;
        OnPropertyChanged();
    }

    public void ConvertToProductCollection()
    {
        string filePath = Path.Combine(maindir, $"FlightBooking.json");

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            BookingCollection = JsonSerializer.Deserialize<ObservableCollection<BookingFlight>>(jsonData);
            OnPropertyChanged();
        }

    }

    
}