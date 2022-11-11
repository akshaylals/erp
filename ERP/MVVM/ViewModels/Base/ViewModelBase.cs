namespace ERP.MVVM.ViewModels.Base;

[AddINotifyPropertyChangedInterface]
public class ViewModelBase
{
    #region Services
    protected IApiService ApiService { get; }
    public INavigation NavigationService { get; set; }
    public Page PageService { get; set; }
    #endregion

    #region Bindable Properties
    public bool IsBusy { get; set; } = false;
    public string LoadingText { get; set; } = "";
    #endregion

    public ViewModelBase()
    {
        ApiService = ((App)Application.Current).ApiService;
    }

    #region Commands
    public ICommand LogOutCommand =>
        new Command(() =>
        {
            ((App)Application.Current).Logout();
        });
    #endregion

    #region methods
    protected void SetLoading(bool isLoading, string loadingMsg = "")
    {
        IsBusy = isLoading;
        LoadingText = loadingMsg;
    }
    #endregion
}
