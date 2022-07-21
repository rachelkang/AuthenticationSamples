using AzureADSample.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureADSample.ViewModel;

[QueryProperty(nameof(User), nameof(User))]
public partial class SettingsPageViewModel : ObservableObject
{
    [ObservableProperty]
    User user;

}
