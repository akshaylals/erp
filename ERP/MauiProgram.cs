using ERP.Services;
using ERP.ViewModels;
using ERP.Views;
using SimpleRatingControlMaui;
using CommunityToolkit.Maui;

namespace ERP;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().UseSimpleRatingControl().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();
        builder.Services.AddSingleton<ProductsService>();
        builder.Services.AddSingleton<ProductsViewModel>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<ProductDetailsPage>();
        builder.Services.AddTransient<ProductDetailsViewModel>();
        return builder.Build();
    }
}