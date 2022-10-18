namespace ERP3.ViewModels;

public partial class ProductsPageViewModel : AppViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<Product> products;

    [ObservableProperty]
    private int cartCount;

    [ObservableProperty]
    private bool cartBadgeVisible;

    public ProductsPageViewModel(IApiService appApiService) : base(appApiService)
    {
        this.Title = "Products";
    }

    private async Task GetProducts()
    {
        SetDataLodingIndicators(true);

        LoadingText = "Hold on while we get products...";

        Products = new();

        try
        {
            var products = await _appApiService.GetProducts();
            Products.AddRange(products);
            this.DataLoaded = true;
        }
        catch (InternetConnectionException)
        {
            this.IsErrorState = true;
            this.ErrorMessage = "Slow or no internet connection." + Environment.NewLine + "Please check you internet connection and try again.";
            ErrorImage = "nointernet.png";
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
        if(CartCount == 0)
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
        await GetProducts();
        await GetCartCount();
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
        await NavigationService.PushAsync(new DetailsPage($"{id}"));
    }

    [RelayCommand]
    private async Task AddToCart(int id)
    {
        await _appApiService.PostCartItem(id);
        await GetCartCount();
    }
}
