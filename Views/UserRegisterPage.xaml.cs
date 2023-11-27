using SK_Airlines_App.Models;
using SK_Airlines_App.ViewModels;

namespace SK_Airlines_App;

public partial class UserRegisterPage : ContentPage
{
	UserRegisterPageViewModel userRegisterPageViewMode = new UserRegisterPageViewModel();

	public UserRegisterPage()
	{
		InitializeComponent();
		BindingContext = userRegisterPageViewMode;
	}


	private async void OnRegisterClicked(object sender, EventArgs e)
	{
        Register userRegister = new Register(emailAdd.Text, password.Text, firstName.Text, lastName.Text, phoneNum.Text, nickName.Text,null);

		if(string.IsNullOrEmpty(userRegister.FirstName) || string.IsNullOrEmpty(userRegister.LastName) || string.IsNullOrEmpty(userRegister.Email) || string.IsNullOrEmpty(userRegister.PhoneNum) || string.IsNullOrEmpty(userRegister.Password) || string.IsNullOrEmpty(userRegister.Nickname))
		{
			labelResult.Text = "Please fill up all entries!";
        }
		else 
		{
            userRegisterPageViewMode.RegisterUser(userRegister.Email, userRegister.Password, userRegister.FirstName, userRegister.LastName, userRegister.PhoneNum, userRegister.Nickname, null);
            await Navigation.PushAsync(new MainPage());
        }
       
	}
}