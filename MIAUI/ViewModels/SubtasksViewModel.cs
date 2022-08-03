namespace MIAUI.ViewModels;

[INotifyPropertyChanged]
public partial class SubtasksViewModel
{
    [ObservableProperty]
    string details;

    [ICommand] 
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }

    [ICommand]
    void AddDetails()
    {
        if (string.IsNullOrWhiteSpace(details))
            return;
        //add TaskName
        //Items.Add(SubtaskName);
        //TaskName = string.Empty;
    }

}
