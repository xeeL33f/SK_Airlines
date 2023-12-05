using SK_Airlines_App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SK_Airlines_App.Views;

namespace SK_Airlines_App.ViewModels
{
    internal class BookingSummaryViewModel
    {
        string maindir = FileSystem.Current.AppDataDirectory;
        ObservableCollection<Register> registeredUserData = new ObservableCollection<Register>();
        public ObservableCollection<Register> RegisteredUserData
        {
            get { return registeredUserData; }
            set
            {
                registeredUserData = value;
                OnPropertyChanged();
            }
        }
        ObservableCollection<BookingFlight> bookingCollection = new ObservableCollection<BookingFlight>();
        public ObservableCollection<BookingFlight> BookingCollection
        {
            get { return bookingCollection; }
            set
            {
                bookingCollection = value;
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
        
        public string placeholder;
        public string PlaceHolder
        {
            get => placeholder;
            set
            {
                placeholder = value;
                OnPropertyChanged();
            }
        }

        public void Initialize(string id)
        {
            ID = id;
            ReadUserData(ID);
        }

        public void ReadUserData(string ID)
        {
            ConvertToProductCollection();
            foreach (Register item in registeredUserData)
            {
                if(item.ID == ID)
                {
                    

                }
            }
            Display();
        }

        public void ConvertToProductCollection()
        {
            string filePath = Path.Combine(maindir, $"userData.json");
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                registeredUserData = JsonSerializer.Deserialize<ObservableCollection<Register>>(jsonData);
            }
        }

        public void Display()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
