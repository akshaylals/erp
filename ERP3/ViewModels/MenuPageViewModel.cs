namespace ERP3.ViewModels;

public partial class MenuPageViewModel : AppViewModelBase
{
    [ObservableProperty]
    private string username;

    [ObservableProperty]
    private string email;

    public MenuPageViewModel(IApiService appApiService) : base(appApiService)
    {
        this.Title = "Profile";

        this.Username = Preferences.Get("username", "");
        this.Email = Preferences.Get("email", "");
    }
}
