using AzureADSample.Model;
using AzureADSample.Service;
using AzureADSample.Views;
using Microsoft.Identity.Client;

namespace AzureADSample;

public partial class MainPage : ContentPage
{
    AuthService authService;
    User user;
    public MainPage()
    {
        InitializeComponent();
        authService = new AuthService();
        user = new User();
    }

    // If an existing account already exist
    // then direct the user to the settigns page
    protected override async void OnAppearing()
    {
        try
        {
            var accounts = await AuthService.authenticationClient.GetAccountsAsync();
            AuthenticationResult result;

            if (accounts.Count() >= 1)
            {
                result = await AuthService.authenticationClient
                   .AcquireTokenSilent(Constants.Scopes, accounts.FirstOrDefault())
                   .ExecuteAsync();

                await SecureStorage.SetAsync("Token", result?.IdToken); // store token securely for later use
                authService.GetUserClaims(result, user);
                await DisplayAlert("Sucessful Logged in", "Existing account exist", "Ok");
                await Shell.Current.GoToAsync($"{nameof(SettingsPage)}",
                new Dictionary<string, object>
                {
                    [nameof(User)] = user
                });
                await DisplayAlert($"Welcome back {user.Name}", "", "Ok");
            }
        }
        catch
        {
            // Do nothing - the user isn't logged in
        }
    }

    // Get the result of AuthService and read the token. 
    // If there's data then that means authentication was successful
    // Get claims by reading the token
    // Afterwards, redirect client to Settings page
    async void AzureADPageClicked(object sender, EventArgs e)
    {
        var result = await authService.LoginAsync(CancellationToken.None);
        authService.GetUserClaims(result, user);

        if (result is not null)
        {
            await DisplayAlert("Sucessful", "Successfully logged in", "Ok");
            await Shell.Current.GoToAsync($"{nameof(SettingsPage)}",
            new Dictionary<string, object>
            {
                [nameof(User)] = user
            });
            await DisplayAlert($"Welcome {user.Name}", "", "Ok");
        }
    }
}
