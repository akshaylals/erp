namespace ERP.MVVM.Views;

public partial class FilterPage : ViewBase<FilterPageViewModel>
{
    RadioButton lastBtn;

    public FilterPage(ref FilterStringWrapper fs)
    {
        InitializeComponent();
        ViewModel.FilterObj = fs;
    }

    private void DoneClicked(object sender, EventArgs e)
    {
        if (lastBtn != null)
        {
            ViewModel.FilterObj.FilterString = lastBtn.Content.ToString();
        }
        else
        {
            ViewModel.FilterObj.FilterString = "";
        }
        Navigation.PopModalAsync();
    }

    private void ResetClicked(object sender, EventArgs e)
    {
        if(lastBtn != null)
        {
            lastBtn.IsChecked = false;
            lastBtn = null;
        }
    }

    private void RadioChanged(object sender, EventArgs e)
    {
        lastBtn = sender as RadioButton;
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}