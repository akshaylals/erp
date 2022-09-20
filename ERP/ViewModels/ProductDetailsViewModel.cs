using ERP.Models;
using ERP.ViewModel;
using ERP.Services;
using Debug = System.Diagnostics.Debug;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ERP.ViewModels
{
    public partial class ProductDetailsViewModel : BaseViewModel
    {
        [ObservableProperty]
        Product product;

        ProductsService productsService;

        public ProductDetailsViewModel(ProductsService productsService)
        {
            Title = "Product";
            this.productsService = productsService;
        }

        [RelayCommand]
        public async Task GetProductAsync(string id) 
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                product = await productsService.GetProduct(id);

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
