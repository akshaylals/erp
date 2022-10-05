using ERP3.Models;

namespace ERP3.ViewModels;

public partial class ProductsPageViewModel : AppViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<Product> products;
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
        catch (InternetConnectionException iex)
        {
            this.IsErrorState = true;
            this.ErrorMessage = "Slow or no internet connection." + Environment.NewLine + "Please check you internet connection and try again.";
            ErrorImage = "nointernet.png";
        }
        catch (Exception ex)
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

    public override async void OnNavigatedTo(object parameters)
    {
        await GetProducts();
    }

    [RelayCommand]
    private async Task NavigateToCartPage()
    {
        await NavigationService.PushAsync(new CartPage());
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
    }
}
