namespace ERP3.Views;

public partial class ProductsPage : ViewBase<ProductsPageViewModel>
{
	public ProductsPage()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		ViewModel.GetCartCount();
        string token = await SecureStorage.Default.GetAsync("token");
		Console.WriteLine(token);
    }

	public void FlyToCartAnimation(object obj, SwipedEventArgs e)
	{
		Frame frame = (Frame)obj;
		ViewModel.ShowAnimation(-200, 600, 82, 40);
	}

    async void txtSearchQuery_Completed(System.Object sender, System.EventArgs e)
    {
        ViewModel.SearchProductsCommand.Execute(txtSearchQuery.Text);
    }

	private void ClearSearchButton_Clicked(object sender, EventArgs e)
	{
        txtSearchQuery.Text = String.Empty;
        ViewModel.SearchProductsCommand.Execute(txtSearchQuery.Text);
    }
}