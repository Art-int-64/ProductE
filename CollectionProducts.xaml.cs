
using MauiApp4.Class;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MauiApp4;

public partial class CollectionProducts : ContentPage
{
    List<Products> ListCatalogProducts =  CatalogProducts.ListProducts.FindAll(x => x.Type == CatalogProducts.TypeProducts);
    string selection;
    public CollectionProducts()
	{
        InitializeComponent();
        if (NewMainPage.sr!=null)
        {
            SearcBar_Coll.Text= NewMainPage.sr;
            ListCatalogProducts=Poisk(NewMainPage.sr);
            CollectionView_Products.ItemsSource = Poisk(NewMainPage.sr);
            NewMainPage.sr = null;

        }
        else
        {
            CollectionView_Products.ItemsSource = ListCatalogProducts;
        }
        Sort(selection);

    }

    private async void Button_Clicked_Open_CartPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CartPage());

    }

    private async void CollectionView_Products_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {   
        try
        {
            Products products = (Products)CollectionView_Products.SelectedItem;
            if (CollectionView_Products.SelectedItem!=null)
            {
            await Navigation.PushAsync(new ProductsInfoPage(products));
            }
            CollectionView_Products.SelectedItem = null;
        }
        catch
        {
            await DisplayAlert("ОШИБКА", "Произошла непредвиденная ошибка!!!", "ок");
        }


    }

   

    private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    { 
        SearchBar searchBar = (SearchBar)sender;
        ListCatalogProducts = Poisk(searchBar.Text);
        CollectionView_Products.ItemsSource = ListCatalogProducts;
        Sort(selection);
      
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        selection = await DisplayActionSheet("Показать сначала", "Отмена",null, "Дешёвые", "Дорогие");
        Sort(selection);
    }

     void Sort(string pick)
     {
       
        switch (pick) {
            case "Дорогие":
                CollectionView_Products.ItemsSource = ListCatalogProducts.OrderByDescending(x => x.price).ToList();
                break;
            case "Дешёвые":
                CollectionView_Products.ItemsSource = ListCatalogProducts.OrderBy(x => x.price).ToList();
                break;
            default: break;

        }
        
    }

     List<Products> Poisk(string Text)
     {
        var Product =  CatalogProducts.ListProducts.Where(x => x.name.StartsWith(Text,StringComparison.OrdinalIgnoreCase)||x.brand.StartsWith(Text, StringComparison.OrdinalIgnoreCase)).ToList();
        if (Product.Count == 0 || Product == null)
        {
            Label_Mes.Text = "Ничего не найдено";
        }
        else
        {
            Label_Mes.Text = null;
        }
        return Product;
     }

}