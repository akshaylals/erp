namespace ERP3.Views;

public partial class EstimatePage : ViewBase<EstimatePageViewModel>
{
	public EstimatePage()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel.SearchProductsCommand.Execute("");
        ViewModel.GetCartCount();
    }

    public void FlyToCartAnimation(object obj, SwipedEventArgs e)
    {
        Frame frame = (Frame)obj;
        ViewModel.ShowAnimation(-200, 600, 58, 40);
    }

    async void txtSearchQuery_Completed(System.Object sender, System.EventArgs e)
    {
        ViewModel.SearchProductsCommand.Execute(txtSearchQuery.Text);
    }

    private void ClearSearchButton_Clicked(object sender, EventArgs e)
    {
        txtSearchQuery.Text = String.Empty;
    }
}