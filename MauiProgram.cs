using Microsoft.Extensions.Logging;
using Plugin.LocalNotification;
using Syncfusion.Blazor;
using m0.maui.Data;
using m0.maui.Interfaces;
using m0.maui.Platforms.Android;

namespace m0.maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseLocalNotification()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
		builder.Services.AddScoped(_ => new HttpClient
		{
			BaseAddress = new Uri("http://mthrowaway488-001-site1.dtempurl.com")
		});
		builder.Services.AddSyncfusionBlazor();

		Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Key.License);

#if ANDROID
		builder.Services.AddTransient<IForegroundService, NotificationService>();
#endif

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<WeatherForecastService>();

		return builder.Build();
	}
}
