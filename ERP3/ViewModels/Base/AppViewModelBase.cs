using Microsoft.Maui.Controls;

namespace ERP3.ViewModels.Base;

public partial class AppViewModelBase : ViewModelBase
{
    public INavigation NavigationService { get; set; }
    public Page PageService { get; set; }

    protected IApiService _appApiService { get; set; }

    public Image dummyImage;

    public AppViewModelBase(IApiService appApiService) : base()
    {
        _appApiService = appApiService;
    }

    [RelayCommand]
    private async Task LogOut() =>
        App.Current.MainPage = new LoginPage(((App)Application.Current).OidcClient);

    [RelayCommand]
    private async Task NavigateBack() =>
        await NavigationService.PopAsync();

    [RelayCommand]
    private async Task NavigateBackToShell() =>
        ((App)Application.Current).NavigateBack();

    [RelayCommand]
    private async Task CloseModal() =>
        await NavigationService.PopModalAsync();

    public async void ShowAnimation(double x1, double y1, double x2, double y2)
    {
        dummyImage.Scale = 1;
        dummyImage.Rotation = 0;
        dummyImage.TranslationX = x1;
        dummyImage.TranslationY = y1;
        dummyImage.IsVisible = true;

        await Task.WhenAll(
            dummyImage.TranslateTo(x2, y2, 800, Easing.CubicInOut),
            dummyImage.RotateTo(1000, 800)
        );
        await dummyImage.ScaleTo(0, 200);

        dummyImage.IsVisible = false;
    }

}