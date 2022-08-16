namespace MIAUI;

public partial class App : Application
{
    public static TasksRepository TaskRepo { get; private set; }
    public App (TasksRepository task)
	{
		InitializeComponent ();

		MainPage = new AppShell ();

		TaskRepo = task;
	}
}
