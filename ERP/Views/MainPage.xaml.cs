using ERP.Services;
using ERP.ViewModels;
using Debug = System.Diagnostics.Debug;

namespace ERP.Views;

public partial class MainPage : ContentPage
{
	public MainPage(ProductsViewModel viewModel)
	{
		InitializeComponent();
		viewModel.GetProductsCommand.Execute(viewModel);
        BindingContext = viewModel;
	}

    private void CartPageFn(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(CartPage));
    }

    private async void SwipeAddCart(object sender, SwipedEventArgs e)
    {
        var data = e.Parameter.ToString();
        CartService cartService = new CartService();
        await cartService.PostCartProduct(data);
    }

}

