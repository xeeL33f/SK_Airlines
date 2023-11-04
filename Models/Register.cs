using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SK_Airlines_App.Models
{
    class Register:INotifyPropertyChanged
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNum { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;

        public Register(string email, string password, string firstName, string lastName, string phoneNum, string nickName)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            PhoneNum = phoneNum;
            Nickname = nickName;
            OnPropertyChanged();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
