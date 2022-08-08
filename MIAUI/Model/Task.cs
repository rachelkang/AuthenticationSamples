using System.Collections.ObjectModel;
using SQLite;

namespace MIAUI.Model;

[Table ("tasks")]
public class Task
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Details { get; set; } = String.Empty;
    public string TaskName { get; set; }
    //public ObservableCollection<Subtask> Subtasks { get; set; }
    public string UserId { get; set; }

    public Task(string taskName)
    {
        TaskName = taskName;
        //Subtasks = new ObservableCollection<Subtask>();
    }

    public void Subtask(string taskName, string details)
    {
        Details = details;
        TaskName = taskName;
        //Subtasks = new ObservableCollection<Subtask>();
    }

}
