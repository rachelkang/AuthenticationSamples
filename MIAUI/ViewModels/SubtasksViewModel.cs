namespace MIAUI.ViewModels;

[INotifyPropertyChanged]
[QueryProperty("TaskName", "TaskName")]
public partial class SubtasksViewModel
{
    public SubtasksViewModel()
    {
        Details = new ObservableCollection<Task>();
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
        Details.Clear();
        if (string.IsNullOrWhiteSpace(DetailsInfo))
            return;
        //add TaskName
        App.TaskRepo.AddNewDetails(DetailsInfo);
        Details.Add(DetailsInfo);
        //DetailsInfo = string.Empty;
    }

}
