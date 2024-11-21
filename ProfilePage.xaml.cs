using MauiApp4.Class;

namespace MauiApp4;

public partial class ProfilePage : ContentPage
{
    Profile item = CatalogProfile.ProfileList[CatalogProfile.IdUser];
    string imageSource;
    public ProfilePage()
	{
		InitializeComponent();
    
		INFO();
    }

  


    private void INFO()
	{

        Profile_Entry_Email.Text = item.e_mail;
        Profile_Entry_Loginn.Text = item.logon;
        Profile_Entry_Password.Text = item.password;
        Profile_ImagButton.Source = item.image;
        Profile_Entry_Phone.Text = item.phone.ToString();
           
    }

    private  void Button_Clicked_Transform(object sender, EventArgs e)
    {
        if (imageSource != null)
        {
            item.image = imageSource;
        }
        item.e_mail = Profile_Entry_Email.Text;
        item.logon = Profile_Entry_Loginn.Text;
        item.password = Profile_Entry_Password.Text;
        item.phone = Profile_Entry_Phone.Text;
    }

    private async void Profile_ImagButton_Clicked(object sender, EventArgs e)
    {

        var images = await FilePicker.Default.PickAsync(new PickOptions
        {
         
            FileTypes = FilePickerFileType.Images
        });
         imageSource = images.FullPath.ToString();
  
         Profile_ImagButton.Source = imageSource;
     
    }



    private void Button_Clicked_Exit(object sender, EventArgs e)
    {
       
        Navigation.PushModalAsync(new MainPage());
    }

    
}