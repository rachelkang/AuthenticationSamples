using FireBaseAuthSample.Service;
using FireBaseAuthSample.View;
using FireBaseAuthSample.ViewModel;

namespace FireBaseAuthSample;

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

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddSingleton<SettingsPage>();

        builder.Services.AddTransient<RegisterPageViewModel>();
		builder.Services.AddSingleton<LoginPageViewModel>();
		builder.Services.AddSingleton<SettingsPageViewModel>();

		builder.Services.AddSingleton<FirebaseService>();

        return builder.Build();
	}
}
