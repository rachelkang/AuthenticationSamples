using FirebaseAdmin;
using FirebaseAdmin.Auth;
using FireBaseAuthSample.Model;
using FireBaseAuthSample.Service;
using FireBaseAuthSample.View;
using FireBaseAuthSample.ViewModel;
using Google.Apis.Auth.OAuth2;

namespace FireBaseAuthSample;

public partial class MainPage : ContentPage
{
    public string projectId = "fir-authsample-b63ac";
    User user;
    FirebaseService authService;

    public MainPage(LoginPageViewModel vm, FirebaseService service)
    {
        InitializeComponent();
        BindingContext = vm;
        FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.FromComputeCredential(),
            ProjectId = projectId,
        });

        user = new User();
        authService = service;
    }

    // Check that there's an existing account
    // Attempt to get token silently for the account from the user token cache 
    // then direct the user to the settigns page
    protected override async void OnAppearing()
    {
        try
        {
            // Verify the ID token while checking if the token is revoked by passing checkRevoked as true.
            bool checkRevoked = true;
            var token = await SecureStorage.GetAsync("token");
            if (token is not null)
            {
                var decodedToken = await authService.VerifyIdTokenAsync(token);
                // Token is valid and not revoked.
                string uid = decodedToken.Uid;

                authService.GetUserClaims(decodedToken, user);

                bool userInput = await DisplayAlert("Existing account detected", $"Would you like to log back in as {user.DisplayName}", "Yes", "No");

                if (userInput is true) {
                    await Shell.Current.GoToAsync($"{nameof(SettingsPage)}",
                    new Dictionary<string, object>
                    {
                        [nameof(User)] = user
                    });
                    await DisplayAlert($"Welcome back {user.DisplayName}", "", "Ok");
                }
            }
        }
        catch (FirebaseAuthException ex)
        {
            if (ex.AuthErrorCode == AuthErrorCode.RevokedIdToken)
            {
                // Token has been revoked. Inform the user to re-authenticate or signOut() the user.
                await DisplayAlert("Alert", "Please login again", "Ok");
                
            }
            else
            {
                // Token is invalid.
                await DisplayAlert("Alert", $"{ex.Message} Please login again.", "Ok");
            }
        }

    }
}
