using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using FireBaseAuthSample.Model;
using FireBaseAuthSample.Service;
using FireBaseAuthSample.View;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using FirebaseAuth = FirebaseAdmin.Auth.FirebaseAuth;
using User = FireBaseAuthSample.Model.User;

namespace FireBaseAuthSample.ViewModel;
public partial class LoginPageViewModel : ObservableObject
{
    public string webApiKey = "AIzaSyDluqM7Va_YsYx4QvgIVzGaVVIENiK87D4";
    public string projectId = "fir-authsample-b63ac";

    [ObservableProperty]
    User user;

    FirebaseService authService;
 
    public LoginPageViewModel(FirebaseService service)
    {
        authService = service;
        user = new User();
    }

    [RelayCommand]
    async void LogIn()
    {
        try
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey)); // base

            // Login and get the token
            // Verify ID tokens using the Firebase Admin SDK
            // Get the user claims
            var token = await authService.LoginAsync(authProvider, user);
            var decodedToken = await authService.VerifyIdTokenAsync(token);

            authService.GetUserClaims(decodedToken, user);

            await SecureStorage.SetAsync("token", token); // store token for later use
            await Shell.Current.GoToAsync($"{nameof(SettingsPage)}",
            new Dictionary<string, object>
            {
                [nameof(User)] = user
            });

            // NOTE - This is my old code


            /*          var content = await auth.GetFreshAuthAsync(); // log in content (information)
                      var serialziedContent = JsonConvert.SerializeObject(content); // encode the content if needed
                      var token = auth.FirebaseToken;*/


            /*            var auth = await authProvider.SignInWithEmailAndPasswordAsync(user.Email, user.Password); // log in
                        var content = await auth.GetFreshAuthAsync(); // log in content
                        var serialziedContent = JsonConvert.SerializeObject(content); // encode the content
                        var token = auth.FirebaseToken; // get the token


                        // Get user claims
                        FirebaseToken decodedToken = await FirebaseAuth.DefaultInstance
                        .VerifyIdTokenAsync(token);
                        string uid = decodedToken.Uid;

                        await SecureStorage.SetAsync("token", token); // store token for later use


                        if (decodedToken is not null)
                        {
                            user.Name = decodedToken.Claims.FirstOrDefault(x => x.Key.Equals("name")).ToString();
                            user.Email = decodedToken.Claims.FirstOrDefault(x => x.Key.Equals("email")).Value.ToString();
                        }

                        await Shell.Current.GoToAsync($"{nameof(SettingsPage)}",
                            new Dictionary<string, object>
                            {
                                [nameof(User)] = user
                            });*/
        }
        catch (Exception e)
        {
            await App.Current.MainPage.DisplayAlert("ALert", e.Message, "Ok");
            Console.WriteLine(Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS"));
        }
    }

    [RelayCommand]
    async Task RegisterBtn() => 
        await Shell.Current.GoToAsync(nameof(RegisterPage));

}
