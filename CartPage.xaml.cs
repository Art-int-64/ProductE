using MauiApp4.Class;

namespace MauiApp4;

public partial class CartPage : ContentPage
{   
	public CartPage()
	{
        InitializeComponent();
        updete();
        IF_Count_null();
    }

    private async void CollectionView_CartsProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Products products = (Products)CollectionView_CartsProducts.SelectedItem;
        if (CollectionView_CartsProducts.SelectedItem != null)
        {
            await Navigation.PushAsync(new ProductsInfoPage(products));
            CollectionView_CartsProducts.SelectedItem = null;
        } 
    }

    void updete()
    {
        CollectionView_CartsProducts.ItemsSource = null;
        CollectionView_CartsProducts.ItemsSource = CatalogProducts.CartProductList;
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        updete();
        IF_Count_null();
    }

    private async void Button_Clicked_Registration(object sender, EventArgs e)
    {
       
        if (CatalogProducts.CartProductList.Count==0)
        {
            await Navigation.PopAsync();
        }
        else
        {
            await Navigation.PushAsync(new OrderRegistrationPage());
        }
    }
    void IF_Count_null()
    {
        if (CatalogProducts.CartProductList.Count == 0)
        {
            _lael.Text = "Корзина пустая";
            Button_Cart.Text = "Вернуться в магазин";
            Label_Order.Text = null;
            imageButton_Cart_Delete.Source = null;
            imageButton_Cart_Delete.IsEnabled= false;
        }
        else
        {
            _lael.Text = null;
            Button_Cart.Text = "Далее";
            Label_Order.Text = "Заказ";
            Imade_Delete_Cart();

        }
        
    }
    void Imade_Delete_Cart()
    {
        imageButton_Cart_Delete.Source = "i.svg";
        imageButton_Cart_Delete.HeightRequest = 50;
        imageButton_Cart_Delete.WidthRequest = 50;
        
    }

    private async void imageButton_Cart_Delete_Clicked(object sender, EventArgs e)
    {
        var result = await DisplayAlert("Подтвердите действие", "Вы точно хотите очистить корзину продуктов?", "Да", "Нет");
        if (result)
        {
            CatalogProducts.CartProductList.Clear();
            updete();
            IF_Count_null();
        }
        
    }

    private void SwipeDelete_Clicked(object sender, EventArgs e)
    {
        Products a = (Products)CollectionView_CartsProducts.SelectedItem;
        CatalogProducts.CartProductList.Remove(a);
        updete();
        IF_Count_null();
    }

   
}