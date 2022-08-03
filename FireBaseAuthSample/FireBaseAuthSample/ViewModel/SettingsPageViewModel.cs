using CommunityToolkit.Mvvm.ComponentModel;
using FireBaseAuthSample.Model;

namespace FireBaseAuthSample.ViewModel;
[QueryProperty(nameof(User), nameof(User))]
public partial class SettingsPageViewModel : ObservableObject
{
    [ObservableProperty]
    User user;
}
