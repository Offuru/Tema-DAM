using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Sensor_Logger.Models;
using Sensor_Logger.Services;

namespace Sensor_Logger.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private LoginService _loginService;

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
                await Shell.Current.CurrentPage.DisplayAlert("Alert", "Valid credentials", "OK");
            }
            else
            {
                await Shell.Current.CurrentPage.DisplayAlert("Alert", "Invalid credentials", "OK");
            }
        }

        #endregion
    }
}
