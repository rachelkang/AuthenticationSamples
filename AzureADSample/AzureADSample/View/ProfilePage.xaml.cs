using AzureADSample.ViewModel;

namespace AzureADSample.Views;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(ProfilePageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	async void LogOutBtn(object sender, EventArgs e)
    {
		// TODO - Sign out and remove existing accounts and redirect ther user to the home page to log in
		await Shell.Current.GoToAsync(".."); 
    }
}
