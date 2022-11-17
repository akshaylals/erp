namespace ERP;

public partial class App : Application
{
    public IApiService ApiService { get; }
    public OidcClient OidcClient { get; }
    public AuthService AuthService { get; }

    public App(IApiService apiService, OidcClient oidcClient, AuthService authService)
	{
		InitializeComponent();
		ApiService = apiService;
		OidcClient = oidcClient;
        AuthService = authService;

		MainPage = new LoginPage();
	}

	public async Task Authenticate()
	{
        if (await AuthService.Authenticate())
            MainPage = new AppShell();
        else
            await MainPage.DisplayAlert("Error Logging in", "", "Ok");
    }

    public void Logout()
    {
        AuthService.Logout();
        MainPage = new LoginPage();
    }
}
