﻿namespace ERP.MVVM.ViewModels;

public class LoginPageViewModel : ViewModelBase
{
    #region Binding Property
    #endregion

    public LoginPageViewModel()
    {
    }


    #region Commands
    public ICommand LoginCommand =>
        new Command(() =>
        {
            ((App)Application.Current).Authenticate();
        });
    #endregion

    #region functions
    #endregion
}