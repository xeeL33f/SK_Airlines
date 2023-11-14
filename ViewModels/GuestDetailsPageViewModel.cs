using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using SK_Airlines_App.Models;

namespace SK_Airlines_App.ViewModels
{

    public class GuestDetailsPageViewModel
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

        public ObservableCollection<GuestDetails> guestDetailsCollection = new ObservableCollection<GuestDetails>();

        public ObservableCollection<GuestDetails> GuestDetailsCollection
        {
            get { return guestDetailsCollection; }
            set
            {
                guestDetailsCollection = value;
                OnPropertyChanged();
            }
        }
        
        public ObservableCollection<GuestDetails> guestContactInformation = new ObservableCollection<GuestDetails>();

        public ObservableCollection<GuestDetails> GuestContactInformation
        {
            get { return guestContactInformation; }
            set
            {
                guestContactInformation = value;
                OnPropertyChanged();
            }
        }

        public BookingFlight LastItem
        {
            get
            {
                if (BookingCollections.Count > 0)
                {
                    return BookingCollections[BookingCollections.Count - 1];
                }
                return null; // Handle the case when the collection is empty
            }
        }

        public GuestDetailsPageViewModel()
        {
            ConvertToProductCollection();
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

        public int AdultQuantifier()
        {
            var adultQuantity = Int32.Parse(LastItem.NoAdults);
            return adultQuantity;
        }

        public int InfantQuantifier()
        {
            var infantQuantity = Int32.Parse(LastItem.NoInfants);
            return infantQuantity;
        }

        public int ChildrenQuantifier()
        {
            var childrenQuantity = Int32.Parse(LastItem.NoChildren);
            return childrenQuantity;
        }

        public void GuestTicketSave()
        {
            
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
