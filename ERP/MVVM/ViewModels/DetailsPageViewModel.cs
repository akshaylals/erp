namespace ERP.MVVM.ViewModels;

public class DetailsPageViewModel : ViewModelBase
{
    #region Binding Property
    public Product Product { get; set; }
    #endregion

    #region Commands
    #endregion

    #region functions
    public async void GetProduct(int productID)
    {
        SetError(false);
        SetLoading(true, "Hold on while we load the product details...");

        try
        {
            Product = await ApiService.GetProduct(productID);
            //this.DataLoaded = true;
        }
        catch (InternetConnectionException)
        {
            SetError(true,
                $"Slow or no internet connection.{Environment.NewLine} Please check you internet connection and try again.",
                "nointernet.png");

            Console.WriteLine("Slow or no internet connection." + Environment.NewLine + "Please check you internet connection and try again.");
        }
        catch (Exception)
        {
            SetError(true,
                "Something went wrong.",
                "error.png");

            Console.WriteLine("Something went wrong.");
        }
        finally
        {
            SetLoading(false);
        }
    }
    #endregion
}
