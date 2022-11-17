using Framework.Authentication;
using IdentityModel.OidcClient;

namespace Framework.Extensions;

public static class AuthenticationExtensions
{
    public static MauiAppBuilder RegisterAuth(this MauiAppBuilder builder, AuthConfig config)
    {
        builder.Services.AddTransient<WebAuthenticatorBrowser>();
        builder.Services.AddTransient<OidcClient>(sp =>
            new OidcClient(new OidcClientOptions
            {
                Authority = config.Authority,
                ClientId = config.ClientId,
                RedirectUri = config.RedirectUri,
                Scope = config.Scope,
                ClientSecret = config.ClientSecret,
                Policy = new Policy { Discovery = new IdentityModel.Client.DiscoveryPolicy { ValidateEndpoints = false } },
                Browser = sp.GetRequiredService<WebAuthenticatorBrowser>(),

            })
        );

        return builder;
    }
}
