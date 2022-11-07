namespace ERP.MVVM.ViewModels.Base;


public class ViewModelBase
{
    #region Services
    protected IApiService ApiService { get; }
    public INavigation NavigationService { get; set; }
    public Page PageService { get; set; }
    #endregion

    public ViewModelBase()
    {
        ApiService = ((App)Application.Current).ApiService;
    }

    #region Commands
    public ICommand LogOutCommand =>
        new Command(() =>
        {
            Preferences.Remove("token");
            Preferences.Remove("email");
            Preferences.Remove("username");
            App.Current.MainPage = new LoginPage();
        });
    #endregion
}
