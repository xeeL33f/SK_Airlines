using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SK_Airlines_App.Models
{
    internal class Addons:INotifyPropertyChanged
    {
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
        public bool SeatCheckbox
        {
            get => seatCheckbox;
            set
            {
                seatCheckbox = value;
                OnPropertyChanged();
            }
        }

        private bool mealCheckbox;
        public bool MealCheckbox
        {
            get => mealCheckbox;
            set
            {
                mealCheckbox = value;
                OnPropertyChanged();
            }
        }

        private bool insuranceCheckbox;
        public bool InsuranceCheckbox
        {
            get => insuranceCheckbox;
            set
            {
                insuranceCheckbox = value;
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

        public Addons(bool baggageCheckbox,bool seatCheckbox,bool mealCheckbox,
            bool insuranceCheckbox,bool transportCheckbox)
        {
            BaggageCheckbox=baggageCheckbox;
            SeatCheckbox=seatCheckbox;
            MealCheckbox=mealCheckbox;
            InsuranceCheckbox=insuranceCheckbox;
            TransportCheckBox=transportCheckbox;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
