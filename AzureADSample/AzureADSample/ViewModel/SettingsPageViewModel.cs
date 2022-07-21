using AzureADSample.Model;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AzureADSample.ViewModel;

[QueryProperty(nameof(User), nameof(User))]
public partial class SettingsPageViewModel : ObservableObject
{
    [ObservableProperty]
    User user;

}
