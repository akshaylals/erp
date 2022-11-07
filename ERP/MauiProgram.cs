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
                // use your own ngrok url:
                Authority = "https://cognito-idp.us-east-2.amazonaws.com/us-east-2_Z3HizOtuq/",
                ClientId = "6inagfr1f90pv903vvtd7out3k",
                RedirectUri = "erp://",
                Scope = "openid email profile",
                ClientSecret = "1gi4j6jptekcdptasjsfb5cfrn71avl1u48qohf0uavlr8apgl1l",
                Policy = new Policy { Discovery = new IdentityModel.Client.DiscoveryPolicy { ValidateEndpoints = false } },
                Browser = sp.GetRequiredService<WebAuthenticatorBrowser>(),

            })
        );

        return builder.Build();
	}
}
