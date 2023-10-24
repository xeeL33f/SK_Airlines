namespace SK_Airlines_App;

public partial class AdminLoginPage : ContentPage
{
	public AdminLoginPage()
	{
		InitializeComponent();
	}

	private async void OnButtonClicked(object sender, EventArgs e)
	{
		if(emailAdmin.Text != "admin@email.com" && passAdmin.Text != "admin123")
		{
			labelAdminValidate.Text = "Incorrect email and password!";
		}
		else if(emailAdmin.Text == "admin@email.com" && passAdmin.Text == "admin123")
		{
			await Navigation.PushAsync(new Admin());
		}
	}
}