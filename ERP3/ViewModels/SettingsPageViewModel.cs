namespace ERP3.ViewModels;

public partial class SettingsPageViewModel : AppViewModelBase
{
    public SettingsPageViewModel(IApiService appApiService) : base(appApiService)
    {
        this.Title = "Settings";
    }
}
