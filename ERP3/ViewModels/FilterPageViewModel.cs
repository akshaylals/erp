namespace ERP3.ViewModels;

public partial class FilterPageViewModel : AppViewModelBase
{
    public FilterPageViewModel(IApiService appApiService) : base(appApiService)
    {
        this.Title = "";
    }
}
