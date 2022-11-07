namespace ERP.MVVM.ViewModels;


[AddINotifyPropertyChangedInterface]
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
        //SetDataLodingIndicators(true);

        //LoadingText = "Hold on while we get your cart...";

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
            //this.IsErrorState = true;
            //this.ErrorMessage = "Slow or no internet connection." + Environment.NewLine + "Please check you internet connection and try again.";
            //ErrorImage = "nointernet.png";
            Console.WriteLine("Slow or no internet connection." + Environment.NewLine + "Please check you internet connection and try again.");
        }
        catch (EmptyCartException)
        {
            //this.IsErrorState = true;
            //this.ErrorMessage = $"No items in cart.";
            //ErrorImage = "emptycart.png";
            Console.WriteLine("No items in cart.");
        }
        catch (Exception)
        {
            //this.IsErrorState = true;
            //this.ErrorMessage = $"Something went wrong.";
            //ErrorImage = "error.png";
            Console.WriteLine("Something went wrong.");
        }
        finally
        {
            //SetDataLodingIndicators(false);
            Console.WriteLine("Loaded");

        }
    }
    #endregion
}
