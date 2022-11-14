namespace ERP.MVVM.ViewModels;

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
            HapticFeedback.Default.Perform(HapticFeedbackType.Click);
            NavigationService.PushModalAsync(new DetailsPage((int)id));
        });

    public ICommand SearchProductsCommand =>
        new Command(async (searchQuery) =>
        {
            searchTerm = ((string)searchQuery).Trim();
            if (searchTerm == "")
            {
                GetAllProducts();
            }
            else
            {
                await GetSearchProducts();
            }
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
        SetError(false);
        SetLoading(true, "Searching...");
        Products.Clear();

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
            SetError(true,
                $"Slow or no internet connection. {Environment.NewLine}Please check you internet connection and try again.",
                "nointernet.png");

            Console.WriteLine("Slow or no internet connection." + Environment.NewLine + "Please check you internet connection and try again.");
        }
        catch (EmptySearchException)
        {
            SetError(true, "No search results.", "emptysearch.png");
            Console.WriteLine("No search results.");
        }
        catch (Exception)
        {
            SetError(true, "Something went wrong.", "error.png");
            Console.WriteLine("Something went wrong.");
        }
        finally
        {
            SetLoading(false);
        }

    }

    public async void GetAllProducts()
    {
        SetError(false);
        SetLoading(true, "Hold on while we get products...");

        try
        {
            List<Product> products;
            products = await ApiService.GetProducts();
            Products = new ObservableCollection<Product>(products);

            //this.DataLoaded = true;
        }
        catch (InternetConnectionException)
        {
            SetError(true,
                $"Slow or no internet connection. {Environment.NewLine}Please check you internet connection and try again.",
                "nointernet.png");

            Console.WriteLine("Slow or no internet connection." + Environment.NewLine + "Please check you internet connection and try again.");
        }
        catch (EmptySearchException)
        {
            SetError(true, "No search results.", "emptysearch.png");
            Console.WriteLine("No search results.");
        }
        catch (Exception)
        {
            SetError(true, "Something went wrong.", "error.png");
            Console.WriteLine("Something went wrong.");
        }
        finally
        {
            SetLoading(false);
        }
    }
    #endregion
}
