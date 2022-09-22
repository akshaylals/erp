﻿using ERP.Models;
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

        ProductsService productsService;

        public ProductDetailsViewModel(ProductsService productsService)
        {
            Title = "Product Details";
            this.productsService = productsService;
            Debug.WriteLine("vm");
        }
        
        public async Task GetProduct()
        {
            product = await productsService.GetProduct(Id);
        }
    }
}
