namespace ERP3.ViewModels;

public partial class LoginPageViewModel : AppViewModelBase
{
    public LoginPageViewModel(IApiService appApiService) : base(appApiService)
    {
        this.Title = "Login";
    }
}
