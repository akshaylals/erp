using ERP.Services;
using ERP.ViewModels;

namespace ERP.Views;

public partial class CartPage : ContentPage
{
	public CartPage()
	{
		InitializeComponent();
        CartService cartService = new();
        CartViewModel viewModel = new(cartService);
        viewModel.GetCartProductsCommand.Execute(viewModel);
        BindingContext = viewModel;
    }
}