using MauiApp4.Class;
using MauiApp4.SubCategories;
using MauiApp4.SubCategoriesProducts;

namespace MauiApp4;

public partial class NewMainPage : ContentPage
{
   static public string sr { get;set;}
	public NewMainPage()
	{
       
        InitializeComponent();
         New_Image();
       
    }


    private void New_Image()
    {
        ImageButton_Main.Source = CatalogProfile.ProfileList[CatalogProfile.IdUser].image;
    }
    private async void ClicK_Milk_Category(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Milk—ategoriesPage());
	
	}

    private async  void ImageButton_Clicked_Profile(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProfilePage());

    }

    private  void ContentPage_Appearing(object sender, EventArgs e)
    {
        New_Image();
    }

    private async void ImageButton_Clicked_Navigat_CartPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CartPage());
    }

    private async void SerchBar_MainPage_SearchButtonPressed(object sender, EventArgs e)
    {
        SearchBar searchBar = (SearchBar)sender;
        sr = searchBar.Text;
        searchBar.Text = null;
        await Navigation.PushAsync(new CollectionProducts());
    }

    private async void ImageButton_Clicked_Vegetables_And_Fruits(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new VegetablesFruitsCategories());
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new —andyCategoriesPage());
    }

    private async void ImageButton_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BreadPastriesCategoriesPage());
    }

    private async void ImageButton_Clicked_2(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MeatCategories());
    }

    private async void ImageButton_Clicked_3(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new WaterCategories());
    }
}