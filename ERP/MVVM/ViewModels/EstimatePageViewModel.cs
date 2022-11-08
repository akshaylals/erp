﻿namespace ERP.MVVM.ViewModels;

[AddINotifyPropertyChangedInterface]
public class EstimatePageViewModel : ViewModelBase
{
    #region Binding Property
    public ObservableCollection<Product> Products { get; set; }
    public bool CartBadgeVisible { get; set; }
    public int CartCount { get; set; }
    #endregion

    #region Properties
    private string searchTerm = "";
    public FilterStringWrapper filterObj = new();
    public Image dummyImage;
    #endregion

    #region Commands
    public ICommand NavigateToDetailsPageCommand =>
        new Command((id) =>
        {
            NavigationService.PushModalAsync(new DetailsPage((int)id));
        });

    public ICommand AddToCartCommand =>
        new Command(async (id) =>
        {
            await ApiService.PostCartItem((int)id);
            await GetCartCount();
            ShowAnimation(-200, 600, 58, 40);
        });

    public ICommand SearchProductsCommand =>
        new Command(async (searchQuery) =>
        {
            searchTerm = ((string)searchQuery).Trim();
            await GetSearchProducts();
        });

    public ICommand NavigateToFilterPageCommand =>
        new Command(() =>
        {
            NavigationService.PushModalAsync(new FilterPage(ref filterObj));
        });

    public ICommand NavigateToCartPageCommand =>
        new Command(() =>
        {
            NavigationService.PushModalAsync(new CartPage());
        });
    #endregion

    #region functions
    public async Task GetCartCount()
    {
        CartCount = await ApiService.GetCartCount();
        if (CartCount == 0)
        {
            CartBadgeVisible = false;
        }
        else
        {
            CartBadgeVisible = true;
        }
    }

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

    private async Task GetSearchProducts()
    {
        //SetDataLodingIndicators(true);

        //LoadingText = "Hold on while we get products...";

        try
        {
            List<Product> products;
            Products = new();
            if (filterObj.FilterString == "")
            {
                products = await ApiService.GetProducts(searchTerm);
            }
            else
            {
                products = await ApiService.GetProducts(searchTerm, filterObj.FilterString);
            }
            Products = new ObservableCollection<Product>(products);

            //this.DataLoaded = true;
        }
        catch (InternetConnectionException)
        {
            //this.IsErrorState = true;
            //this.ErrorMessage = "Slow or no internet connection." + Environment.NewLine + "Please check you internet connection and try again.";
            Console.WriteLine("Slow or no internet connection." + Environment.NewLine + "Please check you internet connection and try again.");
            //ErrorImage = "nointernet.png";
        }
        catch (EmptySearchException)
        {
            //this.IsErrorState = true;
            //this.ErrorMessage = $"No search results.";
            Console.WriteLine("No search results.");
            //ErrorImage = "emptysearch.png";
        }
        catch (Exception)
        {
            //this.IsErrorState = true;
            //this.ErrorMessage = $"Something went wrong.";
            Console.WriteLine("Something went wrong.");
            //ErrorImage = "error.png";
        }
        finally
        {
            //SetDataLodingIndicators(false);
        }

    }
    #endregion
}