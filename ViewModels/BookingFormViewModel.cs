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
    internal class BookingFormViewModel
    {
        string maindir = FileSystem.Current.AppDataDirectory;
        public ObservableCollection<BookingFlight> bookingCollection = new ObservableCollection<BookingFlight>();

        public ObservableCollection<BookingFlight> BookingCollections
        {
            get { return bookingCollection; }
            set
            {
                bookingCollection = value;
                OnPropertyChanged();
            }
        }

        public BookingFormViewModel()
        {
            FileExist();
            ConvertToProductCollection();
        }

        //unknown code
        /*
        public void SearchFlight(BookingFlight BookingFlightObject)
        {
            //BookingCollections.Add(BookingFlightObject);
            AddToFile();
        }*/

        public void GetInfo(string origin, string destination, string adultQuantity, string childrenQuantity, string infantQuantity,
            string flightType,string departureDate,string returnDate,string promoCode,string travelClass)
        {
            BookingFlight BookingInfo = new BookingFlight(origin, destination, adultQuantity, childrenQuantity, infantQuantity,
                flightType, departureDate, returnDate, promoCode, travelClass);

            BookingCollections.Add(BookingInfo);

            AddToFile();
        }

        public void AddToFile()
        {
            string filePath = Path.Combine(maindir, $"FlightBooking.json");

            var json = string.Empty;
            json = JsonSerializer.Serialize(BookingCollections);

            File.WriteAllText(filePath, json);
        }

        public void FileExist()
        {
            string filePath = Path.Combine(maindir, $"FlightBooking.json");
            var jsonData = JsonSerializer.Serialize(BookingCollections);
            if (!File.Exists(filePath))
            {
                BookingCollections.Clear();

                File.WriteAllText(filePath, jsonData);
            }
        }

        public void ConvertToProductCollection()
        {
            string filePath = Path.Combine(maindir, $"FlightBooking.json");
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                BookingCollections = JsonSerializer.Deserialize<ObservableCollection<BookingFlight>>(jsonData);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
