namespace MIAUI.ViewModels;

[INotifyPropertyChanged]
public partial class TasksViewModel
{
    public TasksViewModel()
    {
        Items = new ObservableCollection<string>();
    }

    [ObservableProperty]
    ObservableCollection<string> items;

    [ObservableProperty]
    string taskName;

    [ICommand]
    void Add()
    {
        if (string.IsNullOrWhiteSpace(TaskName))
            return;
        Items.Add(TaskName);
        TaskName = string.Empty;
    }

    [ICommand]
    void Delete(string s)
    {
        if (Items.Contains(s))
        {
            Items.Remove(s);
        }
    }

    [ICommand]
    async Task Tap(string s)
    {
        await Shell.Current.GoToAsync($"{nameof(SubtasksPage)}?Text{s}");
    }
}
