﻿using CommunityToolkit.Maui.Views;

namespace SK_Airlines_App
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnImageTapped(object sender, TappedEventArgs e)
        {
            string originValue = originEntry.Text;
            string destinationValue = destEntry.Text;

            originEntry.Text = destinationValue;
            destEntry.Text = originValue;
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BookingForm());
 
        }

        private async void OnLabelTapped(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void TapGesureRecognizer_Tapped_ForScaleAnim(object sender, PointerEventArgs e)
        {
            if(sender == placeSample1)
            {
                await placeSample1.ScaleTo(2, 180);
            }
            else if(sender == placeSample2)
            {
                await placeSample2.ScaleTo(2, 180);
            }
            else if (sender == placeSample3)
            {
                await placeSample3.ScaleTo(2, 180);
            }
            else if (sender == placeSample4)
            {
                await placeSample4.ScaleTo(2, 180);
            }
        }

        private async void TapGesureRecognizer_Exited_ForScaleAnim(object sender, PointerEventArgs e)
        {
            if(sender == placeSample1)
            {
                await placeSample1.ScaleTo(1, 175);
            }
            else if(sender == placeSample2)
            {
                await placeSample2.ScaleTo(1, 175);
            }
            else if (sender == placeSample3)
            {
                await placeSample3.ScaleTo(1, 175);
            }
            else if (sender == placeSample4)
            {
                await placeSample4.ScaleTo(1, 175);
            }
        }
    }
}