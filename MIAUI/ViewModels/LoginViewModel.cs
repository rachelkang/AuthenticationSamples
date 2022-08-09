using MIAUI.Model;
using MIAUI.Service;
using SQLite;

namespace MIAUI.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    AuthService authService;
    User user;
    int id;

    public LoginViewModel()
    {
        authService = new AuthService();
        user = new User();
    }

    [RelayCommand]
    async void LogIn()
    {
        try
        {
            var result = await authService.LoginAsync(CancellationToken.None);
            authService.GetUserClaims(result, user);
            if (result is not null)
            {
                App.UserRepo.AddNewPerson(user.Name, user.Email);
                id = user.Id;
                await App.Current.MainPage.DisplayAlert("Success", "Successfully logged in", "Ok");
                await Shell.Current.GoToAsync($"{nameof(NewTaskPage)}?Id={id}",
                    new Dictionary<string, object>
                    {
                        [nameof(User)] = user
                    });
                await App.Current.MainPage.DisplayAlert($"Welcome {user.Name}", "", "Ok");
            }
        }
        catch(Exception e)
        {
            await App.Current.MainPage.DisplayAlert("Alert", "Please log in to continue", "Ok");
        }
    }
}
