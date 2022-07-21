using AzureADSample.ViewModel;
using AzureADSample.Views;

namespace AzureADSample;

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
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddSingleton<SettingsPage>();

		builder.Services.AddSingleton<MainViewModel>();
		builder.Services.AddSingleton<SettingsPageViewModel>();

		return builder.Build();
	}
}
