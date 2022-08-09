using MIAUI.Model;

namespace MIAUI.ViewModels;


[INotifyPropertyChanged]
[QueryProperty(nameof(User), nameof(User))]
public partial class TasksViewModel
{
    [ObservableProperty]
    User user;

    public TasksViewModel()
    {
        Items = new ObservableCollection<MIAUI.Model.Task>();
    }

    [ObservableProperty]
    ObservableCollection<MIAUI.Model.Task> items;

    [ObservableProperty]
    string taskName;

    [RelayCommand]
    void Add()
    {

        if (string.IsNullOrWhiteSpace(TaskName))
            return;
        Items.Add(new Model.Task(TaskName));
        TaskName = string.Empty;


    }

    [RelayCommand]

    //This delete method needs to interact with the database
    void Delete(string s)
    {
        /*if (Items.Contains(s))
        {
            Items.Remove(s);
        }*/
    }

    [RelayCommand]
    async Task Tap(string s)
    {
        await Shell.Current.GoToAsync($"{nameof(SubtasksPage)}?TaskName={s}");
    }

    [RelayCommand]
    async Task NavToProfilePage()
    {
        await Shell.Current.GoToAsync($"{nameof(ProfilePage)}",
                new Dictionary<string, object>
                {
                    [nameof(User)] = user
                });
    }
}
