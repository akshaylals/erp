namespace ERP.MVVM.Views.Base;

public class ViewBase<TViewModel> : PageBase where TViewModel : ViewModelBase, new()
{
    protected TViewModel ViewModel { get; set; }

    public ViewBase() : base()
    {
        BindingContext = ViewModel = new TViewModel();

        ViewModel.NavigationService = this.Navigation;
        ViewModel.PageService = this;
    }
}
