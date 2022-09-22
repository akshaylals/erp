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

        [ObservableProperty]
        Product product;

        public ProductDetailsViewModel()
        {
            Title = "Product";
            Debug.WriteLine("vm");
        }
        
        public async Task GetProduct()
        {
            ProductsService _service = new();
            product = await _service.GetProduct(Id);
        }
    }
}
