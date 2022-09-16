using ERP.Views;
using Debug = System.Diagnostics.Debug;
namespace ERP;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(CartPage), typeof(CartPage));
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
    }
}
