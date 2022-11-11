namespace ERP.MVVM.ViewModels;


public class LoginPageViewModel : ViewModelBase
{
    #region Binding Property
    #endregion

    public LoginPageViewModel()
    {
    }


    #region Commands
    public ICommand LoginCommand =>
        new Command(async () =>
        {
            SetLoading(true, "Logging in");
            await ((App)Application.Current).Authenticate();
            SetLoading(false);
        });
    #endregion

    #region functions
    #endregion
}
