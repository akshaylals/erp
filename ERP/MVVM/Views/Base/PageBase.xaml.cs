namespace ERP.MVVM.Views.Base;

public partial class PageBase : ContentPage
{
    public IList<Microsoft.Maui.IView> PageContent => PageContentGrid.Children;
    public PageBase()
	{
		InitializeComponent();
	}
}