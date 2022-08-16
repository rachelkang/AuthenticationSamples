namespace MIAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        //Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
		Routing.RegisterRoute(nameof(NewTaskPage), typeof(NewTaskPage));
	}
}
