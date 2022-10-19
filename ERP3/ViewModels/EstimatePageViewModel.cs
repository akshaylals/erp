using ERP3.Models;

namespace ERP3.ViewModels;

public partial class EstimatePageViewModel : AppViewModelBase
{
    private string searchTerm = "iPhone 14";

    [ObservableProperty]
    private ObservableCollection<Product> products;

    [ObservableProperty]
    private int cartCount;

    [ObservableProperty]
    private bool cartBadgeVisible;

    public EstimatePageViewModel(IApiService appApiService) : base(appApiService)
    {
        this.Title = "Create Estimate";
    }

    private async Task Search()
    {
        SetDataLodingIndicators(true);

        LoadingText = "Hold on while we search for Products...";

        Products = new();

        try
        {
            //Search for videos
            await GetSearchProducts();

            this.DataLoaded = true;
        }
        catch (InternetConnectionException iex)
        {
            this.IsErrorState = true;
            this.ErrorMessage = "Slow or no internet connection." + Environment.NewLine + "Please check you internet connection and try again.";
            ErrorImage = "nointernet.png";
        }
        catch (Exception ex)
        {
            this.IsErrorState = true;
            this.ErrorMessage = $"Something went wrong. If the problem persists, plz contact support with the error message:" + Environment.NewLine + Environment.NewLine + ex.Message;
            ErrorImage = "error.png";
        }
        finally
        {
            SetDataLodingIndicators(false);
        }
    }

    private async Task GetSearchProducts()
    {
        SetDataLodingIndicators(true);

        LoadingText = "Hold on while we get products...";

        Products = new();

        try
        {
            var products = await _appApiService.GetProducts(searchTerm);
            Products.AddRange(products);
            this.DataLoaded = true;
        }
        catch (InternetConnectionException)
        {
            this.IsErrorState = true;
            this.ErrorMessage = "Slow or no internet connection." + Environment.NewLine + "Please check you internet connection and try again.";
            ErrorImage = "nointernet.png";
        }
        catch (EmptySearchException)
        {
            this.IsErrorState = true;
            this.ErrorMessage = $"No search results.";
            ErrorImage = "emptysearch.png";
        }
        catch (Exception)
        {
            this.IsErrorState = true;
            this.ErrorMessage = $"Something went wrong.";
            ErrorImage = "error.png";
        }
        finally
        {
            SetDataLodingIndicators(false);
        }

    }

    public async Task GetCartCount()
    {
        CartCount = await _appApiService.GetCartCount();
        if (CartCount == 0)
        {
            CartBadgeVisible = false;
        }
        else
        {
            CartBadgeVisible = true;
        }
    }

    public override async void OnNavigatedTo(object parameters)
    {
        await GetCartCount();
    }

    [RelayCommand]
    private async Task SearchProducts(string searchQuery)
    {
        searchTerm = searchQuery.Trim();

        await Search();
    }

    [RelayCommand]
    private async Task NavigateToFilterPage()
    {
        //await NavigationService.PushAsync(new CartPage());
        System.Diagnostics.Debug.WriteLine(App.Current.MainPage.ToString());
        ((App)Application.Current).NavigateTo(new FilterPage());
    }

    [RelayCommand]
    private async Task NavigateToCartPage()
    {
        System.Diagnostics.Debug.WriteLine(App.Current.MainPage.ToString());
        ((App)Application.Current).NavigateTo(new CartPage());
        //await NavigationService.PushAsync(new CartPage());
    }

    [RelayCommand]
    private async Task NavigateToDetailsPage(int id)
    {
        //await NavigationService.PushAsync(new DetailsPage($"{id}"));
        ((App)Application.Current).NavigateTo(new DetailsPage($"{id}"));
    }

    [RelayCommand]
    private async Task AddToCart(int id)
    {
        await _appApiService.PostCartItem(id);
        await GetCartCount();
    }
}
