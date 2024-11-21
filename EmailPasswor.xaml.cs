using MauiApp4.Class;
using System.Net.Mail;
using System.Net;

namespace MauiApp4;

public partial class EmailPasswor : ContentPage
{
    public EmailPasswor()
	{
        InitializeComponent();
    }

    void SendMessege()
    {
        var  ProfEmail = CatalogProfile.ProfileList.Find(x => x.e_mail == Entry_EmailPassword.Text);
        MailAddress from = new MailAddress("tesst.tok@mail.ru", "ПродуктЭкспресс");
        MailAddress to = new MailAddress(ProfEmail.e_mail);
        MailMessage m = new MailMessage(from, to);
        m.Subject = "Ваш пароль";
        m.Body = $"<h2>{ProfEmail.password}</h2>";
        m.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient("smtp.mail.ru");
        smtp.Credentials = new NetworkCredential("tesst.tok@mail.ru", "9sv6r1mn8X8pxhzavyKm");
        smtp.EnableSsl = true;
        smtp.Send(m);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var ProfEmail = CatalogProfile.ProfileList.Find(x => x.e_mail == Entry_EmailPassword.Text);
        try
        {
            if (ProfEmail.e_mail == Entry_EmailPassword.Text)
            {
                SendMessege();
                DisplayAlert("", "На почту отправлен пароль", "ОК");
            }
            else
            {
                DisplayAlert("", "Пользователь с такой почтой не найден", "ОК");
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Ошибка", ex.Message, "ОК");
        }
    }
}