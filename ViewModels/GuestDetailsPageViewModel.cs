using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
    internal class GuestDetailsPageViewModel:INotifyPropertyChanged
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

        public ICommand ContinueClickedButton { get; }
        private INavigation navigation;
        public GuestDetailsPageViewModel()
        {

            ContinueClickedButton = new Command(OnClickedContinueButton);
        }

        public async void OnClickedContinueButton()
        {
            ConvertToProductCollection();
            bool IsFoundFirstCondition = false;
            foreach (Register item in registeredUserData)
            {
                foreach (Register item1 in registeredUserData)
                {
                    if (FirstNameEntry == item1.FirstName)
                    {
                        IsFoundFirstCondition = true;
                    }
                }

                if(IsFoundFirstCondition==true && LastNameEntry == item.LastName)
                {
                    ID = item.ID;
                    break;
                }
            }

            
            //navigation.PushAsync(new GuestDetailsPageSubTickets(ID));
            await Shell.Current.GoToAsync($"{nameof(GuestDetailsPageSubTickets)}?id={ID}");
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
