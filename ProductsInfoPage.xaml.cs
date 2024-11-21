using MauiApp4.Class;


namespace MauiApp4;

public partial class ProductsInfoPage : ContentPage
{
   public Products products { get; set; }
    int count { get; set; } 
    public ProductsInfoPage( Products pr)
	{
		InitializeComponent();
        products = pr;
        INFO_Product();
    }

    void INFO_Product()
    {
        Image_ImageProducts.Source = products.ImageProducts;
        Label_Name.Text = products.name;
        Label_Structure.Text = products.structure;
        Label_Brand.Text = products.brand;
        Label_Pack.Text = products.pack;
        Label_Term.Text = products.term;
        Lebel_Price.Text = products.price.ToString() + "₽".ToString();
        var a = CatalogProducts.CartProductList.FirstOrDefault(x => x.name == products.name);
        if (a != null)
        {
            
            count = a.CountProducts;
        }
        Lebel_Count_Product.Text = count.ToString();
    }

    private void Button_Clicked_Add_Or_Remove(object sender, EventArgs e)
    {
       Button button= (Button)sender;
        switch (button.Text)
        {
            case "+":
                Add_Cart_Products();
                break;
            case "-":
                RemoveCartProduct();
                break;
        }

    }


     void Add_Cart_Products()
    {
        count++;
        var a = CatalogProducts.CartProductList.FirstOrDefault(x => x.name == products.name);
        if(a==null)
        {
      
            CatalogProducts.CartProductList.Add(new Products(products.ImageProducts, products.name, products.price, products.CountProducts+1,products.structure,products.term,products.brand,products.pack));
        }
        else
        {
            a.CountProducts = count;
        }
        Lebel_Count_Product.Text = count.ToString();
    }

    void RemoveCartProduct()
    {
        var a= CatalogProducts.CartProductList.FirstOrDefault(x => x.name == products.name);
        count--;
        if (count>0&&a!=null)
        {
            a.CountProducts = count;        

        }
        if (count < 0)
        {
            count = 0;
        }
        if (count<=0)
        {
           CatalogProducts.CartProductList.Remove(a);
        }
        Lebel_Count_Product.Text = count.ToString();
    }

   

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        INFO_Product();
    }
}