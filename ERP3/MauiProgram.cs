using SimpleRatingControlMaui;

namespace ERP3;

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
			})
			.ConfigureLifecycleEvents(events =>
			{
#if ANDROID
                events.AddAndroid(android => android.OnCreate((activity, bundle) => MakeStatusBarTranslucent(activity)));

                static void MakeStatusBarTranslucent(Android.App.Activity activity)
                {
                    activity.Window.SetFlags(Android.Views.WindowManagerFlags.LayoutNoLimits, Android.Views.WindowManagerFlags.LayoutNoLimits);

                    activity.Window.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);

                    activity.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
                }
#endif
            });

		RegisterAppServices(builder.Services);

		return builder.Build();
	}

    private static void RegisterAppServices(IServiceCollection services)
    {
        //Add Platform specific Dependencies
        services.AddSingleton<IConnectivity>(Connectivity.Current);


        //Register API Service
        services.AddSingleton<IApiService, ErpService>();

        //Register View Models
        services.AddSingleton<ProductsPageViewModel>();
        services.AddSingleton<CartPageViewModel>();
        services.AddSingleton<SettingsPageViewModel>();
        services.AddSingleton<MenuPageViewModel>();
        services.AddSingleton<EstimatePageViewModel>();
        services.AddSingleton<FilterPageViewModel>();
        
        services.AddTransient<DetailsPageViewModel>();

    }
}
