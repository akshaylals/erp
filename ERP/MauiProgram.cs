using ERP.Services;
using ERP.ViewModels;
using ERP.Views;

namespace ERP;

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

		builder.Services.AddSingleton<ProductsService>();
		builder.Services.AddSingleton<ProductsViewModel>();
		builder.Services.AddSingleton<MainPage>();

		return builder.Build();
	}
}
