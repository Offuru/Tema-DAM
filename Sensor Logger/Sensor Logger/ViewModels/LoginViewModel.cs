using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Sensor_Logger.Models;
using Sensor_Logger.Services;
using System.Windows.Input;

namespace Sensor_Logger.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private LoginService _loginService;

        [ObservableProperty]
        private User currentUser;

        public LoginViewModel(LoginService loginService)
        {
            _loginService = loginService;
        }

        #region Commands

        [RelayCommand]
        public async Task LoginUser(User? user)
        {
            var databaseUser = await _loginService.IsValidUser(user);
            if (user.Equals(databaseUser))
            {
                CurrentUser = databaseUser;
                _loginService.CurrentUser = databaseUser;
                await Shell.Current.CurrentPage.DisplayAlert("Alert", "Valid credentials", "OK");
                await Shell.Current.GoToAsync("//home");
            }
            else
            {
                await Shell.Current.CurrentPage.DisplayAlert("Alert", "Invalid credentials", "OK");
            }
        }

        [RelayCommand]
        public async Task RegisterUser(User? user)
        {
            var databaseUser = await _loginService.RegisterUser(user);

            if(user == null)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Alert", "User already exists", "OK");
            }
            else
            {
                CurrentUser = databaseUser;
                _loginService.CurrentUser = databaseUser;
                await Shell.Current.CurrentPage.DisplayAlert("Alert", "Succesfully registered", "OK");
                await Shell.Current.GoToAsync("//home");
            }
        }

        [RelayCommand]
        public void GoToRegistration()
        {
            Shell.Current.GoToAsync("//register");
        }

        #endregion
    }
}
