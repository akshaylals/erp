using IdentityModel.OidcClient;

namespace Framework.Services;

public class AuthService
{
    public OidcClient OidcClient { get; }

    public AuthService(OidcClient oidcClient)
    {
        OidcClient = oidcClient;
    }

    public async Task<bool> Authenticate()
    {
        if (Preferences.ContainsKey("token"))
        {
            return true;
        }
        else
        {
            try
            {
                var loginResult = await OidcClient.LoginAsync(new LoginRequest());

                Preferences.Set("token", loginResult.AccessToken);

                foreach (var claim in loginResult.User.Claims)
                {
                    if (claim.Type == "email")
                    {
                        Preferences.Set("email", claim.Value);
                    }
                    if (claim.Type == "username")
                    {
                        Preferences.Set("username", claim.Value);
                    }
                }
                //await SecureStorage.Default.SetAsync("token", loginResult.AccessToken);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        return false;
    }

    public void Logout()
    {
        Preferences.Remove("token");
        Preferences.Remove("email");
        Preferences.Remove("username");
        OidcClient.LogoutAsync();
    }
}
