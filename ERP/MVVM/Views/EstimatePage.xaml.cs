using Microsoft.Maui.Controls.Shapes;

namespace ERP.MVVM.Views;

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
        filterGrid.Children.Clear();

        if (ViewModel.filterObj.FilterString != "")
        {
            CreateFilterCard();
        }

        ViewModel.dummyImage = dummyImage;
    }

    private void ClearSearchButton_Clicked(object sender, EventArgs e)
    {
        txtSearchQuery.Text = String.Empty;
    }

    private void ClearFilterButton_Clicked(object sender, EventArgs e)
    {
        ViewModel.filterObj.FilterString = "";
        System.Diagnostics.Debug.WriteLine("filter Cleared!");
        filterGrid.Children.Clear();
    }

    private void CreateFilterCard()
    {
        Border border = new Border();
        border.Padding = new Thickness(12, 4);
        border.BackgroundColor = Color.FromArgb("#ffffff");
        border.HorizontalOptions = LayoutOptions.Fill;
        border.Margin = new Thickness(5, 0, 5, 8);
        border.HeightRequest = 40;
        border.StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(8) };
        Grid grid = new Grid
        {
            ColumnDefinitions =
            {
                new ColumnDefinition
                {
                    Width = new GridLength(.9, GridUnitType.Star)
                },
                new ColumnDefinition
                {
                    Width = new GridLength(.1, GridUnitType.Star)
                }
            }


        };
        grid.Add(new Label
        { Text = ViewModel.filterObj.FilterString }, 0);
        ImageButton imageButton = new ImageButton
        {
            WidthRequest = 18,
            HeightRequest = 18,
            Source = "ic_close.png",
            VerticalOptions = LayoutOptions.Center
        };
        Entry entry = new Entry();
        imageButton.Clicked += (s, e) =>
        {
            ViewModel.filterObj.FilterString = "";
            System.Diagnostics.Debug.WriteLine("filter Cleared!");
            filterGrid.Children.Clear();
        };
        grid.Add(imageButton, 1);
        border.Content = grid;
        filterGrid.Add(border);
    }
}