using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace SK_Airlines_App.Models
{
    public class BookingFlight : INotifyPropertyChanged
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string NoAdults { get; set; }
        public string NoChildren { get; set; }
        public string NoInfants { get; set; }
        public string FlightType { get; set; }
        public string DepartureDate { get; set; }

        public string ReturnDate { get; set; }
        public string PromoCode { get; set; }
        public int TravelClass { get; set; }

        public BookingFlight(string origin, string destination, string noAdults, string noChildren,
            string noInfants, string flightType, string departureDate, string returnDate, string promoCode
            , int travelClass)
        {
            Origin = origin;
            Destination = destination;
            NoAdults = noAdults;
            NoChildren = noChildren;
            NoInfants = noInfants;
            FlightType = flightType;
            DepartureDate = departureDate;
            ReturnDate = returnDate;
            PromoCode = promoCode;
            TravelClass = travelClass;
            OnPropertyChanged();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
