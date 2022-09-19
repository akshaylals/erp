using ERP.Services;
using ERP.ViewModels;
using ERP.Views;
using SimpleRatingControlMaui;

namespace ERP;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseSimpleRatingControl()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<ProductsService>();
		builder.Services.AddSingleton<ProductsViewModel>();
		builder.Services.AddSingleton<MainPage>();

		return builder.Build();
	}
}
