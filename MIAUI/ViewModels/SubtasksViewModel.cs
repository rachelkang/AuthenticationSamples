namespace MIAUI.ViewModels;

[INotifyPropertyChanged]
public partial class SubtasksViewModel
{
    [ObservableProperty]
    string details;

    [RelayCommand] 
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    void AddDetails()
    {
        if (string.IsNullOrWhiteSpace(details))
            return;
        //add TaskName
        //Items.Add(SubtaskName);
        //TaskName = string.Empty;
    }

}
