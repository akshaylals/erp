namespace ERP.Extensions;

public static class ConfigExtensions
{
    public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
        builder.Services.AddSingleton<IApiService, ApiService>();

        return builder;
    }
}
