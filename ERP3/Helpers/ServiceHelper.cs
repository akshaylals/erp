namespace ERP3.Helpers;

public static class ServiceHelpers
{

    public static TService GetService<TService>() => //test
        Current.GetService<TService>();

    public static IServiceProvider Current =>
#if ANDROID
    MauiApplication.Current.Services;
#elif IOS || MACCATALYST
			MauiUIApplicationDelegate.Current.Services;
#else
			null;
#endif
}