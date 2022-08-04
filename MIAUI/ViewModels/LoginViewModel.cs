using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIAUI.ViewModels
{
    [INotifyPropertyChanged]
    public partial class LoginViewModel
    {
        [ICommand]
        async Task OnLoginClicked()
        {
            //await Shell.Current.GoToAsync(nameof(NewTaskPage));
        }
    }
}
