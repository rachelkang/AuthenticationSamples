namespace MIAUI.ViewModels;

[INotifyPropertyChanged]
[QueryProperty(nameof (Task), "Task")]
[QueryProperty(nameof (TaskName), "TaskName")]
[QueryProperty(nameof (DetailsInfo), "Details")]
public partial class DetailsViewModel
{
    public DetailsViewModel ()
    {
        //Details = detailsInfo;
    }

    [ObservableProperty]
    Model.Task task;

    [ObservableProperty]
    string taskName;

    [ObservableProperty]
    int id;

    [ObservableProperty]
    string detailsInfo;

    [RelayCommand]
    async Task GoBack ()
    {
        await Shell.Current.GoToAsync ("..");
    }

    [RelayCommand]
    void SaveDetails ()
    {
        if (string.IsNullOrWhiteSpace (DetailsInfo))
            return;
        //add TaskName
        Task.Details = DetailsInfo;
        App.TaskRepo.UpdateDetails (Task);
        var taskList = App.TaskRepo.GetAllTasks ();
    }

}
