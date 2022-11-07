namespace ERP.MVVM.Views;

public partial class CartPage : ViewBase<CartPageViewModel>
{
	public CartPage()
	{
		InitializeComponent();
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}