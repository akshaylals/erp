namespace ERP.MVVM.ViewModels;

[AddINotifyPropertyChangedInterface]
public class FilterPageViewModel : ViewModelBase
{
    #region Bindable Properties
    public ObservableCollection<FilterOption> Categories { get; set; } = new();
    #endregion

    #region Properties
    public FilterStringWrapper FilterObj { get; set; }
    #endregion

    public FilterPageViewModel()
    {
        GetCategories();
    }

    #region Commands
    #endregion

    #region functions
    private async void GetCategories()
    {
        var categories = await ApiService.GetCategories();
        foreach (var category in categories)
        {
            Categories.Add(new FilterOption
            {
                CategoryName = category,
                IsSelected = (category == FilterObj.FilterString)
            });
        }
    }
    #endregion
}


public class FilterOption
{
    public string CategoryName { get; set; }
    public bool IsSelected { get; set; } = false;
}