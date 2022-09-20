using ERP.Services;
using ERP.ViewModels;
using Microsoft.Maui.Controls;
using Debug = System.Diagnostics.Debug;

namespace ERP.Views;

public partial class CartPage : ContentPage
{
    CartService cartService;
    CartViewModel viewModel;
	public CartPage()
	{
		InitializeComponent();
        cartService = new();
        viewModel = new(cartService);
        viewModel.GetCartProductsCommand.Execute(viewModel);
        BindingContext = viewModel;
    }

    private async void SwipeDeleteCart(object sender, SwipedEventArgs e)
    {
        var data = e.Parameter.ToString();
        CartService cartService = new CartService();
        await cartService.DeleteCartProduct(data);

        viewModel.GetCartProductsCommand.Execute(viewModel);

        //// Get current page
        //var page = Navigation.NavigationStack.LastOrDefault();

        //// Load new page
        //await Shell.Current.GoToAsync(nameof(CartPage), false);

        //// Remove old page
        //Navigation.RemovePage(page);
    }

    private void SwipeShowProduct(object sender, SwipedEventArgs e)
    {

    }
}