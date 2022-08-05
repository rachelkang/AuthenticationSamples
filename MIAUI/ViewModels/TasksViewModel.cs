namespace MIAUI.ViewModels;


[INotifyPropertyChanged]
public partial class TasksViewModel
{
    public TasksViewModel()
    {
        Items = new ObservableCollection<MIAUI.Model.Task>();
    }

    [ObservableProperty]
    ObservableCollection<MIAUI.Model.Task> items;

    [ObservableProperty]
    string taskName;

    [ICommand]
    void Add()
    {

        if (string.IsNullOrWhiteSpace(TaskName))
            return;
        Items.Add(new Model.Task(TaskName));
        TaskName = string.Empty;


    }

    [ICommand]

    //This delete method needs to interact with the database
    void Delete(string s)
    {
        /*if (Items.Contains(s))
        {
            Items.Remove(s);
        }*/
    }

    [ICommand]
    async Task Tap(string s)
    {
        await Shell.Current.GoToAsync($"{nameof(SubtasksPage)}?TaskName={s}");
    }
}

