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

	public void FlyToCartAnimation(object obj, SwipedEventArgs e)
	{
		Frame frame = (Frame)obj;
		ViewModel.ShowAnimation(-200, 600, 82, 40);
	}
}