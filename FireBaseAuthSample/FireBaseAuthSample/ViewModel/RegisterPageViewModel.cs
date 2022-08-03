using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using User = FireBaseAuthSample.Model.User;

namespace FireBaseAuthSample.ViewModel;
public partial class RegisterPageViewModel : ObservableObject
{
    [ObservableProperty]
    User user;

    public string webApiKey = "AIzaSyDluqM7Va_YsYx4QvgIVzGaVVIENiK87D4";

    public RegisterPageViewModel()
    {
        user = new User();
    }

    [RelayCommand]
    public async void RegisterUser()
    {
        try
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(webApiKey));
            var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(user.Email, user.Password);
            string token = auth.FirebaseToken;
            
            if (token is not null)
                await App.Current.MainPage.DisplayAlert("Alert", "User Register Successfully", "OK");

            await Shell.Current.GoToAsync("..");
        }
        catch (Exception e)
        {
            await App.Current.MainPage.DisplayAlert("Alert", e.Message, "OK");
        }
    }
}
