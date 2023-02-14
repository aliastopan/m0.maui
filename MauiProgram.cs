using Microsoft.Extensions.Logging;
using Plugin.LocalNotification;
using Syncfusion.Blazor;
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
		builder.Services.AddSyncfusionBlazor();

		// Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("@32302e342e30AW5dpATBtpqCFPZ1l4AXleiW/O4HFZ22AoNNIP8dg2U=;Mgo DSMBaFt/QHRqVVhkVFpGaV1CQmFJfFBmQmlafVRwdkUmHVdTRHRcQl9iSn9adUdjW3lcdHI=;Mgo DSMBMAY9C3t2VVhkQlFacldJX3xLfkx0RWFab1l6d1dMYF5BJAtUQF1hSn5Rd0ZiUHxccHZTRGZa;Mgo DSMBPh8sVXJ0S0J XE9AflRAQmFJYVF2R2BJeFRzdl9GYkwxOX1dQl9gSXxSdURqWn1ecnJXQWY=;@32302e342e30DoNebZK2TDiWrnrmyvpmQHI/efwrTIUJCAKvFwdnF9Q=;NRAiBiAaIQQuGjN/V0Z WE9EaFtKVmFWfFNpR2NbfE53flZEalxTVBYiSV9jS31TdERgWHZdcnRXQGNcVw==;NT8mJyc2IWhhY31nfWN9Z2toYXxhY3xhY2Fgc2RpYGFpY2FzAx5oJzU9fTImNGAhNxM0PjI6P30wPD4=;ORg4AjUWIQA/Gnt2VVhkQlFacldJX3xLfkx0RWFab1l6d1dMYF5BJAtUQF1hSn5Rd0ZiUHxccHZTRWRa;@32302e342e30RyPREH2TWzygOuEWgApcXl7IDrsce1uaBgs/vAmyn10=;@32302e342e30Kc0XEFGa/6MBMHHFca87H2d9c1nIcMTgeml3RHlgdXs=;@32302e342e30Y83O0UGX5rB/su73CG gAlqTLGT4xK6Nr9h5AkgQ2sE=;@32302e342e30NWoE03S4ZjDbSXKdyG5bj2lI/sOJqI VjhY84Md0HXs=;@32302e342e30AW5dpATBtpqCFPZ1l4AXleiW/O4HFZ22AoNNIP8dg2U=");

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<WeatherForecastService>();

		return builder.Build();
	}
}
