namespace AuthenticationSimpleSample;

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
				fonts.AddFont("SF-Pro.ttf", "MainFont");
				fonts.AddFont("SF-Pro-Italic.ttf", "MainFontTwo");
			});
		// AddTransient for new page instance for navigation
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<SettingsPage>();

		return builder.Build();
	}
}
