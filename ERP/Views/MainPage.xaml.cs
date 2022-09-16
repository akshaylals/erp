using ERP.ViewModels;
using Debug = System.Diagnostics.Debug;

namespace ERP.Views;

public partial class MainPage : ContentPage
{
	public MainPage(ProductsViewModel viewModel)
	{
		InitializeComponent();
		viewModel.GetProductsCommand.Execute(viewModel);
        BindingContext = viewModel;
	}

	private void DragGestureRecognizer_DragStarting_1(object sender, DragStartingEventArgs e)
	{
        var frame = (sender as Element)?.Parent as Frame;
        e.Data.Properties.Add("Id", frame.ClassId);
    }

    private void DropGestureRecognizer_Drop_1(object sender, DropEventArgs e)
    {
        var data = e.Data.Properties["Id"].ToString();
        var frame = (sender as Element)?.Parent as Frame;
    }
}

