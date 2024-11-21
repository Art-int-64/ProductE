using MauiApp4.Class;
using System.Net.Mail;
using System.Net;

namespace MauiApp4;

public partial class TwoFactorAuthenticationPage : ContentPage
{
	Profile user = CatalogProfile.ProfileList[CatalogProfile.IdUser];
    int RandomInt { get; set; }
    public TwoFactorAuthenticationPage()
	{
		InitializeComponent();
        Lebel_Email.Text = "Введите код отпраленный на почту:\n" + user.e_mail;
        SendMessege();
	}

    async void SendMessege()
    {
        try
        {
            Random random = new Random();
            RandomInt = random.Next(100, 999);
            MailAddress from = new MailAddress("tesst.tok@mail.ru", "ПродуктЭкспресс");
            MailAddress to = new MailAddress(user.e_mail);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Код подтверждения";
            m.Body = $"<h2>{RandomInt}</h2>";
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.mail.ru");
            smtp.Credentials = new NetworkCredential("tesst.tok@mail.ru", "9sv6r1mn8X8pxhzavyKm");
            smtp.EnableSsl = true;
            smtp.Send(m);
            await DisplayAlert(null, "Письмо успешно отправлено", "ОК");
        }
        catch(Exception ex) 
        {
            await DisplayAlert(null, ex.Message, "ОК");
        }
       

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (Entry_Kod_Email.Text==RandomInt.ToString())
        {
            await Navigation.PushAsync(new NewMainPage());
        }
        else
        {
            await DisplayAlert(null, "Неверный код", "ОК");
        }
    }
}