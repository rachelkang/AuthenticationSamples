using MIAUI.Model;
using MIAUI.Service;
using Microsoft.Identity.Client;

namespace MIAUI.Views;

public partial class MainLoginPage : ContentPage
{
    AuthService authService;
    User user;
    int id;
    public MainLoginPage(LoginViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
        authService = new AuthService();
        user = new User();
    }

    // Check that there's an existing account
    // Attempt to get token silently for the account from the user token cache 
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

                bool userInput = await DisplayAlert("Existing account detected", $"Would you like to log back in as {user.Name}", "Yes", "No");

                if (userInput is true)
                {
                    id = user.Id;
                    await Shell.Current.GoToAsync($"{nameof(NewTaskPage)}?Id={id}",
                    new Dictionary<string, object>
                    {
                        [nameof(User)] = user
                    });
                    await DisplayAlert($"Welcome back {user.Name}", "", "Ok");
                }
            }
        }
        catch (MsalUiRequiredException e)
        {
            Console.WriteLine("Token doesn't exist in the cache or is expired");
        }
    }
}