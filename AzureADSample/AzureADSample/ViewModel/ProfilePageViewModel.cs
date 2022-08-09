using AzureADSample.Model;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AzureADSample.ViewModel;

[QueryProperty(nameof(User), nameof(User))]
public partial class ProfilePageViewModel : ObservableObject
{
    [ObservableProperty]
    User user;
}
