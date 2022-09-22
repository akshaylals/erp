using ERP.Models;
using ERP.ViewModels;
using Debug = System.Diagnostics.Debug;

namespace ERP.Views;

public partial class ProductDetailsPage : ContentPage
{
	public ProductDetailsPage(ProductDetailsViewModel viewModel)
	{
		InitializeComponent();
		Debug.WriteLine("Page");
		//viewModel.GetProductCommand.Execute(viewModel);
		BindingContext = viewModel;
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		await (BindingContext as ProductDetailsViewModel).GetProduct();
	}
}