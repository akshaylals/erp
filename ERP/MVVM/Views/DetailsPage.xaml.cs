namespace ERP.MVVM.Views;

public partial class DetailsPage : ViewBase<DetailsPageViewModel>
{
    public DetailsPage(int id)
	{
		InitializeComponent();

        ViewModel.GetProduct(id);
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}