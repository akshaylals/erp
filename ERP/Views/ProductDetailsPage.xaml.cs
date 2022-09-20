using ERP.Models;
using ERP.ViewModels;

namespace ERP.Views;

[QueryProperty(nameof(Vm), "viewModel")]
public partial class ProductDetailsPage : ContentPage
{
	ProductDetailsViewModel viewModel;
	public ProductDetailsViewModel Vm
	{
		get => viewModel;
		set
		{
			viewModel = value;
			OnPropertyChanged();
		}

    }
	
	public ProductDetailsPage()
	{
		InitializeComponent();
		BindingContext = this;
	}
}