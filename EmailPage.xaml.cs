using MauiApp4.Class;

namespace MauiApp4;

public partial class EmailPage : ContentPage
{
	string Email { get; set; }
	string Password { get; set; }
	string Login { get; set; }
	string Phone { get; set; }
	public EmailPage(string email,string password,string login,string phone)
	{
		InitializeComponent();
		Email = email;
		Password = password;
		Login = login;
		Phone = phone;
		Lebel_Email.Text = "Введите код отпраленный на почту "+Email;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (Entry_Kod_Email.Text==CatalogProfile.KodEmail.ToString())
        {
            CatalogProfile.ProfileList.Add(new Profile(Login,Password,Phone,Email, "img_408797_1.png"));
			Navigation.PushAsync(new MainPage());
        }
        else
        {
			DisplayAlert("", "Неверный код","ОК");
        }
    }
}