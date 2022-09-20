using ERP.ViewModels;

namespace ERP.Views;

public partial class ProductDetailsPage : ContentPage
{
	public ProductDetailsPage(ProductDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}