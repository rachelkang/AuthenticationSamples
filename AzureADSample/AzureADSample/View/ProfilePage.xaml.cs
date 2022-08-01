using AzureADSample.Service;
using AzureADSample.ViewModel;
using Microsoft.Identity.Client;

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
        IEnumerable<IAccount> accounts = await AuthService.authenticationClient.GetAccountsAsync();

        while (accounts.Any())
        {
            await AuthService.authenticationClient.RemoveAsync(accounts.First());
            accounts = await AuthService.authenticationClient.GetAccountsAsync();
        }
        //Redirect user to home page
        await Shell.Current.GoToAsync(nameof(MainPage));
    }
}

