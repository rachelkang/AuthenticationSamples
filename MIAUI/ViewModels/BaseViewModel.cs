using CommunityToolkit.Mvvm.ComponentModel;

namespace MIAUI.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        bool isBusy = false;
    }
}
