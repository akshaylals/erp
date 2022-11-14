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
    public string LoadingText { get; set; } = string.Empty;

    public string ErrorText { get; set; } = string.Empty;
    public string ErrorImage { get; set; } = string.Empty;
    public bool IsError { get; set; } = false;

    public bool DataLoaded { get; set; } = false;
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

    protected void SetError(bool isError, string errorMsg = "", string errorImg = "")
    {
        IsError = isError;
        ErrorText = errorMsg;
        ErrorImage = errorImg;
    }
    #endregion
}
