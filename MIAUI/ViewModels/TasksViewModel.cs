namespace MIAUI.ViewModels;

[INotifyPropertyChanged]
public partial class TasksViewModel
{
    public TasksViewModel()
    {
        listOfItems = new ObservableCollection<string>();
    }

    [ObservableProperty]
    ObservableCollection<string> listOfItems;

    [ObservableProperty]
    string task;

    [RelayCommand]
    void Add()
    {
        if (string.IsNullOrWhiteSpace(task))
            return;
        listOfItems.Add(task);
        task = string.Empty;
    }

    [RelayCommand]
    void Delete(string s)
    {
        if (listOfItems.Contains(s))
        {
            listOfItems.Remove(s);
        }
    }

    [RelayCommand]
    async Task Tap(string s)
    {
        await Shell.Current.GoToAsync($"{nameof(SubtasksPage)}?Text{s}");
    }
}
