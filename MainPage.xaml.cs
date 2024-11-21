using MauiApp4.Class;
using System.Data.Common;
using System.Reflection.Metadata;

namespace MauiApp4
{
    public partial class MainPage : ContentPage
    {
     

        public MainPage()
        {
           
            InitializeComponent();
           
        }
        

       
        private async void NextPageNavigation(object? sender, EventArgs e)
        {
            if (Entry_Login.Text == null || Entry_Password.Text == null)
            {

                await DisplayAlert("Ошибка!", "Не все поля заполнены ", "ок");
            }
            CatalogProfile.IdUser = CatalogProfile.ProfileList.FindIndex(x => x.logon == Entry_Login.Text&&x.password==Entry_Password.Text);
            if (CatalogProfile.IdUser!=-1)
            {
                await Navigation.PushAsync(new TwoFactorAuthenticationPage());

            }
            else
            {
                await DisplayAlert("Ошибка!", "Неправильно введен логин или пароль", "ок");
            }
        }

        private async void NextPageNavigationRegistr(object? sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new PageRegistr());
            Entry_Null();

        }

        private void Entry_Null()
        {
            Entry_Login.Text = null;
            Entry_Password.Text = null;
        }

        private async void Button_Clicked_NewPassword(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmailPasswor());
        }
    }

}
