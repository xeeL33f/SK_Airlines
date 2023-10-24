namespace SK_Airlines_App;

public partial class Admin : ContentPage
{
	public Admin()
	{
		InitializeComponent();
	}

	//**Validation Code**
	private async void OnRegisterButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new AdminPage());
	}
}