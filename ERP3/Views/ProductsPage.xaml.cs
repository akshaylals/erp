namespace ERP3.Views;

public partial class ProductsPage : ViewBase<ProductsPageViewModel>
{
	public ProductsPage()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		ViewModel.GetCartCount();
	}
}