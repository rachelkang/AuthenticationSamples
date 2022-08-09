namespace MIAUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<NewTaskPage>();
		builder.Services.AddTransient<SubtasksPage>();
		builder.Services.AddTransient<MainLoginPage>();
		builder.Services.AddSingleton<ProfilePage>();

		builder.Services.AddSingleton<LoginViewModel>();
		builder.Services.AddTransient<SubtasksViewModel>();
		builder.Services.AddSingleton<ProfilePageViewModel>();
		
		// database
        string dbPath = FileAccessHelper.GetLocalFilePath("user.db3");
        builder.Services.AddSingleton<UserRepository>(s => ActivatorUtilities.CreateInstance<UserRepository>(s, dbPath));

        return builder.Build();
	}
}
