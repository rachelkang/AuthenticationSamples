using SQLite;
using MIAUI.Model;

namespace MIAUI.ViewModels;



[INotifyPropertyChanged]
public partial class TasksViewModel
{
    public TasksViewModel()
    {
        var list = App.TaskRepo.GetAllTasks();
        Items = new ObservableCollection<Model.Task>(list);
        //Items = new ObservableCollection<Model.Task>();
        //fetch from database and fill items
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
        App.TaskRepo.AddNewTask(TaskName);
        Items.Add(new Model.Task(TaskName));
        TaskName = string.Empty;


    }

    [RelayCommand]

    //This delete method needs to interact with the database
    void Delete(Model.Task task)
    {
        //var taskList = App.TaskRepo.GetAllTasks();
        /*if (Items.Contains(s))
        {
            Items.Remove(s);
        }*/

        App.TaskRepo.DeleteTask(task.Id);
        Items.Remove(task);
    }

    [RelayCommand]
    async Task Tap(Model.Task Task)
    {
        await Shell.Current.GoToAsync($"{nameof(SubtasksPage)}",
                    new Dictionary<string, object>
                    {
                        [nameof(Task)] = Task,
                        ["Details"] = Task.Details
                    });
       // await Shell.Current.GoToAsync($"{nameof(SubtasksPage)}?Task={Task}");
    }
}

