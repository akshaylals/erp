using ERP.Models;
using ERP.ViewModels;
using Debug = System.Diagnostics.Debug;

namespace ERP.Views;

public partial class ProductDetailsPage : ContentPage
{	
	public ProductDetailsPage(ProductDetailsViewModel viewModel)
	{
		InitializeComponent();
		//viewModel.GetProductCommand.Execute(viewModel);
		BindingContext = viewModel;
	}
}