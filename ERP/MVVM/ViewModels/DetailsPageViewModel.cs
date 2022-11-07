namespace ERP.MVVM.ViewModels;

[AddINotifyPropertyChangedInterface]
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
        //SetDataLodingIndicators(true);

        //this.LoadingText = "Hold on while we load the product details...";

        try
        {
            Product = await ApiService.GetProduct(productID);

            //this.DataLoaded = true;
        }
        catch (InternetConnectionException)
        {
            //this.IsErrorState = true;
            //this.ErrorMessage = "Slow or no internet connection." + Environment.NewLine + "Please check you internet connection and try again.";
            //ErrorImage = "nointernet.png";
            Console.WriteLine("Slow or no internet connection." + Environment.NewLine + "Please check you internet connection and try again.");
        }
        catch (Exception)
        {
            //this.IsErrorState = true;
            //this.ErrorMessage = $"Something went wrong.";
            //ErrorImage = "error.png";
            Console.WriteLine("Something went wrong.");
        }
        finally
        {
            //SetDataLodingIndicators(false);
            Console.WriteLine("Loaded");
        }
    }
    #endregion
}
