using SK_Airlines_App.ViewModels;
using SK_Airlines_App.Models;
using System.Collections.ObjectModel;

namespace SK_Airlines_App.Views;

public partial class GuestDetailsPage : ContentPage
{
    GuestDetailsPageViewModel guestDetailsPageViewModel = new GuestDetailsPageViewModel();


    public ObservableCollection<GuestDetails> guestCollection = new ObservableCollection<GuestDetails>();


    public ObservableCollection<GuestDetails> GuestCollection
    {
        get { return guestCollection; }
        set
        {
            guestCollection = value;
            OnPropertyChanged();
        }
    }




    public GuestDetailsPage()
	{
        InitializeComponent();
        CreateDynamicControls(guestDetailsPageViewModel);
        BindingContext = guestDetailsPageViewModel;
    }

    public void CreateDynamicControls(GuestDetailsPageViewModel guestDetailsPageViewModel)
    {
        var adultQuantity = guestDetailsPageViewModel.AdultQuantifier();
        var InfantQuantity = guestDetailsPageViewModel.InfantQuantifier();
        var ChildrenQuantity = guestDetailsPageViewModel.ChildrenQuantifier();

        List<string> pickerItemsPrefix = new List<string>
        {
            "Select",
            "Mr",
            "Mrs",
            "Ms",
        };
        
        List<string> pickerItemsNationality = new List<string>
        {
            "Select",
            "Filipino",
            "American",
            "Bahamian",
            "Cambodian",
        };

        // Create the main StackLayout
        StackLayout mainStackLayout = new StackLayout
        {
            Orientation = StackOrientation.Vertical
        };

        // Create the HorizontalStackLayout
        StackLayout horizontalStackLayout = new StackLayout
        {
            Orientation = StackOrientation.Horizontal
        };

        // Create Labels for HorizontalStackLayout
        Label label1 = new Label
        {
            Padding = new Thickness(10),
            FontSize = 20,
            Text = "Placeholder-Placeholder"
        };

        Label label2 = new Label
        {
            Padding = new Thickness(80, 10, 0, 0),
            FontSize = 20,
            Text = "Book Flight"
        };

        Label label3 = new Label
        {
            Padding = new Thickness(40, 10, 0, 0),
            FontAttributes = FontAttributes.Bold,
            FontSize = 20,
            Text = "Guest Details",
            TextColor = Color.FromArgb("#ff149bcc")
        };

        Label label4 = new Label
        {
            Padding = new Thickness(40, 10, 0, 0),
            FontSize = 20,
            Text = "Add-ons"
        };

        Label label5 = new Label
        {
            Padding = new Thickness(40, 10, 0, 0),
            FontSize = 20,
            Text = "Payment"
        };

        Label label6 = new Label
        {
            Padding = new Thickness(40, 10, 0, 0),
            FontSize = 20,
            Text = "Confirmation"
        };

        // Add Labels to HorizontalStackLayout
        horizontalStackLayout.Children.Add(label1);
        horizontalStackLayout.Children.Add(label2);
        horizontalStackLayout.Children.Add(label3);
        horizontalStackLayout.Children.Add(label4);
        horizontalStackLayout.Children.Add(label5);
        horizontalStackLayout.Children.Add(label6);

        // Add HorizontalStackLayout to the main StackLayout
        mainStackLayout.Children.Add(horizontalStackLayout);

        // Create a StackLayout for the BoxView
        StackLayout boxViewStackLayout = new StackLayout
        {
            Padding = new Thickness(0, 5, 0, 0),
            Orientation = StackOrientation.Horizontal
        };

        // Create the BoxView
        BoxView boxView = new BoxView
        {
            BackgroundColor = Color.FromArgb("#ff000000"),
            HeightRequest = 6,
            HorizontalOptions = LayoutOptions.FillAndExpand
        };

        // Add BoxView to the StackLayout for BoxView
        boxViewStackLayout.Children.Add(boxView);

        // Add the StackLayout for BoxView to the main StackLayout
        mainStackLayout.Children.Add(boxViewStackLayout);

        // Create the Label for "Guest Details"
        Label guestDetailsLabel = new Label
        {
            Padding = new Thickness(10),
            FontAttributes = FontAttributes.Bold,
            FontSize = 30,
            Text = "Guest Details"
        };

        // Add the Label for "Guest Details" to the main StackLayout
        mainStackLayout.Children.Add(guestDetailsLabel);

        StackLayout dynamicControlsStackLayut = new StackLayout
        {
            Padding = new Thickness(0, 5, 0, 0),
            Orientation = StackOrientation.Vertical,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
            Spacing = 5
        };

        StackLayout dynamicControlsStackLayoutHorizontalOptions = new StackLayout
        {
            Padding = new Thickness(0, 5, 0, 0),
            Orientation = StackOrientation.Horizontal,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
            Spacing = 5,
        };

        //generate dynamic controls for adults
        for (int i = 0; i < adultQuantity; i++)
        {
            var stackLayout = new StackLayout();
            Label guestLabel = new Label
            {
                Text = $"Adult {i + 1}",
                FontSize = 20
            };

            Label guestLabelName = new Label
            {
                Text = $"Name",
                FontSize = 12,
            };

            Label guestLabelNameInstructions = new Label
            {
                Text = $"Please make sure that you enter your name as it appears on your passport.",
                FontSize = 12
            };

            Entry guestEntryFirstName = new Entry
            {
                Placeholder = "First Name",
                WidthRequest = 100
            };
            
            Entry guestEntryLastName = new Entry
            {
                Placeholder = "Last Name",
                WidthRequest = 100
            };

            Picker guestPickerPrefix = new Picker
            {
                Title = "Select Prefix",
            };

            foreach (var item in pickerItemsPrefix)
            {
                guestPickerPrefix.Items.Add(item);
            }

            guestPickerPrefix.SelectedIndexChanged += OnPickerSelectedIndexChanged;

            DatePicker guestDatePicker = new DatePicker
            {
                Format = "dd/MM/yyyy",
                MaximumDate = DateTime.Now,
                Date = DateTime.Now,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            Picker guestPickerNationality = new Picker
            {
                Title = "Select Nationality",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            foreach (var item in pickerItemsNationality)
            {
                guestPickerNationality.Items.Add(item);
            }


            guestPickerNationality.SelectedItem = "Select";
            guestPickerPrefix.SelectedItem = "Select";



            //stackLayout.Children.Add(new Label { Text = $"Adult {i + 1}" });
            //stackLayout.Children.Add(new Entry { Placeholder = "First Name" });
            //Content = stackLayout;

            dynamicControlsStackLayut.Children.Add(guestLabel);
            dynamicControlsStackLayut.Children.Add(guestLabelName);
            dynamicControlsStackLayut.Children.Add(guestLabelNameInstructions);
            dynamicControlsStackLayut.Children.Add(guestPickerPrefix);
            dynamicControlsStackLayut.Children.Add(guestEntryFirstName);
            dynamicControlsStackLayut.Children.Add(guestEntryLastName);
            dynamicControlsStackLayut.Children.Add(guestDatePicker);
            dynamicControlsStackLayut.Children.Add(guestPickerNationality);
            //dynamicControlsStackLayut.Children.Add(dynamicControlsStackLayoutHorizontalOptions);
            //dynamicControlsStackLayut.Dispatcher.Dispatch(() => dynamicControlsStackLayut.Children.Add(dynamicControlsStackLayoutHorizontalOptions));
            //saving to the collection
            GuestDetails GuestInfo = new GuestDetails(guestPickerPrefix.SelectedItem.ToString(), guestEntryFirstName.Text,
                guestEntryLastName.Text, guestDatePicker.Date.ToString("dd/MM/yyyy"), guestPickerNationality.SelectedItem.ToString());

            GuestCollection.Add(GuestInfo);
        }
        //mainStackLayout.Children.Add(dynamicControlsStackLayut);

        //generate dynamic controls for children
        for (int i = 0; i < ChildrenQuantity; i++)
        {
            var stackLayout = new StackLayout();
            Label guestLabel = new Label
            {
                Text = $"Child {i + 1}",
                FontSize = 20
            };

            Label guestLabelName = new Label
            {
                Text = $"Name",
                FontSize = 12,
            };

            Label guestLabelNameInstructions = new Label
            {
                Text = $"Please make sure that you enter your name as it appears on your passport.",
                FontSize = 12
            };

            Entry guestEntryFirstName = new Entry
            {
                Placeholder = "First Name",
                WidthRequest = 100
            };

            Entry guestEntryLastName = new Entry
            {
                Placeholder = "Last Name",
                WidthRequest = 100
            };

            Picker guestPickerPrefix = new Picker
            {
                Title = "Select Prefix",
            };

            foreach (var item in pickerItemsPrefix)
            {
                guestPickerPrefix.Items.Add(item);
            }

            guestPickerPrefix.SelectedIndexChanged += OnPickerSelectedIndexChanged;

            DatePicker guestDatePicker = new DatePicker
            {
                Format = "dd/MM/yyyy",
                MaximumDate = DateTime.Now,
                Date = DateTime.Now,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            Picker guestPickerNationality = new Picker
            {
                Title = "Select Nationality",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            foreach (var item in pickerItemsNationality)
            {
                guestPickerNationality.Items.Add(item);
            }

            /*GuestDetails GuestInfo = new GuestDetails(guestPickerPrefix.SelectedItem.ToString(), guestEntryFirstName.Text,
                guestEntryLastName.Text, guestDatePicker.Date.ToString("dd/MM/yyyy"), guestPickerNationality.SelectedItem.ToString());

            GuestCollection.Add(GuestInfo);*/
            //stackLayout.Children.Add(new Label { Text = $"Adult {i + 1}" });
            //stackLayout.Children.Add(new Entry { Placeholder = "First Name" });
            //Content = stackLayout;

            dynamicControlsStackLayut.Children.Add(guestLabel);
            dynamicControlsStackLayut.Children.Add(guestLabelName);
            dynamicControlsStackLayut.Children.Add(guestLabelNameInstructions);
            dynamicControlsStackLayut.Children.Add(guestPickerPrefix);
            dynamicControlsStackLayut.Children.Add(guestEntryFirstName);
            dynamicControlsStackLayut.Children.Add(guestEntryLastName);
            dynamicControlsStackLayut.Children.Add(guestDatePicker);
            dynamicControlsStackLayut.Children.Add(guestPickerNationality);
            //dynamicControlsStackLayut.Children.Add(dynamicControlsStackLayoutHorizontalOptions);
            //dynamicControlsStackLayut.Dispatcher.Dispatch(() => dynamicControlsStackLayut.Children.Add(dynamicControlsStackLayoutHorizontalOptions));
            SaveAdminGuestInfo(guestPickerPrefix,guestEntryFirstName, guestEntryLastName, guestDatePicker, guestPickerNationality); 
        }
        //mainStackLayout.Children.Add(dynamicControlsStackLayut);


        //generate dynamic controls for infants
        for (int i = 0; i < InfantQuantity; i++)
        {
            var stackLayout = new StackLayout();
            Label guestLabel = new Label
            {
                Text = $"Infant {i + 1}",
                FontSize = 20
            };

            Label guestLabelName = new Label
            {
                Text = $"Name",
                FontSize = 12,
            };

            Label guestLabelNameInstructions = new Label
            {
                Text = $"Please make sure that you enter your name as it appears on your passport.",
                FontSize = 12
            };

            Entry guestEntryFirstName = new Entry
            {
                Placeholder = "First Name",
                WidthRequest = 100
            };

            Entry guestEntryLastName = new Entry
            {
                Placeholder = "Last Name",
                WidthRequest = 100
            };

            Picker guestPickerPrefix = new Picker
            {
                Title = "Select Prefix",
            };

            foreach (var item in pickerItemsPrefix)
            {
                guestPickerPrefix.Items.Add(item);
            }

            guestPickerPrefix.SelectedIndexChanged += OnPickerSelectedIndexChanged;

            DatePicker guestDatePicker = new DatePicker
            {
                Format = "dd/MM/yyyy",
                MaximumDate = DateTime.Now,
                Date = DateTime.Now,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            Picker guestPickerNationality = new Picker
            {
                Title = "Select Nationality",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            foreach (var item in pickerItemsNationality)
            {
                guestPickerNationality.Items.Add(item);
            }

            GuestDetails GuestInfo = new GuestDetails(guestPickerPrefix.SelectedItem.ToString(), guestEntryFirstName.Text,
                guestEntryLastName.Text, guestDatePicker.Date.ToString("dd/MM/yyyy"), guestPickerNationality.SelectedItem.ToString());

            GuestCollection.Add(GuestInfo);

            //stackLayout.Children.Add(new Label { Text = $"Adult {i + 1}" });
            //stackLayout.Children.Add(new Entry { Placeholder = "First Name" });
            //Content = stackLayout;

            dynamicControlsStackLayut.Children.Add(guestLabel);
            dynamicControlsStackLayut.Children.Add(guestLabelName);
            dynamicControlsStackLayut.Children.Add(guestLabelNameInstructions);
            dynamicControlsStackLayut.Children.Add(guestPickerPrefix);
            dynamicControlsStackLayut.Children.Add(guestEntryFirstName);
            dynamicControlsStackLayut.Children.Add(guestEntryLastName);
            dynamicControlsStackLayut.Children.Add(guestDatePicker);
            dynamicControlsStackLayut.Children.Add(guestPickerNationality);
            //dynamicControlsStackLayut.Children.Add(dynamicControlsStackLayoutHorizontalOptions);
            //dynamicControlsStackLayut.Dispatcher.Dispatch(() => dynamicControlsStackLayut.Children.Add(dynamicControlsStackLayoutHorizontalOptions));
        }
        mainStackLayout.Children.Add(dynamicControlsStackLayut);


        // Create the Label for "Guest Details"
        Label guestContactInformation = new Label
        {
            Padding = new Thickness(10),
            FontAttributes = FontAttributes.Bold,
            FontSize = 30,
            Text = "Guest Contact Information"
        };

        Picker guestPickerPrefixContactInformation = new Picker
        {
            Title = "Select Prefix",
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
        };

        foreach (var item in pickerItemsPrefix)
        {
            guestPickerPrefixContactInformation.Items.Add(item);
        }

        guestPickerPrefixContactInformation.SelectedIndexChanged += OnPickerSelectedIndexChanged;


        Entry guestEntryFirstNameContactInformation = new Entry
        {
            Placeholder = "First Name",
            WidthRequest = 100
        };

        Entry guestEntryLastNameContactInformation = new Entry
        {
            Placeholder = "Last Name",
            WidthRequest = 100
        };

        Entry guestContactNumber = new Entry
        {
            Placeholder = "Contact Number",
            WidthRequest = 100
        };

        Entry guestEmail = new Entry
        {
            Placeholder = "Email",
            WidthRequest = 100
        };

        Button GuestSubmitButtonIsClicked = new Button
        {
            Text = "Submit",
            WidthRequest= 100,
        };


        // Add the Label for "Guest Details" to the main StackLayout
        mainStackLayout.Children.Add(guestContactInformation);
        mainStackLayout.Children.Add(guestPickerPrefixContactInformation);
        mainStackLayout.Children.Add(guestEntryFirstNameContactInformation);
        mainStackLayout.Children.Add(guestEntryLastNameContactInformation);
        mainStackLayout.Children.Add(guestContactNumber);
        mainStackLayout.Children.Add(guestEmail);
        mainStackLayout.Children.Add(GuestSubmitButtonIsClicked);


        ScrollView scrollView = new ScrollView
        {
            Content = mainStackLayout
        };

        // Set the main StackLayout as the content of the page
        Content = scrollView;

        //Save to a ObservableCollection
        
    }

    private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        // Handle the selected index change event here
        Picker picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            string selectedOption = picker.Items[selectedIndex];
            // Do something with the selected option
            //DisplayAlert("Selected Option", selectedOption, "OK");
        }
    }

    public void SaveAdminGuestInfo(Picker guestPickerPrefix, Entry guestEntryFirstName, Entry guestEntryLastName, DatePicker guestDatePicker, Picker guestPickerNationality)
    {
        GuestDetails GuestInfo = new GuestDetails(guestPickerPrefix.SelectedItem.ToString(), guestEntryFirstName.Text,
                           guestEntryLastName.Text, guestDatePicker.Date.ToString("dd/MM/yyyy"), guestPickerNationality.SelectedItem.ToString());

        GuestCollection.Add(GuestInfo);
    }

    private void GuestSubmitButtonIsClicked(object sender, EventArgs e)
    {
        var adultQuantity = guestDetailsPageViewModel.AdultQuantifier();
        var InfantQuantity = guestDetailsPageViewModel.InfantQuantifier();
        var ChildrenQuantity = guestDetailsPageViewModel.ChildrenQuantifier();


    }
}