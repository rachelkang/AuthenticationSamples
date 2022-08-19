namespace MIAUI.ViewModels;

[INotifyPropertyChanged]
public partial class TasksViewModel
{
    public TasksViewModel ()
    {
        var list = App.TaskRepo.GetAllTasks ();
        Items = new ObservableCollection<Model.Task> (list);
    }

    [ObservableProperty]
    ObservableCollection<Model.Task> items;

    [ObservableProperty]
    DateTime today = DateTime.Today;

    [ObservableProperty]
    string taskName;

    [RelayCommand]
    void Add ()
    {
        if (string.IsNullOrWhiteSpace (TaskName))
            return;
        App.TaskRepo.AddNewTask (TaskName);
        Items.Add (new Model.Task (TaskName));
        TaskName = string.Empty;
    }

    [RelayCommand]
    void Delete (Model.Task task)
    {
        App.TaskRepo.DeleteTask (task.Id);
        Items.Remove (task);
    }

    [RelayCommand]
    async Task Tap (Model.Task Task)
    {
        await Shell.Current.GoToAsync ($"{nameof (DetailsPage)}",
                    new Dictionary<string, object>
                    {
                        [nameof (Task)] = Task,
                        ["TaskName"] = Task.TaskName,
                        ["Details"] = Task.Details
                    }); ;
    }
}
