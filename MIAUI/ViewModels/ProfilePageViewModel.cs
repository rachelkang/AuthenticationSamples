using MIAUI.Model;

namespace MIAUI.ViewModels;

[QueryProperty(nameof(User), nameof(User))]
public partial class ProfilePageViewModel : ObservableObject
{
    // Diosplay info here
    [ObservableProperty]
    User user;


    [RelayCommand]
    async void LogOutBtn()
    {

    }
}
