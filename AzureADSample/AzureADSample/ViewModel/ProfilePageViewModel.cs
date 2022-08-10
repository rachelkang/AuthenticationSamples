using AzureADSample.Model;
using AzureADSample.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Identity.Client;

namespace AzureADSample.ViewModel;

[INotifyPropertyChanged]
[QueryProperty(nameof(User), nameof(User))]
public partial class ProfilePageViewModel
{
    [ObservableProperty]
    User user;

    [RelayCommand]
    public async void LogOut()
    {
        IEnumerable<IAccount> accounts = await AuthService.authenticationClient.GetAccountsAsync();

        while (accounts.Any())
        {
            await AuthService.authenticationClient.RemoveAsync(accounts.First());
            accounts = await AuthService.authenticationClient.GetAccountsAsync();
        }
        //Redirect user to home page
        await Shell.Current.GoToAsync("..");
    }
}

