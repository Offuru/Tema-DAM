using Sensor_Logger.ViewModels;

namespace Sensor_Logger.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel loginViewModel)
	{
		InitializeComponent();
		BindingContext = loginViewModel;
	}

    protected override bool OnBackButtonPressed()
    {
        // Global back button logic
        Shell.Current.GoToAsync("..");
        return true; // Prevent default behavior
    }
}