namespace ERP3.ViewModels;

public partial class EstimatePageViewModel : AppViewModelBase
{
    public EstimatePageViewModel(IApiService appApiService) : base(appApiService)
    {
        this.Title = "Estimate";
    }
}
