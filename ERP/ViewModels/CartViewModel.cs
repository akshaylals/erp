using ERP.Models;
using ERP.ViewModel;
using ERP.Services;
using ERP.Views;
using System.Collections.ObjectModel;
using Debug = System.Diagnostics.Debug;
using CommunityToolkit.Mvvm.Input;

namespace ERP.ViewModels
{
    public partial class CartViewModel : BaseViewModel
    {
        public ObservableCollection<Product> CartProducts { get; } = new();

        CartService cartService;
        public CartViewModel(CartService cartService)
        {
            Title = "Cart";
            this.cartService = cartService;
        }

        [RelayCommand]
        async Task GetCartProductsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var products = await cartService.GetCartProducts();

                if (CartProducts.Count != 0)
                    CartProducts.Clear();

                foreach (var product in products)
                    CartProducts.Add(product);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get products: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        async Task GoToDetails(Product product)
        {
            if (product == null)
                return;

            await Shell.Current.GoToAsync(nameof(ProductDetailsPage), true, new Dictionary<string, object>
            {
                {
                    "Product", product
                }
            });
        }
    }
}
