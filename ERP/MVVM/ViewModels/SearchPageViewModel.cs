namespace ERP.MVVM.ViewModels;

[AddINotifyPropertyChangedInterface]
public class SearchPageViewModel : ViewModelBase
{
    public SearchPageViewModel()
    {
        GetAllProducts();
    }


    #region Binding Property
    public ObservableCollection<Product> Products { get; set; }
    #endregion


    #region Properties
    private string searchTerm = "";
    public FilterStringWrapper filterObj = new();
    #endregion

    #region Commands
    public ICommand NavigateToDetailsPageCommand =>
        new Command((id) =>
        {
            NavigationService.PushModalAsync(new DetailsPage((int)id));
        });

    public ICommand SearchProductsCommand =>
        new Command(async (searchQuery) =>
        {
            searchTerm = ((string)searchQuery).Trim();
            await GetSearchProducts();
        });

    public ICommand NavigateToFilterPageCommand =>
        new Command(() =>
        {
            NavigationService.PushModalAsync(new FilterPage(ref filterObj));
        });
    #endregion

    #region functions
    private async Task GetSearchProducts()
    {
        //SetDataLodingIndicators(true);

        //LoadingText = "Hold on while we get products...";

        try
        {
            List<Product> products;
            if (filterObj.FilterString == "")
            {
                products = await ApiService.GetProducts(searchTerm);
            }
            else
            {
                products = await ApiService.GetProducts(searchTerm, filterObj.FilterString);
            }
            Products = new ObservableCollection<Product>(products);

            //this.DataLoaded = true;
        }
        catch (InternetConnectionException)
        {
            //this.IsErrorState = true;
            //this.ErrorMessage = "Slow or no internet connection." + Environment.NewLine + "Please check you internet connection and try again.";
            Console.WriteLine("Slow or no internet connection." + Environment.NewLine + "Please check you internet connection and try again.");
            //ErrorImage = "nointernet.png";
        }
        catch (EmptySearchException)
        {
            //this.IsErrorState = true;
            //this.ErrorMessage = $"No search results.";
            Console.WriteLine("No search results.");
            //ErrorImage = "emptysearch.png";
        }
        catch (Exception)
        {
            //this.IsErrorState = true;
            //this.ErrorMessage = $"Something went wrong.";
            Console.WriteLine("Something went wrong.");
            //ErrorImage = "error.png";
        }
        finally
        {
            //SetDataLodingIndicators(false);
        }

    }

    public async void GetAllProducts()
    {
        var products = await ApiService.GetProducts();
        Products = new ObservableCollection<Product>(products);
    }
    #endregion
}
