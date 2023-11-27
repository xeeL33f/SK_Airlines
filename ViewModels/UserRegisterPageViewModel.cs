using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SK_Airlines_App.Models;

namespace SK_Airlines_App.ViewModels
{
    internal class UserRegisterPageViewModel
    {
        string maindir = FileSystem.Current.AppDataDirectory;
        public ObservableCollection<Register> userCollections = new ObservableCollection<Register>();

        public ObservableCollection<Register> UserCollections
        {
            get { return userCollections; }
            set
            {
                userCollections = value;
                OnPropertyChanged();
            }
        }

        public UserRegisterPageViewModel()
        {
            
        }

        public void RegisterUser(string email, string password, string firstName, string lastName, string phoneNum, string nickName, string id)
        {
            var idNo = FileExist();
            ConvertToProductCollection(idNo);
            Register userRegister = new Register(email, password, firstName, lastName, phoneNum, nickName, idNo);
            userCollections.Add(userRegister);
            AddToFile(idNo);
        }

        public string FileExist()
        {
            for(var i=1;i!=0;i++)
            {
                string filePath = Path.Combine(maindir, $"userData[{i}].json");
                var jsonData = JsonSerializer.Serialize(UserCollections);
                if (!File.Exists(filePath))
                {
                    UserCollections.Clear();
                    File.WriteAllText(filePath, jsonData);
                    return i.ToString();
                }
            }
            //test
            return "99";
        }

        public void ConvertToProductCollection(string id)
        {
            string filePath = Path.Combine(maindir, $"userData[{id}].json");
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                UserCollections = JsonSerializer.Deserialize<ObservableCollection<Register>>(jsonData);
            }
        }

        public void AddToFile(string id)
        {
            string filePath = Path.Combine(maindir, $"userData[{id}].json");

            var json = string.Empty;
            json = JsonSerializer.Serialize(UserCollections);

            File.WriteAllText(filePath, json);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
