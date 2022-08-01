using AzureADSample.Model;
using AzureADSample.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Identity.Client;

namespace AzureADSample.ViewModel;

[QueryProperty(nameof(User), nameof(User))]
public partial class ProfilePageViewModel : ObservableObject
{
    [ObservableProperty]
    User user;
    async void LogOut(object sender, EventArgs e)
    {
        IEnumerable<IAccount> accounts = await AuthService.authenticationClient.GetAccountsAsync();

        while (accounts.Any())
        {
            await AuthService.authenticationClient.RemoveAsync(accounts.First());
            accounts = await AuthService.authenticationClient.GetAccountsAsync();
        }

        await Shell.Current.GoToAsync(nameof(MainPage));
    }
}
