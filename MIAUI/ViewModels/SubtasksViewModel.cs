using MIAUI.Model;

namespace MIAUI.ViewModels;

[INotifyPropertyChanged]
[QueryProperty("TaskName", "TaskName")]
public partial class SubtasksViewModel
{
    public SubtasksViewModel()
    {
        Details = new ObservableCollection<Subtask>();
    }

    [ObservableProperty]
    ObservableCollection<Subtask> details;

    [ObservableProperty]
    string taskName;

    [ObservableProperty]
    string detailsInfo;

    [RelayCommand]
    async Task GoBack(string details)
    {
        await Shell.Current.GoToAsync($"..?DetailsInfo={details}");
    }

    [RelayCommand]
    void SaveDetails()
    {
        Details.Clear();
        if (string.IsNullOrWhiteSpace(DetailsInfo))
            return;
        //add TaskName
        Details.Add(new Subtask(DetailsInfo));
        //@DetailsInfo = string.Empty;
    }

}
