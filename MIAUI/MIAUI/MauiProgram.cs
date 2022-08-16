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

		builder.Services.AddSingleton<LoginViewModel>();
		builder.Services.AddTransient<SubtasksViewModel>();

        string dbPath = FileAccessHelper.GetLocalFilePath("Task.db3"); ;
        builder.Services.AddSingleton<TasksRepository>(s => ActivatorUtilities.CreateInstance<TasksRepository>(s, dbPath));
        
		return builder.Build();
	}
}
