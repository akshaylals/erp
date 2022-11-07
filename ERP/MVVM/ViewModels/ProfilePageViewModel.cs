namespace ERP.MVVM.ViewModels;


public class ProfilePageViewModel : ViewModelBase
{
    public string Username { get; set; }
    public string Email { get; set; }

    public ProfilePageViewModel()
    {
        Username = Preferences.Get("username", "");
        Email = Preferences.Get("email", "");
    }
}
