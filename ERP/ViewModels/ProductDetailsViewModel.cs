using ERP.Models;
using ERP.ViewModel;
using ERP.Services;
using Debug = System.Diagnostics.Debug;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ERP.Views;

namespace ERP.ViewModels
{
    [QueryProperty("Id", "Id")]
    public partial class ProductDetailsViewModel : BaseViewModel
    {
        [ObservableProperty]
        string id;

        public ProductDetailsViewModel()
        {
            Title = "Product";
        }
        [RelayCommand]
        public async Task<Product> GetProduct()
        {
            ProductsService _service = new();
            Debug.WriteLine(Id);
            return await _service.GetProduct(Id);
        }
    }
}
