using MauiApp4.Class;
using System.Net.Mail;
using System.Net;
using Microsoft.Maui.Controls;
using System.Text.RegularExpressions;
namespace MauiApp4;

public partial class PageRegistr : ContentPage
{
	public PageRegistr()
	{
		InitializeComponent();
	}



    async void SendMessege()
    {
        Random random = new Random();
        int RandomInt = random.Next(100,999);
        CatalogProfile.KodEmail = RandomInt;
        MailAddress from = new MailAddress("tesst.tok@mail.ru", "ПродуктЭкспресс");
        MailAddress to = new MailAddress(Add_Entry_Email.Text);
        MailMessage m = new MailMessage(from, to);
        m.Subject = "Код подтверждения";
        m.Body = $"<h2>{CatalogProfile.KodEmail}</h2>";
        m.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient("smtp.mail.ru");
        smtp.Credentials = new NetworkCredential("tesst.tok@mail.ru", "9sv6r1mn8X8pxhzavyKm");
        smtp.EnableSsl = true;
        smtp.Send(m);
        await DisplayAlert(null, "Письмо успешно отправлено", "ОК");
     
    }
    private  bool Validation(bool result)
    {
        if (!Add_Entry_Email.Text.Contains('a') || !Add_Entry_Email.Text.Contains('.'))
        {
            Add_Entry_Email.Placeholder = "Неправильно введена электронная почта";
            Add_Entry_Email.Text = null;
            result = false;
        }
        if (Add_Entry_Password.Text.Length < 6)
        {
            Add_Entry_Password.Placeholder = "Пароль не должен быть короче 6 символов";
            Add_Entry_Password.Text = null;
            result = false;
        }
        if (Add_Entry_Loginn.Text.Length < 5 )
        {
            Add_Entry_Loginn.Placeholder = "Логин не должен быть короче 5 символов";
            Add_Entry_Loginn.Text = null;
            result = false;
        }
        
        return result;
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            bool result=true;
            if (Add_Entry_Email.Text == null || Add_Entry_Loginn.Text == null || Add_Entry_Password.Text == null || Add_Entry_Phone.Text == null)
            {
               await DisplayAlert("", "Все поля для ввода должны быть заполнены","ОК");
                result = false;

            }
            else
            {
                Validation(result);
            }
            if (result)
            {
                SendMessege();
                await Navigation.PushAsync(new EmailPage(Add_Entry_Email.Text, Add_Entry_Password.Text, Add_Entry_Loginn.Text, Add_Entry_Phone.Text));
            }

        }
        catch (Exception ex)
        {
           await DisplayAlert("", ex.Message, "ОК");
        }

    }

}