using MIAUI.Service;

namespace MIAUI.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    AuthService authService;
    User user;
    public LoginViewModel ()
    {
        authService = new AuthService ();
        user = new User ();
    }

    [RelayCommand]
    async void LogIn ()
    {
        try
        {
            var result = await authService.LoginAsync (CancellationToken.None);
            authService.GetUserClaims (result, user);

            if (result is not null)
            {
                await App.Current.MainPage.DisplayAlert ("Success", "Successfully logged in", "Ok");
                await Shell.Current.GoToAsync ($"{nameof(TasksPage)}",
                new Dictionary<string, object>
                {
                    [nameof(User)] = user
                });
                await App.Current.MainPage.DisplayAlert ($"Welcome {user.Name}", "", "Ok");
            }
        }
        catch (Exception e)
        {
            await App.Current.MainPage.DisplayAlert ("Alert", "Please log in to continue", "Ok");
        }
    }
}
