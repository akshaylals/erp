namespace ERP;

public partial class App : Application
{
    public IApiService ApiService { get; }
    public OidcClient OidcClient { get; }

    public App(IApiService apiService, OidcClient oidcClient)
	{
		InitializeComponent();
		ApiService = apiService;
		OidcClient = oidcClient;

		MainPage = new LoginPage();
	}

	public async void Authenticate()
	{
        if (Preferences.ContainsKey("token"))
        {
            MainPage = new AppShell();
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

                App.Current.MainPage = new AppShell();
            }
            catch (Exception ex)
            {
                await MainPage.DisplayAlert("Error", ex.ToString(), "Ok");
                Console.WriteLine(ex.ToString());
            }
        }
    }

    public void Logout()
    {
        Preferences.Remove("token");
        Preferences.Remove("email");
        Preferences.Remove("username");
        MainPage = new LoginPage();
    }
}
