using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MIAUI.ViewModels
{
    //[QueryProperty("Text", "Text")]
    public partial class SubtasksViewModel : BaseViewModel
    {
        [ObservableProperty]
        string details;

        [ICommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        [ICommand]
        void Add()
        {
            if (string.IsNullOrWhiteSpace(details))
                return;
            //add TaskName
            //Items.Add(SubtaskName);
            //TaskName = string.Empty;
        }

    }
}
