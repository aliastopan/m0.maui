using Microsoft.Extensions.Logging;
using Plugin.LocalNotification;
using m0.maui.Data;

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

		// builder.Services.AddHostedService<PeriodicService>();
		builder.Services.AddMauiBlazorWebView();
		builder.Services.AddScoped(_ => new HttpClient
		{
			BaseAddress = new Uri("http://mthrowaway488-001-site1.dtempurl.com")
		});

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<WeatherForecastService>();

		return builder.Build();
	}
}
