namespace ERP3;

public partial class App : Application
{
	List<Page> navStack = new();

	public App()
	{
		InitializeComponent();

		//MainPage = new NavigationPage(new ProductsPage());
		//MainPage = new NavigationPage(new AppShell());
		MainPage = new LoginPage();
	}

	public void NavigateTo(Page page)
	{
		this.navStack.Add(this.MainPage);
		this.MainPage = page;
	}

	public void NavigateBack()
	{
		this.MainPage = navStack[navStack.Count - 1];
		navStack.RemoveAt(navStack.Count - 1);
    }

}
