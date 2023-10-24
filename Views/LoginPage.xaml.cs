namespace SK_Airlines_App;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	private async void OnLabelClicked(object sender, TappedEventArgs e)
	{
		if(sender == label_Register)
		{
            await Navigation.PushAsync(new Admin());
        }
		else if(sender == label_Login)
		{
			await Navigation.PushAsync(new AdminLoginPage());
		}
        else if (sender == label_UserRegister)
        {
            await Navigation.PushAsync(new UserRegisterPage());
        }
    }

	private async void OnButtonClicked(object sender, EventArgs e)
	{
		if (email.Text == "user@email.com" && pass.Text == "password123")
		{
			await Navigation.PushAsync (new NewLandingPage());
		}
		else
		{
			labelValidation.Text = "User and Password are incorrect!";
		}
	}
}