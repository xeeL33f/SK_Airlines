﻿using SK_Airlines_App.Views;

namespace SK_Airlines_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}