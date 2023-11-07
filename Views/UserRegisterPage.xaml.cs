using SK_Airlines_App.Models;
namespace SK_Airlines_App;

public partial class UserRegisterPage : ContentPage
{
	public UserRegisterPage()
	{
		InitializeComponent();

	}


	private async void OnRegisterClicked(object sender, EventArgs e)
	{
        Register userRegister = new Register(emailAdd.Text, password.Text, firstName.Text, lastName.Text, phoneNum.Text, nickName.Text);

		if(string.IsNullOrEmpty(userRegister.FirstName) || string.IsNullOrEmpty(userRegister.LastName) || string.IsNullOrEmpty(userRegister.Email) || string.IsNullOrEmpty(userRegister.PhoneNum) || string.IsNullOrEmpty(userRegister.Password) || string.IsNullOrEmpty(userRegister.Nickname))
		{
			labelResult.Text = "Please fill up all entries!";
        }
		else 
		{
            await Navigation.PushAsync(new MainPage());
        }
       
	}
}