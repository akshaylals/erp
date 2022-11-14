namespace ERP.MVVM.ViewModels;


public class CartPageViewModel : ViewModelBase
{
    public CartPageViewModel()
    {
        GetCartItems();
    }

    #region Binding Property
    public ObservableCollection<CartItem> CartItems { get; set; }
    #endregion

    #region Commands
    public ICommand NavigateToDetailsPageCommand =>
        new Command((id) =>
        {
            NavigationService.PushModalAsync(new DetailsPage((int)id));
        });

    public ICommand DeleteFromCartCommand =>
        new Command(async (id) =>
        {
            await ApiService.DeleteCartItem((int)id);

            await GetCartItems();
        });
    #endregion

    #region functions
    private async Task GetCartItems()
    {
        SetError(false);
        SetLoading(true, "Hold on while we get your cart...");

        try
        {
            CartItems = new();
            var cartItems = await ApiService.GetCartItems();
            cartItems.ForEach(async cartItem =>
            {
                CartItem item = new();
                item.id = cartItem.id;
                item.product = await ApiService.GetProduct(cartItem.productId);
                item.quantity = cartItem.quantity;
                CartItems.Add(item);
            });

            //this.DataLoaded = true;
        }
        catch (InternetConnectionException)
        {
            SetError(true,
                $"Slow or no internet connection.{Environment.NewLine}Please check you internet connection and try again.",
                "nointernet.png");
            
            Console.WriteLine("Slow or no internet connection." + Environment.NewLine + "Please check you internet connection and try again.");
        }
        catch (EmptyCartException)
        {
            SetError(true,
                "No items in cart.",
                "emptycart.png");
            
            Console.WriteLine("No items in cart.");
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
