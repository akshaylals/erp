namespace ERP3.ViewModels;

public partial class CartPageViewModel : AppViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<CartItem> cartItems;

    public CartPageViewModel(IApiService appApiService) : base(appApiService)
    {
        this.Title = "Cart";
    }

    private async Task GetCartItems()
    {
        SetDataLodingIndicators(true);

        LoadingText = "Hold on while we get your cart...";

        CartItems = new();

        try
        {
            var cartItems = await _appApiService.GetCartItems();
            cartItems.ForEach(async cartItem =>
            {
                CartItem item = new();
                item.Id = cartItem.Id;
                item.Product = await _appApiService.GetProduct(cartItem.Product.ToString());
                item.Quantity = cartItem.Quantity;
                CartItems.Add(item);
            });

            this.DataLoaded = true;
        }
        catch (InternetConnectionException)
        {
            this.IsErrorState = true;
            this.ErrorMessage = "Slow or no internet connection." + Environment.NewLine + "Please check you internet connection and try again.";
            ErrorImage = "nointernet.png";
        }
        catch (EmptyCartException)
        {
            this.IsErrorState = true;
            this.ErrorMessage = $"No items in cart.";
            ErrorImage = "emptycart.png";
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

    public override async void OnNavigatedTo(object parameters)
    {
        await GetCartItems();
    }

    [RelayCommand]
    private async Task NavigateToDetailsPage(int id)
    {
        ((App)Application.Current).NavigateTo(new DetailsPage($"{id}"));
    }

    [RelayCommand]
    private async Task DeleteFromCart(int id)
    {
        await _appApiService.DeleteCartItem(id);

        await GetCartItems();
    }
}
