namespace ERP.MVVM.ViewModels;

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
        SetError(false);
        SetLoading(true, "Loading ...");

        try
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
        catch (InternetConnectionException)
        {
            SetError(true,
                $"Slow or no internet connection.{Environment.NewLine}Please check you internet connection and try again.",
                "nointernet.png");

            Console.WriteLine("Slow or no internet connection." + Environment.NewLine + "Please check you internet connection and try again.");
        }
        catch (Exception)
        {
            SetError(true,
                "Something went wrong.",
                "error.png");

            Console.WriteLine("Something went wrong.");
        }
        finally
        {
            SetLoading(false);
        }

    }
    #endregion
}


public class FilterOption
{
    public string CategoryName { get; set; }
    public bool IsSelected { get; set; } = false;
}