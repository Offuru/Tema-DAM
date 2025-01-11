using Sensor_Logger.ViewModels;
using System.Diagnostics;

namespace Sensor_Logger.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(LoginViewModel loginViewModel)
	{
		InitializeComponent();
		BindingContext = loginViewModel;
	}

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("//login");

        return true;
    }
}