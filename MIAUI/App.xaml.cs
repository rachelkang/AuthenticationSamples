namespace MIAUI;

public partial class App : Application
{
    public static UserRepository UserRepo { get; private set; }

    public App(UserRepository repo)
	{
		InitializeComponent();

		MainPage = new AppShell();
		UserRepo = repo;
	}
}
