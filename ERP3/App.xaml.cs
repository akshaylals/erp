namespace ERP3;

public partial class App : Application
{
	Page tempPage;
	public App()
	{
		InitializeComponent();

		//MainPage = new NavigationPage(new ProductsPage());
		//MainPage = new NavigationPage(new AppShell());
		MainPage = new AppShell();
	}

	public void NavigateTo(Page page)
	{
		this.tempPage = this.MainPage;
		this.MainPage = page;
	}

	public void NavigateBack()
	{
		this.MainPage = this.tempPage;
	}

}
