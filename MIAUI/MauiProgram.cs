using MIAUI.ViewModels;
using MIAUI.Views;

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
		builder.Services.AddTransient<SubtasksViewModel>();

		return builder.Build();
	}
}
