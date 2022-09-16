using ERP.ViewModels;

namespace ERP.Views;

public partial class MainPage : ContentPage
{
	public MainPage(ProductsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

