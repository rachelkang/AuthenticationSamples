using AzureADSample.Model;
using AzureADSample.Service;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Identity.Client;

namespace AzureADSample.ViewModel;

[QueryProperty(nameof(User), nameof(User))]
public partial class ProfilePageViewModel : ObservableObject
{
    [ObservableProperty]
    User user;
    
}
