using IdentityModel.OidcClient;

namespace ERP3.Views;

public partial class LoginPage : ContentPage
{
	protected OidcClient OidcClient { get; }
	public LoginPage(OidcClient oidcClient)
	{
		InitializeComponent();
		OidcClient = oidcClient;
	}

	private async void LoginButton_Clicked(object sender, EventArgs e)
	{
		try
		{
			var loginResult = await OidcClient.LoginAsync(new LoginRequest());

			await DisplayAlert("Login Result", "Access token is: \n\n" + loginResult.AccessToken, "Close");
			//App.Current.MainPage = new AppShell();
		}
        catch (Exception ex)
		{

			await DisplayAlert("Error", ex.ToString(), "Ok");
		}
	}
}