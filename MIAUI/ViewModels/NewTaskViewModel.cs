using MIAUI.Model;

namespace MIAUI.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        string _taskName;
        string _subtasks;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(_taskName );
        }

        public string TaskName
        {
            get => _taskName;
            set => SetProperty(ref _taskName, value);
        }

        public string Subtasks
        {
            get => _subtasks;
            set => SetProperty(ref _subtasks, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            List<Subtask> subtaskList = new List<Subtask> ();
            string[] subtaskStringList = (Subtasks ?? String.Empty).Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string subtaskString in subtaskStringList)
                subtaskList.Add(new Subtask { SubtaskItem = subtaskString });

            Model.Task newItem = new ()
            {
                //Id = Guid.NewGuid().ToString(),
                TaskName = TaskName,
                Subtasks = subtaskList,
            };

            await DataStore.AddItemAsync(newItem);

            SemanticScreenReader.Announce(TaskName + " task added.");

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
