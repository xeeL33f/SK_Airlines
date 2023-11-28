using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using SK_Airlines_App.Views;
using SK_Airlines_App.Models;
using System.Windows.Input;


namespace SK_Airlines_App.ViewModels
{

    internal class GuestDetailsPageSubTicketsViewModel : INotifyPropertyChanged
    {

        int globalAdultsInt = 0;
        int globalChildrenInt = 0;
        int globalInfantInt = 0;
        string maindir = FileSystem.Current.AppDataDirectory;
        public ObservableCollection<BookingFlight> bookingCollection = new ObservableCollection<BookingFlight>();
        public ObservableCollection<BookingFlight> BookingCollections
        {
            get
            {
                return bookingCollection;
            }
            set
            {
                bookingCollection = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<GuestDetailModel> guestDetailsCollection = new ObservableCollection<GuestDetailModel>();
        public ObservableCollection<GuestDetailModel> GuestDetailsCollections
        {
            get
            {
                return guestDetailsCollection;
            }
            set
            {
                guestDetailsCollection = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<GuestDetailModel> guestToBeAddedCollection = new ObservableCollection<GuestDetailModel>();
        public ObservableCollection<GuestDetailModel> GuestToBeAddedCollection
        {
            get
            {
                return guestToBeAddedCollection;
            }
            set
            {
                guestToBeAddedCollection = value;
                OnPropertyChanged();
            }
        }

        private string labelText;

        public string LabelText
        {
            get => labelText;
            set
            {
                labelText = value;
                OnPropertyChanged();
            }
        }

        private string firstnameEntry;

        public string FirstNameEntry
        {
            get => firstnameEntry;
            set
            {
                firstnameEntry = value;

                OnPropertyChanged();
            }
        }

        public string lastnameEntry;
        public string LastNameEntry
        {
            get => lastnameEntry;
            set
            {
                lastnameEntry = value;

                OnPropertyChanged();
            }
        }

        public string nationalityEntry;
        public string NationalityEntry
        {
            get => nationalityEntry;
            set
            {
                nationalityEntry = value;

                OnPropertyChanged();
            }
        }

        public DateTime dateOfBirthPck;
        public DateTime DateOfBirthPck
        {
            get => dateOfBirthPck;
            set
            {
                dateOfBirthPck = value;

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
                Initialize(id);
            }
        }

        public ICommand SubmitButtonCommand
        {
            get;
        }
        public ICommand ClearAllCommand
        {
            get;
        }

        public GuestDetailsPageSubTicketsViewModel()
        {
            SubmitButtonCommand = new Command(SubmitButton);
        }

        public void Initialize(string id)
        {
            //ConvertToProductCollection();
            BookingFlight lastEntryBookingFlight = BookingCollections.Last();
            int adultsInt = Int32.Parse(lastEntryBookingFlight.NoAdults);
            var number = ((adultsInt - adultsInt) + 1);
            LabelText = $"Adult {number}";
            globalAdultsInt++;
            int infantsInt = Int32.Parse(lastEntryBookingFlight.NoInfants);
            int childrenInt = Int32.Parse(lastEntryBookingFlight.NoChildren);
        }

        public void SubmitButton()
        {
            //ConvertToProductCollection();
            BookingFlight lastEntryBookingFlight = BookingCollections.Last();
            int adultsInt = Int32.Parse(lastEntryBookingFlight.NoAdults);
            int infantsInt = Int32.Parse(lastEntryBookingFlight.NoInfants);
            int childrenInt = Int32.Parse(lastEntryBookingFlight.NoChildren);
            if (globalAdultsInt != adultsInt)
            {
                GuestDetailModel GuestDetailsCollections = new GuestDetailModel(FirstNameEntry, LastNameEntry, DateOfBirthPck, NationalityEntry);
                GuestToBeAddedCollection.Add(GuestDetailsCollections);
                AddToFile(GuestToBeAddedCollection);


                FirstNameEntry = string.Empty;
                LastNameEntry = string.Empty;
                NationalityEntry = string.Empty;
                globalAdultsInt++;
                LabelText = $"Adult {globalAdultsInt}";
            }
            else if (globalChildrenInt != childrenInt)
            {
                GuestDetailModel GuestDetailsCollections = new GuestDetailModel(FirstNameEntry, LastNameEntry, DateOfBirthPck, NationalityEntry);
                GuestToBeAddedCollection.Add(GuestDetailsCollections);
                AddToFile(GuestToBeAddedCollection);


                FirstNameEntry = string.Empty;
                LastNameEntry = string.Empty;
                NationalityEntry = string.Empty;
                globalChildrenInt++;
                LabelText = $"Child {globalChildrenInt}";

            }
            else if (globalInfantInt != infantsInt)
            {
                GuestDetailModel GuestDetailsCollections = new GuestDetailModel(FirstNameEntry, LastNameEntry, DateOfBirthPck, NationalityEntry);
                GuestToBeAddedCollection.Add(GuestDetailsCollections);
                AddToFile(GuestToBeAddedCollection);


                FirstNameEntry = string.Empty;
                LastNameEntry = string.Empty;
                NationalityEntry = string.Empty;
                globalInfantInt++;
                LabelText = $"Infant {globalInfantInt}";

            }

        }
        public void AddToFile(ObservableCollection<GuestDetailModel>beepbbop)
        {
            string filePath = Path.Combine(maindir, $"userDataTicketDatabase[{ID}].json");

            var json = string.Empty;
            json = JsonSerializer.Serialize(beepbbop);

            File.WriteAllText(filePath, json);
        }

        public void ConvertToProductCollection(string id)
        {
             string filePath = Path.Combine(maindir, $"FlightBooking.json");
            string filePath1 = Path.Combine(maindir, $"userDataTicketDatabase[{id}].json");
            if (File.Exists(filePath1))
            {
                string jsonData = File.ReadAllText(filePath);
                string jsonData1 = File.ReadAllText(filePath1);
                BookingCollections = JsonSerializer.Deserialize<ObservableCollection<BookingFlight>>(jsonData);
                GuestToBeAddedCollection = JsonSerializer.Deserialize<ObservableCollection<GuestDetailModel>>(jsonData1);
                ID = id;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}