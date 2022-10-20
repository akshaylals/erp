namespace ERP3.ViewModels;

public partial class FilterPageViewModel : AppViewModelBase
{

    //[ObservableProperty]
    //private ObservableCollection<string> categories = new();

    public List<string> categories = new();

    public FilterPageViewModel(IApiService appApiService) : base(appApiService)
    {
        this.Title = "Filter";
        this.categories.Add("men's clothing");
        this.categories.Add("jewelery");
        this.categories.Add("electronics");
        this.categories.Add("women's clothing");
    }
}
