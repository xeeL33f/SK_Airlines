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
using SK_Airlines_App.Views;

namespace SK_Airlines_App.ViewModels
{
    
    internal class AddonsPageViewModel
    {
        ObservableCollection<Addons> addons = new ObservableCollection<Addons>();
        public ObservableCollection<Addons> Addons
        {
            get { return addons; }
            set
            {
                addons = value;
                OnPropertyChanged();
            }
        }
        string maindir = FileSystem.Current.AppDataDirectory;
        private bool baggageCheckbox;
        public bool BaggageCheckbox
        {
            get => baggageCheckbox;
            set
            {
                baggageCheckbox = value;
                OnPropertyChanged();
            }
        }

        private bool seatCheckbox;
        public bool SeatCheckBox
        {
            get => seatCheckbox;
            set
            {
                seatCheckbox = value;
                OnPropertyChanged();
            }
        }

        private bool mealCheckbox;
        public bool MealCheckBox
        {
            get => mealCheckbox;
            set
            {
                mealCheckbox = value;
                OnPropertyChanged();
            }
        }

        private bool insuranceCheckBox;
        public bool InsuranceCheckBox
        {
            get => insuranceCheckBox;
            set
            {
                insuranceCheckBox = value;
                OnPropertyChanged();
            }
        }

        private bool transportCheckBox;
        public bool TransportCheckBox
        {
            get => transportCheckBox;
            set
            {
                transportCheckBox = value;
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

        public ICommand ContinueButton { get; }

        public AddonsPageViewModel()
        {
            //ContinueButton = new Command(OnClickedContinueButton);
        }

        public void Initialize(string id)
        {
            ID = id;
        }

        
        /*public void OnClickedContinueButton()
        {
            Addons AddonsCollection = new Addons(BaggageCheckbox,SeatCheckBox,MealCheckBox,
                InsuranceCheckBox, TransportCheckBox);
            AddToFile(AddonsCollection);
            NextPage();
        }

        public void AddToFile(Addons AddonsCollection)
        {
            string filePath = Path.Combine(maindir, $"userDataTicketDatabaseAddons[{ID}].json");

            var json = string.Empty;
            json = JsonSerializer.Serialize(AddonsCollection);

            File.WriteAllText(filePath, json);
        }

        public async void NextPage()
        {
            //await Shell.Current.GoToAsync($"{nameof(BookingSummaryPage)}?id={ID}");
        }
        */
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
