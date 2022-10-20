namespace ERP3.Views;

public partial class FilterPage : ViewBase<FilterPageViewModel>
{
	FilterStringWrapper filterObj;
	RadioButton lastBtn;

	public FilterPage(ref FilterStringWrapper fs)
	{
		InitializeComponent();
		filterObj = fs;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		CreateButtons();
	}

	private void DoneClicked(object sender, EventArgs e)
	{
		// return filterstring
        ((App)Application.Current).NavigateBack();
    }

    private void ResetClicked(object sender, EventArgs e)
    {
		filterObj.filterString = "";
		lastBtn.IsChecked = false;
    }

    private void RadioChanged(object sender, EventArgs e)
	{
        lastBtn = sender as RadioButton;
        filterObj.filterString = lastBtn.Content.ToString();
	}

	private void CreateButtons()
	{
		foreach (string category in ViewModel.categories)
		{
			RadioButton btn = new RadioButton();
			btn.GroupName = "radioFilter";
			btn.Content = category;
			btn.IsChecked = filterObj.filterString == category;
			btn.CheckedChanged += RadioChanged;
			radioButtons.Add(btn);
		}
	}
}