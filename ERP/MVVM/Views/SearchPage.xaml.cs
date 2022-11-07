namespace ERP.MVVM.Views;

public partial class SearchPage : ViewBase<SearchPageViewModel>
{
	public SearchPage()
	{
		InitializeComponent();
    }

    private void ClearSearchButton_Clicked(object sender, EventArgs e)
    {
        txtSearchQuery.Text = String.Empty;
        ViewModel.SearchProductsCommand.Execute(txtSearchQuery.Text);
    }
}