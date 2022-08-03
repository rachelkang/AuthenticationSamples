using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using MIAUI.Views;
using Task = System.Threading.Tasks.Task;

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
    string taskName; //Task's title

    [ICommand]
    void Add()
    {
        if (string.IsNullOrWhiteSpace(TaskName))
            return;
        //add TaskName
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
