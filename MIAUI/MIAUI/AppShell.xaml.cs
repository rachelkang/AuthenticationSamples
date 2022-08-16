namespace MIAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        //Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(SubtasksPage), typeof(SubtasksPage));
		Routing.RegisterRoute(nameof(NewTaskPage), typeof(NewTaskPage));
	}
}
