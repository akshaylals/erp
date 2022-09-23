using ERP.Models;
using ERP.ViewModel;
using ERP.Services;
using Debug = System.Diagnostics.Debug;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ERP.Views;

namespace ERP.ViewModels
{
    [QueryProperty(nameof(Product), "Product")]
    public partial class ProductDetailsViewModel : BaseViewModel
    { 
        [ObservableProperty]
        Product product;

        public ProductDetailsViewModel()
        {
            Title = "Product Details";
        }
    }
}
