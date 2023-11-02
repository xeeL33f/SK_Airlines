using System;
using SK_Airlines_App.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SK_Airlines_App.ViewModel
{
    internal class BookSummaryViewModel
    {
        string maindir = FileSystem.Current.AppDataDirectory;
        public ObservableCollection<BookingFlight> bookingCollection = new ObservableCollection<BookingFlight>();

        public ObservableCollection<BookingFlight> BookingCollection
        {
            get { return bookingCollection; }
            set
            {
                bookingCollection = value;
                ConvertToProductCollection();
                InitializeValues();
                OnPropertyChanged();
            }
        }

        public void InitializeValues()
        {
            BookingFlight BookingFlightObj = new BookingFlight(BookingCollection[0].Origin, BookingCollection[0].Destination, BookingCollection[0].NoAdults, BookingCollection[0].NoChildren, BookingCollection[0].NoInfants,
                        BookingCollection[0].FlightType, BookingCollection[0].DepartureDate, BookingCollection[0].ReturnDate, BookingCollection[0].PromoCode, "0");

        }

        public void ConvertToProductCollection()
        {
            string filePath = Path.Combine(maindir, $"FlightBooking.json");

            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                BookingCollection = JsonSerializer.Deserialize<ObservableCollection<BookingFlight>>(jsonData);
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
