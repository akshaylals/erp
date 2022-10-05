namespace ERP3.ViewModels;

public partial class DetailsPageViewModel : AppViewModelBase
{
    [ObservableProperty]
    Product product;

    public DetailsPageViewModel(IApiService appApiService) : base(appApiService)
    {
        this.Title = "Product Details";
    }

    public override async void OnNavigatedTo(object parameters)
    {
        var productID = (string)parameters;

        SetDataLodingIndicators(true);

        this.LoadingText = "Hold on while we load the product details...";

        try
        {
            Product = await _appApiService.GetProduct(productID);

            this.DataLoaded = true;
        }catch (InternetConnectionException)
        {
            this.IsErrorState = true;
            this.ErrorMessage = "Slow or no internet connection." + Environment.NewLine + "Please check you internet connection and try again.";
            ErrorImage = "nointernet.png";
        }
        catch (Exception)
        {
            this.IsErrorState = true;
            this.ErrorMessage = $"Something went wrong.";
            ErrorImage = "error.png";
        }
        finally
        {
            SetDataLodingIndicators(false);
        }
    }
}
