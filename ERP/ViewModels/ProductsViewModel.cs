using ERP.Models;
using ERP.ViewModel;
using ERP.Services;
using System.Collections.ObjectModel;
using Debug = System.Diagnostics.Debug;
using CommunityToolkit.Mvvm.Input;

namespace ERP.ViewModels
{
    public partial class ProductsViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; } = new();

        ProductsService productsService;
        public ProductsViewModel(ProductsService productsService)
        {
            Title = "Products";
            this.productsService = productsService;
        }
        [RelayCommand]
        async Task GetProductsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var products = await productsService.GetProducts();

                if (Products.Count != 0)
                    Products.Clear();

                foreach (var product in products)
                    Products.Add(product);

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
    }
}
