namespace MIAUI.ViewModels;

[INotifyPropertyChanged]
[QueryProperty("TaskName", "TaskName")]
public partial class SubtasksViewModel
{
    public SubtasksViewModel()
    {
        Details = new ObservableCollection<string>();
    }

    [ObservableProperty]
    ObservableCollection<string> details;

    [ObservableProperty]
    string taskName;

    [ObservableProperty]
    string detailsInfo;

    [RelayCommand]
    async Task GoBack(string d)
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    void SaveDetails()
    {
        if (string.IsNullOrWhiteSpace(DetailsInfo))
            return;
        //add TaskName
        Details.Add(DetailsInfo);
        DetailsInfo = string.Empty;
    }

}
