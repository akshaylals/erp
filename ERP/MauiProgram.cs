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

        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
        builder.Services.AddSingleton<IApiService, ApiService>();
        builder.Services.AddTransient<WebAuthenticatorBrowser>();
        builder.Services.AddTransient<OidcClient>(sp =>
            new OidcClient(new OidcClientOptions
            {
                Authority = Constants.authority,
                ClientId = Constants.clientId,
                RedirectUri = Constants.redirectUri,
                Scope = Constants.scope,
                ClientSecret = Constants.clientSecret,
                Policy = new Policy { Discovery = new IdentityModel.Client.DiscoveryPolicy { ValidateEndpoints = false } },
                Browser = sp.GetRequiredService<WebAuthenticatorBrowser>(),

            })
        );

        return builder.Build();
	}
}
