namespace ERP3.ViewModels;

public partial class MenuPageViewModel : AppViewModelBase
{
    public MenuPageViewModel(IApiService appApiService) : base(appApiService)
    {
        this.Title = "Menu";
    }
}
