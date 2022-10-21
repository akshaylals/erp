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
        ((App)Application.Current).NavigateBack();
    }

    private void ResetClicked(object sender, EventArgs e)
    {
        lastBtn.IsChecked = false;
		filterObj.filterString = "";
		System.Diagnostics.Debug.WriteLine($"FilterPage ResetClicked: {filterObj.filterString}");
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
			if (btn.IsChecked)
			{
				lastBtn = btn;
			}
		}
	}
}