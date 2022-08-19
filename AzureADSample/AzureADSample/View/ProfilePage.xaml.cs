namespace AzureADSample.Views;

public partial class ProfilePage : ContentPage
{
	public ProfilePage ()
	{
		InitializeComponent ();
		BindingContext = new ProfilePageViewModel ();
	}
}
