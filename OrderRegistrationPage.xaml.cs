using MauiApp4.Class;

namespace MauiApp4;

public partial class OrderRegistrationPage : ContentPage
{
    Profile item = CatalogProfile.ProfileList[CatalogProfile.IdUser];
    string card { get; set; } = "";

    public OrderRegistrationPage()
	{
        InitializeComponent();
		Entry_Phone.Text = item.phone.ToString();
        Sum_Products();
	}

    private  async void Button_Clicked(object sender, EventArgs e)
    {
        var a =  await DisplayPromptAsync("Карта", "Введите номер карты ", "ОК", "Отмена");
        card = a;
    }

    void  Sum_Products()
    {
        int SumPrice = CatalogProducts.CartProductList.Sum(x => x.price * x.CountProducts);
        int result = SumPrice + 100;
        Label_Sum.Text=$"{SumPrice}₽";
        Lebel_Result.Text = $"{result}₽";
    }

    private async void Button_RegistrOrder_Clicked(object sender, EventArgs e)
    {
        if (Enry_Address.Text == null || Enry_Address.Text == " ")
        {
            await DisplayAlert("Ошибка", "Поле адрес не может быть пустым", "ок");
        }
        else if (Check_Box_Payment.IsChecked == false && card == "")
        {
            await DisplayAlert("Ошибка", "Не выбран способ оплаты", "ок");
        }
        else
        {
            await DisplayAlert("Заказ оформлен", "Заказ будет доставле через 60-80 мин", "Ок");
            CatalogProducts.CartProductList.Clear();
            await Navigation.PushAsync(new NewMainPage());
        }

    }
}