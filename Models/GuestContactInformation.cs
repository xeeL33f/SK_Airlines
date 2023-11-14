using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SK_Airlines_App.Models
{
    public class GuestContactInformation:INotifyPropertyChanged
    {
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }

        public GuestContactInformation(string prefix, string firstName, string lastName, string contactNumber, string email)
        {
            Prefix = prefix;
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            Email = email;
            OnPropertyChanged();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
