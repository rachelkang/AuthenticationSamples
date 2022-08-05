using System.Collections.ObjectModel;

namespace MIAUI.Model
{
    public class Task
    {
        public string TaskName { get; set; }
        public ObservableCollection<Subtask> Subtasks { get; set; }

        public Task(string taskName)
        {
            TaskName = taskName;
            Subtasks = new ObservableCollection<Subtask>();
        }

    }
}
