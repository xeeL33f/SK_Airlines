using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SK_Airlines_App.Models;

namespace SK_Airlines_App.ViewModels
{

        public class GuestDetailsPageViewModel
        {
            public int index = 0;
            public ObservableCollection<GuestDetails> Items { get; set; }

            public ICommand AddItemCommand => new Command(addItemMethod);

            private void addItemMethod(object obj)
            {
                index++;
                Items.Add(new GuestDetails { FirstName = "" , LastName = "" });
            }


            public GuestDetailsPageViewModel()
            {
                Items = new ObservableCollection<GuestDetails>();
            }

        }
    
}
